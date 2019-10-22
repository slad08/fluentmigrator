// ***********************************************************************
// Assembly         : FluentMigrator.Runner.Db2
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="Db2ISeriesQuoter.cs" company="FluentMigrator Project">
//     Sean Chambers and the FluentMigrator project 2008-2018
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License
// Copyright (c) 2018, Fluent Migrator Project
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

namespace FluentMigrator.Runner.Generators.DB2.iSeries
{
    /// <summary>
    /// Class Db2ISeriesQuoter.
    /// Implements the <see cref="FluentMigrator.Runner.Generators.DB2.Db2Quoter" />
    /// </summary>
    /// <seealso cref="FluentMigrator.Runner.Generators.DB2.Db2Quoter" />
    public class Db2ISeriesQuoter : Db2Quoter
    {
        /// <summary>
        /// Quotes the name of the constraint.
        /// </summary>
        /// <param name="constraintName">Name of the constraint.</param>
        /// <param name="schemaName">Name of the schema.</param>
        /// <returns>System.String.</returns>
        /// <inheritdoc />
        public override string QuoteConstraintName(string constraintName, string schemaName = null)
        {
            return CreateSchemaPrefixedQuotedIdentifier(
                QuoteSchemaName(schemaName),
                IsQuoted(constraintName) ? constraintName : Quote(constraintName));
        }

        /// <summary>
        /// Quotes the name of the index.
        /// </summary>
        /// <param name="indexName">Name of the index.</param>
        /// <param name="schemaName">Name of the schema.</param>
        /// <returns>System.String.</returns>
        public override string QuoteIndexName(string indexName, string schemaName)
        {
            return CreateSchemaPrefixedQuotedIdentifier(
                QuoteSchemaName(schemaName),
                IsQuoted(indexName) ? indexName : Quote(indexName));
        }
    }
}
