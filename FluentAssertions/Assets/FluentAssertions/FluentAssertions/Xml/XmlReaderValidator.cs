﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using FluentAssertions.Execution;

namespace FluentAssertions.Xml
{
    internal class XmlReaderValidator
    {
        private readonly AssertionScope assertion;
        private readonly XmlReader subjectReader;
        private readonly XmlReader otherReader;

        private string GetCurrentLocation() => "/" + string.Join("/", locationStack.Reverse());

        private readonly Stack<string> locationStack = new Stack<string>();

        public XmlReaderValidator(XmlReader subjectReader, XmlReader otherReader, string because, object[] reasonArgs)
        {
            assertion = Execute.Assertion.BecauseOf(because, reasonArgs);

            this.subjectReader = subjectReader;
            this.otherReader = otherReader;
        }

        private class ValidationResult
        {
            public ValidationResult(string formatString, params object[] formatParams)
            {
                FormatString = formatString;
                FormatParams = formatParams;
            }

            public string FormatString { get; }

            public object[] FormatParams { get; }
        }

        public void Validate(bool expectedEquivalence)
        {
            ValidationResult validationResult = Validate();

            if (expectedEquivalence && validationResult != null)
            {
                assertion.FailWith(validationResult.FormatString, validationResult.FormatParams);
            }

            if (!expectedEquivalence && validationResult is null)
            {
                assertion.FailWith("Did not expect Xml to be equivalent{reason}, but it is.");
            }
        }

        private ValidationResult Validate()
        {
            subjectReader.MoveToContent();
            otherReader.MoveToContent();
            while (!subjectReader.EOF && !otherReader.EOF)
            {
                if (subjectReader.NodeType != otherReader.NodeType)
                {
                    return new ValidationResult("Expected node of type {0} at {1}{reason}, but found {2}.",
                        otherReader.NodeType, GetCurrentLocation(), subjectReader.NodeType);
                }

                ValidationResult validationResult = null;

#pragma warning disable IDE0010 // System.Xml.XmlNodeType has many members we do not care about
                switch (subjectReader.NodeType)
#pragma warning restore IDE0010
                {
                    case XmlNodeType.Element:
                        validationResult = ValidateStartElement();
                        if (validationResult != null)
                        {
                            return validationResult;
                        }

                        locationStack.Push(subjectReader.LocalName);
                        validationResult = ValidateAttributes();
                        if (subjectReader.IsEmptyElement)
                        {
                            locationStack.Pop();
                        }

                        break;
                    case XmlNodeType.EndElement:
                        // No need to verify end element, if it doesn't match
                        // the start element it isn't valid XML, so the parser
                        // would handle that.
                        locationStack.Pop();
                        break;
                    case XmlNodeType.Text:
                        validationResult = ValidateText();
                        break;
                    default:
                        throw new NotSupportedException($"{subjectReader.NodeType} found at {GetCurrentLocation()} is not supported for equivalency comparison.");
                }

                if (validationResult != null)
                {
                    return validationResult;
                }

                subjectReader.Read();
                otherReader.Read();

                subjectReader.MoveToContent();
                otherReader.MoveToContent();
            }

            if (!otherReader.EOF)
            {
                return new ValidationResult("Expected {0}{reason}, but found end of document.",
                    otherReader.LocalName);
            }

            if (!subjectReader.EOF)
            {
                return new ValidationResult("Expected end of document{reason}, but found {0}.",
                    subjectReader.LocalName);
            }

            return null;
        }

        private class AttributeData
        {
            public AttributeData(string namespaceUri, string localName, string value, string prefix)
            {
                NamespaceUri = namespaceUri;
                LocalName = localName;
                Value = value;
                Prefix = prefix;
            }

            public string NamespaceUri { get; }

            public string LocalName { get; }

            public string Value { get; }

            public string Prefix { get; }

            public string QualifiedName
            {
                get
                {
                    if (string.IsNullOrEmpty(Prefix))
                    {
                        return LocalName;
                    }

                    return Prefix + ":" + LocalName;
                }
            }
        }

        private ValidationResult ValidateAttributes()
        {
            IList<AttributeData> expectedAttributes = GetAttributes(otherReader);
            IList<AttributeData> subjectAttributes = GetAttributes(subjectReader);

            foreach (AttributeData subjectAttribute in subjectAttributes)
            {
                AttributeData expectedAttribute = expectedAttributes.SingleOrDefault(
                    ea => ea.NamespaceUri == subjectAttribute.NamespaceUri
                    && ea.LocalName == subjectAttribute.LocalName);

                if (expectedAttribute is null)
                {
                    return new ValidationResult("Did not expect to find attribute {0} at {1}{reason}.",
                        subjectAttribute.QualifiedName, GetCurrentLocation());
                }

                if (subjectAttribute.Value != expectedAttribute.Value)
                {
                    return new ValidationResult("Expected attribute {0} at {1} to have value {2}{reason}, but found {3}.",
                        subjectAttribute.LocalName, GetCurrentLocation(), expectedAttribute.Value, subjectAttribute.Value);
                }
            }

            if (subjectAttributes.Count != expectedAttributes.Count)
            {
                AttributeData missingAttribute = expectedAttributes.First(ea =>
                    !subjectAttributes.Any(sa =>
                        ea.NamespaceUri == sa.NamespaceUri
                        && sa.LocalName == ea.LocalName));

                return new ValidationResult("Expected attribute {0} at {1}{reason}, but found none.",
                    missingAttribute.LocalName, GetCurrentLocation());
            }

            return null;
        }

        private static IList<AttributeData> GetAttributes(XmlReader reader)
        {
            var attributes = new List<AttributeData>();

            if (reader.MoveToFirstAttribute())
            {
                do
                {
                    if (reader.NamespaceURI != "http://www.w3.org/2000/xmlns/")
                    {
                        attributes.Add(new AttributeData(reader.NamespaceURI, reader.LocalName, reader.Value, reader.Prefix));
                    }
                }
                while (reader.MoveToNextAttribute());
            }

            return attributes;
        }

        private ValidationResult ValidateStartElement()
        {
            if (subjectReader.LocalName != otherReader.LocalName)
            {
                return new ValidationResult("Expected local name of element at {0} to be {1}{reason}, but found {2}.",
                    GetCurrentLocation(), otherReader.LocalName, subjectReader.LocalName);
            }

            if (subjectReader.NamespaceURI != otherReader.NamespaceURI)
            {
                return new ValidationResult("Expected namespace of element {0} at {1} to be {2}{reason}, but found {3}.",
                    subjectReader.LocalName, GetCurrentLocation(), otherReader.NamespaceURI, subjectReader.NamespaceURI);
            }

            return null;
        }

        private ValidationResult ValidateText()
        {
            string subject = subjectReader.Value;
            string expected = otherReader.Value;

            if (subject != expected)
            {
                return new ValidationResult("Expected content to be {0} at {1}{reason}, but found {2}.",
                    expected, GetCurrentLocation(), subject);
            }

            return null;
        }
    }
}
