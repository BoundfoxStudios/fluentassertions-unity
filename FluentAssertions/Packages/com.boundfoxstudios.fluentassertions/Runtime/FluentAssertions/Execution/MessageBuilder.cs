﻿#region

using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions.Common;
using FluentAssertions.Formatting;

#endregion

namespace FluentAssertions.Execution;

/// <summary>
/// Encapsulates expanding the various placeholders supported in a failure message.
/// </summary>
internal class MessageBuilder
{
    private readonly FormattingOptions formattingOptions;

    #region Private Definitions

    private readonly char[] blanks = { '\r', '\n', ' ', '\t' };

    #endregion

    public MessageBuilder(FormattingOptions formattingOptions)
    {
        this.formattingOptions = formattingOptions;
    }

    // SMELL: Too many parameters.
    public string Build(string message, object[] messageArgs, string reason, ContextDataItems contextData, string identifier, string fallbackIdentifier)
    {
        message = Regex.Replace(message, "{reason}", SanitizeReason(reason));

        message = SubstituteIdentifier(message, identifier?.EscapePlaceholders(), fallbackIdentifier);

        message = SubstituteContextualTags(message, contextData);

        message = FormatArgumentPlaceholders(message, messageArgs);

        return message;
    }

    private static string SubstituteIdentifier(string message, string identifier, string fallbackIdentifier)
    {
        const string pattern = @"(?:\s|^)\{context(?:\:(?<default>[a-z|A-Z|\s]+))?\}";

        message = Regex.Replace(message, pattern, match =>
        {
            const string result = " ";
            if (!string.IsNullOrEmpty(identifier))
            {
                return result + identifier;
            }

            string defaultIdentifier = match.Groups["default"].Value;

            if (!string.IsNullOrEmpty(defaultIdentifier))
            {
                return result + defaultIdentifier;
            }

            if (!string.IsNullOrEmpty(fallbackIdentifier))
            {
                return result + fallbackIdentifier;
            }

            return " object";
        });

        return message.TrimStart();
    }

    private static string SubstituteContextualTags(string message, ContextDataItems contextData)
    {
        const string pattern = @"(?<!\{)\{(?<key>[a-z|A-Z]+)(?:\:(?<default>[a-z|A-Z|\s]+))?\}(?!\})";

        return Regex.Replace(message, pattern, match =>
        {
            string key = match.Groups["key"].Value;
            string contextualTags = contextData.AsStringOrDefault(key);
            string contextualTagsSubstituted = contextualTags?.EscapePlaceholders();

            return contextualTagsSubstituted ?? match.Groups["default"].Value;
        });
    }

    private string FormatArgumentPlaceholders(string failureMessage, object[] failureArgs)
    {
        string[] values = failureArgs.Select(a => Formatter.ToString(a, formattingOptions)).ToArray();

        try
        {
            return string.Format(CultureInfo.InvariantCulture, failureMessage, values);
        }
        catch (FormatException formatException)
        {
            return $"**WARNING** failure message '{failureMessage}' could not be formatted with string.Format{Environment.NewLine}{formatException.StackTrace}";
        }
    }

    private string SanitizeReason(string reason)
    {
        if (!string.IsNullOrEmpty(reason))
        {
            reason = EnsurePrefix("because", reason);
            reason = reason.EscapePlaceholders();

            return StartsWithBlank(reason) ? reason : " " + reason;
        }

        return string.Empty;
    }

    // SMELL: looks way too complex just to retain the leading whitespace
    private string EnsurePrefix(string prefix, string text)
    {
        string leadingBlanks = ExtractLeadingBlanksFrom(text);
        string textWithoutLeadingBlanks = text.Substring(leadingBlanks.Length);

        return !textWithoutLeadingBlanks.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
            ? leadingBlanks + prefix + " " + textWithoutLeadingBlanks
            : text;
    }

    private string ExtractLeadingBlanksFrom(string text)
    {
        string trimmedText = text.TrimStart(blanks);
        int leadingBlanksCount = text.Length - trimmedText.Length;

        return text.Substring(0, leadingBlanksCount);
    }

    private bool StartsWithBlank(string text)
    {
        return (text.Length > 0) && blanks.Contains(text[0]);
    }
}
