﻿#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Equivalency;
using FluentAssertions.Equivalency.Steps;

#endregion

namespace FluentAssertions {

/// <summary>
/// Represents a mutable collection of equivalency steps that can be reordered and/or amended with additional
/// custom equivalency steps.
/// </summary>
public class EquivalencyPlan : IEnumerable<IEquivalencyStep>
{
    private List<IEquivalencyStep> steps;

    public EquivalencyPlan()
    {
        steps = GetDefaultSteps();
    }

    public IEnumerator<IEquivalencyStep> GetEnumerator()
    {
        return steps.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Adds a new <see cref="IEquivalencyStep"/> after any of the built-in steps, with the exception of the final
    /// <see cref="SimpleEqualityEquivalencyStep"/>.
    /// </summary>
    public void Add<TStep>()
        where TStep : IEquivalencyStep, new()
    {
        InsertBefore<SimpleEqualityEquivalencyStep, TStep>();
    }

    /// <summary>
    /// Adds a new <see cref="IEquivalencyStep"/> right after the specified <typeparamref name="TPredecessor"/>.
    /// </summary>
    public void AddAfter<TPredecessor, TStep>()
        where TStep : IEquivalencyStep, new()
    {
        int insertIndex = Math.Max(steps.Count - 1, 0);

        IEquivalencyStep predecessor = steps.LastOrDefault(s => s is TPredecessor);
        if (predecessor is not null)
        {
            insertIndex = Math.Min(insertIndex, steps.LastIndexOf(predecessor) + 1);
        }

        steps.Insert(insertIndex, new TStep());
    }

    /// <summary>
    /// Inserts a new <see cref="IEquivalencyStep"/> before any of the built-in steps.
    /// </summary>
    public void Insert<TStep>()
        where TStep : IEquivalencyStep, new()
    {
        steps.Insert(0, new TStep());
    }

    /// <summary>
    /// Inserts a new <see cref="IEquivalencyStep"/> just before the <typeparamref name="TSuccessor"/>.
    /// </summary>
    public void InsertBefore<TSuccessor, TStep>()
        where TStep : IEquivalencyStep, new()
    {
        int insertIndex = Math.Max(steps.Count - 1, 0);

        IEquivalencyStep equalityStep = steps.LastOrDefault(s => s is TSuccessor);
        if (equalityStep is not null)
        {
            insertIndex = steps.LastIndexOf(equalityStep);
        }

        steps.Insert(insertIndex, new TStep());
    }

    /// <summary>
    /// Removes all instances of the specified <typeparamref name="TStep"/> from the current step.
    /// </summary>
    public void Remove<TStep>()
        where TStep : IEquivalencyStep
    {
        steps.RemoveAll(s => s is TStep);
    }

    /// <summary>
    /// Removes each and every built-in <see cref="IEquivalencyStep"/>.
    /// </summary>
    public void Clear()
    {
        steps.Clear();
    }

    public void Reset()
    {
        steps = GetDefaultSteps();
    }

    private static List<IEquivalencyStep> GetDefaultSteps()
    {
        return new(18)
        {
            new RunAllUserStepsEquivalencyStep(),
            new AutoConversionStep(),
            new ReferenceEqualityEquivalencyStep(),
            new GenericDictionaryEquivalencyStep(),
            new DataSetEquivalencyStep(),
            new DataTableEquivalencyStep(),
            new DataColumnEquivalencyStep(),
            new DataRelationEquivalencyStep(),
            new DataRowCollectionEquivalencyStep(),
            new DataRowEquivalencyStep(),
            new XDocumentEquivalencyStep(),
            new XElementEquivalencyStep(),
            new XAttributeEquivalencyStep(),
            new ConstraintCollectionEquivalencyStep(),
            new ConstraintEquivalencyStep(),
            new DictionaryEquivalencyStep(),
            new MultiDimensionalArrayEquivalencyStep(),
            new GenericEnumerableEquivalencyStep(),
            new EnumerableEquivalencyStep(),
            new StringEqualityEquivalencyStep(),
            new EnumEqualityStep(),
            new ValueTypeEquivalencyStep(),
            new StructuralEqualityEquivalencyStep(),
            new SimpleEqualityEquivalencyStep(),
        };
    }
}
}