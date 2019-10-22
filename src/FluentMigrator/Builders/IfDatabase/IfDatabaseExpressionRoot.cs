// ***********************************************************************
// Assembly         : FluentMigrator
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="IfDatabaseExpressionRoot.cs" company="FluentMigrator Project">
//     Sean Chambers and the FluentMigrator project 2008-2018
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License
//
// Copyright (c) 2007-2018, Sean Chambers <schambers80@gmail.com>
// Copyright (c) 2011, Grant Archibald
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

using FluentMigrator.Builders.Alter;
using FluentMigrator.Builders.Create;
using FluentMigrator.Builders.Delete;
using FluentMigrator.Builders.Execute;
using FluentMigrator.Builders.Insert;
using FluentMigrator.Builders.Rename;
using FluentMigrator.Builders.Schema;
using FluentMigrator.Builders.Update;
using FluentMigrator.Infrastructure;

namespace FluentMigrator.Builders.IfDatabase
{
    /// <summary>
    /// Allows for conditional inclusion of expresions based on the migration context
    /// </summary>
    public class IfDatabaseExpressionRoot : IIfDatabaseExpressionRoot
    {
        /// <summary>
        /// The context to add expressions into
        /// </summary>
        private readonly IMigrationContext _context;

        /// <summary>
        /// Initializes a new instance of a the <see cref="IfDatabaseExpressionRoot" /> class that will only add expressions to the provided <paramref name="context" /> if <paramref name="databaseType" /> matches the migration processor
        /// </summary>
        /// <param name="context">The context to add expressions to if the database type applies</param>
        /// <param name="databaseType">The database type that the expressions relate to</param>
        /// <exception cref="ArgumentNullException">databaseType</exception>
        /// <remarks>If the database type does not apply then a <seealso cref="NullIfDatabaseProcessor" /> will be used as a container to void any fluent expressions that would have been executed</remarks>
        public IfDatabaseExpressionRoot(IMigrationContext context, params string[] databaseType)
        {
            if (databaseType == null) throw new ArgumentNullException(nameof(databaseType));

            _context = DatabaseTypeApplies(context, databaseType)
                ? context
                : CreateEmptyMigrationContext(context);
        }

        /// <summary>
        /// Initializes a new instance of a the <see cref="IfDatabaseExpressionRoot" /> class that will only add expressions to the provided <paramref name="context" /> if <paramref name="databaseTypePredicate" /> is true for the migration processor
        /// </summary>
        /// <param name="context">The context to add expressions to if the database type applies</param>
        /// <param name="databaseTypePredicate">The predicate that must be true for the expression to run</param>
        /// <exception cref="ArgumentNullException">databaseTypePredicate</exception>
        /// <remarks>If the database type does not apply then a <seealso cref="NullIfDatabaseProcessor" /> will be used as a container to void any fluent expressions that would have been executed</remarks>
        public IfDatabaseExpressionRoot(IMigrationContext context, Predicate<string> databaseTypePredicate)
        {
            if (databaseTypePredicate == null) throw new ArgumentNullException(nameof(databaseTypePredicate));

            _context = DatabaseTypeApplies(context, databaseTypePredicate)
                ? context
                : CreateEmptyMigrationContext(context);
        }

        /// <summary>
        /// Alter the schema of an existing object
        /// </summary>
        /// <value>The alter.</value>
        public IAlterExpressionRoot Alter
        {
            get { return new AlterExpressionRoot(_context); }
        }

        /// <summary>
        /// Create a new database object
        /// </summary>
        /// <value>The create.</value>
        public ICreateExpressionRoot Create
        {
            get { return new CreateExpressionRoot(_context); }
        }

        /// <summary>
        /// Delete a database object, table, or row
        /// </summary>
        /// <value>The delete.</value>
        public IDeleteExpressionRoot Delete
        {
            get { return new DeleteExpressionRoot(_context); }
        }

        /// <summary>
        /// Rename tables / columns
        /// </summary>
        /// <value>The rename.</value>
        public IRenameExpressionRoot Rename
        {
            get { return new RenameExpressionRoot(_context); }
        }

        /// <summary>
        /// Insert data into a table
        /// </summary>
        /// <value>The insert.</value>
        public IInsertExpressionRoot Insert
        {
            get { return new InsertExpressionRoot(_context); }
        }

        /// <summary>
        /// Execute SQL statements
        /// </summary>
        /// <value>The execute.</value>
        public IExecuteExpressionRoot Execute
        {
            get { return new ExecuteExpressionRoot(_context); }
        }

        /// <inheritdoc />
        public ISchemaExpressionRoot Schema
        {
            get { return new SchemaExpressionRoot(_context); }
        }

        /// <summary>
        /// Update an existing row
        /// </summary>
        /// <value>The update.</value>
        public IUpdateExpressionRoot Update
        {
            get { return new UpdateExpressionRoot(_context); }
        }

        /// <inheritdoc />
        public void Delegate(Action delegation)
        {
            if (_context.QuerySchema is NullIfDatabaseProcessor)
            {
                return;
            }

            delegation.Invoke();
        }

        /// <summary>
        /// Checks if the database type matches the name of the context migration processor
        /// </summary>
        /// <param name="context">The context to evaluate</param>
        /// <param name="databaseTypes">The type to be checked</param>
        /// <returns><c>True</c> if the database type applies, <c>False</c> if not</returns>
        private static bool DatabaseTypeApplies(IMigrationContext context, params string[] databaseTypes)
        {
            if (context.QuerySchema is IMigrationProcessor mp)
            {
                var processorDbTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { mp.DatabaseType };
                foreach (var databaseType in mp.DatabaseTypeAliases)
                    processorDbTypes.Add(databaseType);

                return databaseTypes
                    .Any(db => processorDbTypes.Contains(db));
            }

            return false;
        }

        /// <summary>
        /// Checks if the database type matches the name of the context migration processor
        /// </summary>
        /// <param name="context">The context to evaluate</param>
        /// <param name="databaseTypePredicate">The predicate to be evaluated</param>
        /// <returns><c>True</c> if the database type applies, <c>False</c> if not</returns>
        private static bool DatabaseTypeApplies(IMigrationContext context, Predicate<string> databaseTypePredicate)
        {
            if (context.QuerySchema is IMigrationProcessor mp)
            {
                return databaseTypePredicate(mp.DatabaseType);
            }

            return false;
        }

        /// <summary>
        /// Creates the empty migration context.
        /// </summary>
        /// <param name="originalContext">The original context.</param>
        /// <returns>IMigrationContext.</returns>
        private static IMigrationContext CreateEmptyMigrationContext(IMigrationContext originalContext)
        {
            var result = new MigrationContext(
                new NullIfDatabaseProcessor(),
                originalContext.ServiceProvider,
#pragma warning disable 612
                originalContext.ApplicationContext,
#pragma warning restore 612
                string.Empty);
            return result;
        }
    }
}
