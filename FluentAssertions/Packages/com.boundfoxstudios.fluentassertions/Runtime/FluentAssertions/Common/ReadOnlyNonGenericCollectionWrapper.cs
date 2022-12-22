﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FluentAssertions.Common {

internal static class ReadOnlyNonGenericCollectionWrapper
{
    public static ReadOnlyNonGenericCollectionWrapper<DataTableCollection, DataTable> Create(DataTableCollection collection)
    {
        return
            (collection != null)
            ? new ReadOnlyNonGenericCollectionWrapper<DataTableCollection, DataTable>(collection)
            : null;
    }

    public static ReadOnlyNonGenericCollectionWrapper<DataColumnCollection, DataColumn> Create(DataColumnCollection collection)
    {
        return
            (collection != null)
            ? new ReadOnlyNonGenericCollectionWrapper<DataColumnCollection, DataColumn>(collection)
            : null;
    }

    public static ReadOnlyNonGenericCollectionWrapper<DataRowCollection, DataRow> Create(DataRowCollection collection)
    {
        return
            (collection != null)
            ? new ReadOnlyNonGenericCollectionWrapper<DataRowCollection, DataRow>(collection)
            : null;
    }
}

internal class ReadOnlyNonGenericCollectionWrapper<TCollection, TItem> : ICollection<TItem>, ICollectionWrapper<TCollection>
    where TCollection : ICollection
{
    public TCollection UnderlyingCollection { get; }

    public ReadOnlyNonGenericCollectionWrapper(TCollection collection)
    {
        Guard.ThrowIfArgumentIsNull(collection, nameof(collection));

        UnderlyingCollection = collection;
    }

    public int Count => UnderlyingCollection.Count;

    bool ICollection<TItem>.IsReadOnly => true;

    public IEnumerator<TItem> GetEnumerator() => UnderlyingCollection.Cast<TItem>().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => UnderlyingCollection.GetEnumerator();

    public bool Contains(TItem item) => UnderlyingCollection.Cast<TItem>().Contains(item);

    public void CopyTo(TItem[] array, int arrayIndex) => UnderlyingCollection.CopyTo(array, arrayIndex);

    void ICollection<TItem>.Add(TItem item) => throw new NotSupportedException();

    void ICollection<TItem>.Clear() => throw new NotSupportedException();

    bool ICollection<TItem>.Remove(TItem item) => throw new NotSupportedException();
}
}