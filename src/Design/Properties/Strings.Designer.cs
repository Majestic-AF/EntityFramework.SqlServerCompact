// <auto-generated />
namespace Microsoft.Data.Entity.SqlServerCompact.Design
{
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
	using JetBrains.Annotations;

    public static class Strings
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("EntityFramework7.SqlServerCompact40.Design.Strings", typeof(Strings).GetTypeInfo().Assembly);

        /// <summary>
        /// Could not find foreignKeyMapping for ConstraintId {constraintId} for FromColumn {fromColumnId}.
        /// </summary>
        public static string CannotFindForeignKeyMappingForConstraintId([CanBeNull] object constraintId, [CanBeNull] object fromColumnId)
        {
            return string.Format(CultureInfo.CurrentCulture, "Could not find foreignKeyMapping for ConstraintId {0} for FromColumn {1}", constraintId, fromColumnId);
        }

        /// <summary>
        /// For foreign key ConstraintId {constraintId}, could not find relational property mapped to ToColumn with ColumnId {toColumnId}.
        /// </summary>
        public static string CannotFindRelationalPropertyForColumnId([CanBeNull] object constraintId, [CanBeNull] object toColumnId)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("CannotFindRelationalPropertyForColumnId", "constraintId", "toColumnId"), constraintId, toColumnId);
        }

        /// <summary>
        /// For columnId {columnId}. Could not find table with TableId {tableId}. Skipping column.
        /// </summary>
        public static string CannotFindTableForColumn([CanBeNull] object columnId, [CanBeNull] object tableId)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("CannotFindTableForColumn", "columnId", "tableId"), columnId, tableId);
        }

        /// <summary>
        /// For foreign key ConstraintId {constraintId}. Could not find ToColumn with ColumnId {toColumnId}.
        /// </summary>
        public static string CannotFindToColumnForConstraintId([CanBeNull] object constraintId, [CanBeNull] object toColumnId)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("CannotFindToColumnForConstraintId", "constraintId", "toColumnId"), constraintId, toColumnId);
        }

        /// <summary>
        /// For columnId {columnId}. Could not find type mapping for SQL Server type {sqlServerDataType}. Skipping column.
        /// </summary>
        public static string CannotFindTypeMappingForColumn([CanBeNull] object columnId, [CanBeNull] object sqlServerDataType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("CannotFindTypeMappingForColumn", "columnId", "sqlServerDataType"), columnId, sqlServerDataType);
        }

        /// <summary>
        /// Unable to generate EntityType {entityTypeName}. Error message: {errorMessage}
        /// </summary>
        public static string CannotGenerateEntityType([CanBeNull] object entityTypeName, [CanBeNull] object errorMessage)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("CannotGenerateEntityType", "entityTypeName", "errorMessage"), entityTypeName, errorMessage);
        }

        /// <summary>
        /// Unable to interpret the string {sqlServerStringLiteral} as a SQLServer string literal.
        /// </summary>
        public static string CannotInterpretSqlServerStringLiteral([CanBeNull] object sqlServerStringLiteral)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("CannotInterpretSqlServerStringLiteral", "sqlServerStringLiteral"), sqlServerStringLiteral);
        }

        /// <summary>
        /// For columnId {columnId}. The SQL Server data type is {sqlServerDataType}. This will be mapped to CLR type byte which does not allow IdentityStrategy Identity. Generating a matching Property but ignoring the Identity setting.
        /// </summary>
        public static string DataTypeDoesNotAllowIdentityStrategy([CanBeNull] object columnId, [CanBeNull] object sqlServerDataType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("DataTypeDoesNotAllowIdentityStrategy", "columnId", "sqlServerDataType"), columnId, sqlServerDataType);
        }

        /// <summary>
        /// Attempt to generate EntityType {entityTypeName} failed. Unable to identify any primary key columns in the underlying SQL Server table {schemaName}.{name}.
        /// </summary>
        public static string NoPrimaryKeyColumns([CanBeNull] object entityTypeName, [CanBeNull] object schemaName, [CanBeNull] object name)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("NoPrimaryKeyColumns", "entityTypeName", "schemaName", "name"), entityTypeName, schemaName, name);
        }

        /// <summary>
        /// Unable to add a Navigation Property referencing type {referencedEntityTypeName} because of errors generating that EntityType.
        /// </summary>
        public static string UnableToAddNavigationProperty([CanBeNull] object referencedEntityTypeName)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("UnableToAddNavigationProperty", "referencedEntityTypeName"), referencedEntityTypeName);
        }

        /// <summary>
        /// For columnId {columnId} unable to convert default value {defaultValue} into type {propertyType}. Will not generate code setting a default value for the property {propertyName} on entity type {entityTypeName}.
        /// </summary>
        public static string UnableToConvertDefaultValue([CanBeNull] object columnId, [CanBeNull] object defaultValue, [CanBeNull] object propertyType, [CanBeNull] object propertyName, [CanBeNull] object entityTypeName)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("UnableToConvertDefaultValue", "columnId", "defaultValue", "propertyType", "propertyName", "entityTypeName"), columnId, defaultValue, propertyType, propertyName, entityTypeName);
        }

        private static string GetString(string name, params string[] formatterNames)
        {
            //TODO Add error messages
            return name;

            //var value = _resourceManager.GetString(name);

            //Debug.Assert(value != null);

            //if (formatterNames != null)
            //{
            //    for (var i = 0; i < formatterNames.Length; i++)
            //    {
            //        value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
            //    }
            //}

            //return value;
        }
    }
}