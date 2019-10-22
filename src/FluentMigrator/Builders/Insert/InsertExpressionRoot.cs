// ***********************************************************************
// Assembly         : FluentMigrator
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="InsertExpressionRoot.cs" company="FluentMigrator Project">
//     Sean Chambers and the FluentMigrator project 2008-2018
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License
//
// Copyright (c) 2007-2018, Sean Chambers <schambers80@gmail.com>
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

using FluentMigrator.Expressions;
using FluentMigrator.Infrastructure;

namespace FluentMigrator.Builders.Insert
{
    /// <summary>
    /// The implementation of the <see cref="IInsertExpressionRoot" /> interface.
    /// </summary>
    public class InsertExpressionRoot : IInsertExpressionRoot
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IMigrationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="InsertExpressionRoot" /> class.
        /// </summary>
        /// <param name="context">The migration context</param>
        public InsertExpressionRoot(IMigrationContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public IInsertDataOrInSchemaSyntax IntoTable(string tableName)
        {
            var expression = new InsertDataExpression { TableName = tableName };
            _context.Expressions.Add(expression);
            return new InsertDataExpressionBuilder(expression);
        }
    }
}
