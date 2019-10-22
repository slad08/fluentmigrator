// ***********************************************************************
// Assembly         : FluentMigrator.Abstractions
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="IndexDefinition.cs" company="FluentMigrator Project">
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using FluentMigrator.Infrastructure;
using FluentMigrator.Infrastructure.Extensions;
using FluentMigrator.Validation;

namespace FluentMigrator.Model
{
    /// <summary>
    /// The index definition
    /// </summary>
    public class IndexDefinition
        : ICloneable,
#pragma warning disable 618
          ICanBeValidated,
#pragma warning restore 618
          ISupportAdditionalFeatures,
          IValidatableObject,
          IValidationChildren
    {
        /// <summary>
        /// The additional features
        /// </summary>
        private readonly IDictionary<string, object> _additionalFeatures = new Dictionary<string, object>();

        /// <summary>
        /// Gets or sets the index name
        /// </summary>
        /// <value>The name.</value>
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.IndexNameCannotBeNullOrEmpty))]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the schema name
        /// </summary>
        /// <value>The name of the schema.</value>
        public virtual string SchemaName { get; set; }

        /// <summary>
        /// Gets or sets the table name
        /// </summary>
        /// <value>The name of the table.</value>
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.TableNameCannotBeNullOrEmpty))]
        public virtual string TableName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whteher the index only allows unique values
        /// </summary>
        /// <value><c>true</c> if this instance is unique; otherwise, <c>false</c>.</value>
        public virtual bool IsUnique { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the index is clustered
        /// </summary>
        /// <value><c>true</c> if this instance is clustered; otherwise, <c>false</c>.</value>
        public bool IsClustered { get; set; }

        /// <summary>
        /// Gets or sets a collection of index column definitions
        /// </summary>
        /// <value>The columns.</value>
        public virtual ICollection<IndexColumnDefinition> Columns { get; set; } = new List<IndexColumnDefinition>();

        /// <inheritdoc />
        public virtual IDictionary<string, object> AdditionalFeatures => _additionalFeatures;

        /// <inheritdoc />
        [Obsolete("Use the System.ComponentModel.DataAnnotations.Validator instead")]
        public virtual void CollectValidationErrors(ICollection<string> errors)
        {
            this.CollectErrors(errors);
        }

        /// <inheritdoc />
        public object Clone()
        {
            var result = new IndexDefinition
            {
                Name = Name,
                SchemaName = SchemaName,
                TableName = TableName,
                IsUnique = IsUnique,
                IsClustered = IsClustered,
                Columns = Columns.CloneAll().ToList(),
            };

            _additionalFeatures.CloneTo(result._additionalFeatures);

            return result;
        }

        /// <inheritdoc />
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Columns.Count == 0)
            {
                yield return new ValidationResult(ErrorMessages.IndexMustHaveOneOrMoreColumns);
            }
        }

        /// <inheritdoc />
        IEnumerable<object> IValidationChildren.Children => Columns;
    }
}
