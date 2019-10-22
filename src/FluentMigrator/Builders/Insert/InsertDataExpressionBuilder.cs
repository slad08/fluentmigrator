// ***********************************************************************
// Assembly         : FluentMigrator
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="InsertDataExpressionBuilder.cs" company="FluentMigrator Project">
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

using System.Collections.Generic;
using System.ComponentModel;

using FluentMigrator.Expressions;
using FluentMigrator.Infrastructure;
using FluentMigrator.Model;

namespace FluentMigrator.Builders.Insert
{
    /// <summary>
    /// An expression builder for a <see cref="InsertDataExpression" />
    /// </summary>
    public class InsertDataExpressionBuilder : IInsertDataOrInSchemaSyntax, ISupportAdditionalFeatures
    {
        /// <summary>
        /// The expression
        /// </summary>
        private readonly InsertDataExpression _expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="InsertDataExpressionBuilder" /> class.
        /// </summary>
        /// <param name="expression">The underlying expression</param>
        public InsertDataExpressionBuilder(InsertDataExpression expression)
        {
            _expression = expression;
        }

        /// <inheritdoc />
        public IDictionary<string, object> AdditionalFeatures => _expression.AdditionalFeatures;

        /// <inheritdoc />
        public IInsertDataSyntax Row(object dataAsAnonymousType)
        {
            IDictionary<string, object> data = ExtractData(dataAsAnonymousType);

            return Row(data);
        }

        /// <inheritdoc />
        public IInsertDataSyntax Row(IDictionary<string, object> data)
        {
            var dataDefinition = new InsertionDataDefinition();

            dataDefinition.AddRange(data);

            _expression.Rows.Add(dataDefinition);

            return this;
        }

        /// <inheritdoc />
        public IInsertDataSyntax InSchema(string schemaName)
        {
            _expression.SchemaName = schemaName;
            return this;
        }

        /// <summary>
        /// Extracts the data.
        /// </summary>
        /// <param name="dataAsAnonymousType">Type of the data as anonymous.</param>
        /// <returns>IDictionary&lt;System.String, System.Object&gt;.</returns>
        private static IDictionary<string, object> ExtractData(object dataAsAnonymousType)
        {
            var data = new Dictionary<string, object>();

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataAsAnonymousType);

            foreach (PropertyDescriptor property in properties)
            {
                data.Add(property.Name, property.GetValue(dataAsAnonymousType));
            }

            return data;
        }
    }
}
