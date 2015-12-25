﻿using JetBrains.Annotations;
using Microsoft.Data.Entity.Utilities;

namespace Microsoft.Data.Entity.Scaffolding.Metadata
{
    public class SqlCeColumnModelAnnotations
    {
        private readonly ColumnModel _column;

        public SqlCeColumnModelAnnotations([NotNull] ColumnModel column)
        {
            Check.NotNull(column, nameof(column));

            _column = column;
        }

        public virtual bool IsIdentity
        {
            get
            {
                var value = _column[SqlCeDatabaseModelAnnotationNames.IsIdentity];
                return value is bool ? (bool)value : false;
            }
            [param: NotNull]
            set
            {
                _column[SqlCeDatabaseModelAnnotationNames.IsIdentity] = value;
            }
        }
    }
}