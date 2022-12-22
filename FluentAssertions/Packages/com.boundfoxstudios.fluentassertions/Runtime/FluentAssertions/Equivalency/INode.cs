using System;
using JetBrains.Annotations;

namespace FluentAssertions.Equivalency {

/// <summary>
/// Represents a node in the object graph that is being compared as part of a structural equivalency check.
/// This can be the root object, a collection item, a dictionary element, a property or a field.
/// </summary>
public interface INode
{
    /// <summary>
    /// The name of the variable on which a structural equivalency assertion is executed or
    /// the default if reflection failed.
    /// </summary>
    GetSubjectId GetSubjectId { get; }

    /// <summary>
    /// Gets the name of this node.
    /// </summary>
    /// <example>
    /// "Property2"
    /// </example>
    string Name { get; set; }

    /// <summary>
    /// Gets the type of this node, e.g. the type of the field or property, or the type of the collection item. 
    /// </summary>
    Type Type { get; }

    /// <summary>
    /// Gets the type of the parent node, e.g. the type that declares a property or field.
    /// </summary>
    /// <value>
    /// Is <c>null</c> for the root object.
    /// </value>
    [CanBeNull]
    Type ParentType { get; }

    /// <summary>
    /// Gets the path from the root object UNTIL the current node, separated by dots or index/key brackets.
    /// </summary>
    /// <example>
    /// "Parent[0].Property2"
    /// </example>
    string Path { get; }

    /// <summary>
    /// Gets the full path from the root object up to and including the name of the node.
    /// </summary>
    /// <example>
    /// "Parent[0]"
    /// </example>
    string PathAndName { get; }

    /// <summary>
    /// Gets a zero-based number representing the depth within the object graph
    /// </summary>
    int Depth { get; }

    /// <summary>
    /// Gets the path including the description of the subject.
    /// </summary>
    /// <example>
    /// "property subject.Parent[0].Property2"
    /// </example>
    string Description { get; }

    /// <summary>
    /// Gets a value indicating whether the current node is the root.
    /// </summary>
    bool IsRoot { get; }

    /// <summary>
    /// Gets a value indicating if the root of this graph is a collection.
    /// </summary>
    bool RootIsCollection { get; }
}

/// <summary>
/// Allows deferred fetching of the subject ID.
/// </summary>
public delegate string GetSubjectId();
}