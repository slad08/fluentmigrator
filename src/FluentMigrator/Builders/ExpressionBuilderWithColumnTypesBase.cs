// ***********************************************************************
// Assembly         : FluentMigrator
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="ExpressionBuilderWithColumnTypesBase.cs" company="FluentMigrator Project">
//     Sean Chambers and the FluentMigrator project 2008-2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data;
using FluentMigrator.Expressions;
using FluentMigrator.Infrastructure;
using FluentMigrator.Model;

namespace FluentMigrator.Builders
{
    /// <summary>
    /// A base class for expressions that affect column types
    /// </summary>
    /// <typeparam name="TExpression">The migration expression</typeparam>
    /// <typeparam name="TNext">The next type</typeparam>
    /// <remarks>This class will be removed as soon as C# supports default interface methods.</remarks>
    public abstract class ExpressionBuilderWithColumnTypesBase<TExpression, TNext> : ExpressionBuilderBase<TExpression>, IColumnTypeSyntax<TNext>
        where TExpression : class, IMigrationExpression
        where TNext : IFluentSyntax
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionBuilderWithColumnTypesBase{TExpression,TNext}" /> class.
        /// </summary>
        /// <param name="expression">The underlying expression</param>
        protected ExpressionBuilderWithColumnTypesBase(TExpression expression)
            : base(expression)
        {
        }

        /// <summary>
        /// Returns the column definition to set the type for
        /// </summary>
        /// <returns>The column definition to set the type for</returns>
        public abstract ColumnDefinition GetColumnForType();

        /// <summary>
        /// Gets the current column definition
        /// </summary>
        /// <value>The column.</value>
        private ColumnDefinition Column => GetColumnForType();

        /// <inheritdoc />
        public TNext AsAnsiString()
        {
            SetColumnAsString(DbType.AnsiString);
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsAnsiString(string collationName)
        {
            SetColumnAsString(dbType: DbType.AnsiString, collationName: collationName);
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsAnsiString(int size)
        {
            SetColumnAsString(DbType.AnsiString, size);
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsAnsiString(int size, string collationName)
        {
            SetColumnAsString(DbType.AnsiString, size, collationName);
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsBinary()
        {
            Column.Type = DbType.Binary;
            Column.Size = null;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsBinary(int size)
        {
            Column.Type = DbType.Binary;
            Column.Size = size;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsBoolean()
        {
            Column.Type = DbType.Boolean;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsByte()
        {
            Column.Type = DbType.Byte;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsCurrency()
        {
            Column.Type = DbType.Currency;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsDate()
        {
            Column.Type = DbType.Date;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsDateTime()
        {
            Column.Type = DbType.DateTime;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsDateTime2()
        {
            Column.Type = DbType.DateTime2;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsDateTimeOffset()
        {
            Column.Type = DbType.DateTimeOffset;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsDateTimeOffset(int precision)
        {
            Column.Type = DbType.DateTimeOffset;
            Column.Size = precision;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsDecimal()
        {
            Column.Type = DbType.Decimal;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsDecimal(int size, int precision)
        {
            Column.Type = DbType.Decimal;
            Column.Size = size;
            Column.Precision = precision;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsDouble()
        {
            Column.Type = DbType.Double;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsFixedLengthString(int size)
        {
            SetColumnAsString(DbType.StringFixedLength, size);
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsFixedLengthString(int size, string collationName)
        {
            SetColumnAsString(DbType.StringFixedLength, size, collationName);
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsFixedLengthAnsiString(int size)
        {
            SetColumnAsString(DbType.AnsiStringFixedLength, size);
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsFixedLengthAnsiString(int size, string collationName)
        {
            SetColumnAsString(DbType.AnsiStringFixedLength, size, collationName);
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsFloat()
        {
            Column.Type = DbType.Single;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsGuid()
        {
            Column.Type = DbType.Guid;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsInt16()
        {
            Column.Type = DbType.Int16;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsInt32()
        {
            Column.Type = DbType.Int32;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsInt64()
        {
            Column.Type = DbType.Int64;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsString()
        {
            SetColumnAsString(DbType.String);
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsString(string collationName)
        {
            SetColumnAsString(dbType: DbType.String, collationName: collationName);
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsString(int size)
        {
            SetColumnAsString(DbType.String, size);
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsString(int size, string collationName)
        {
            SetColumnAsString(DbType.String, size, collationName);
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsTime()
        {
            Column.Type = DbType.Time;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsXml()
        {
            Column.Type = DbType.Xml;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsXml(int size)
        {
            Column.Type = DbType.Xml;
            Column.Size = size;
            return (TNext)(object)this;
        }

        /// <inheritdoc />
        public TNext AsCustom(string customType)
        {
            Column.Type = null;
            Column.CustomType = customType;
            return (TNext)(object)this;
        }

        /// <summary>
        /// Sets the column as string.
        /// </summary>
        /// <param name="dbType">Type of the database.</param>
        /// <param name="size">The size.</param>
        /// <param name="collationName">Name of the collation.</param>
        private void SetColumnAsString(DbType dbType, int? size = null, string collationName = "")
        {
            Column.Type = dbType;
            Column.Size = size;

            if (!string.IsNullOrEmpty(collationName))
            {
                Column.CollationName = collationName;
            }
        }
    }
}
