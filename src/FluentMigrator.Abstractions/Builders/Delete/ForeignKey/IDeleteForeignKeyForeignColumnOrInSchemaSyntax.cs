// ***********************************************************************
// Assembly         : FluentMigrator.Abstractions
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="IDeleteForeignKeyForeignColumnOrInSchemaSyntax.cs" company="FluentMigrator Project">
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

namespace FluentMigrator.Builders.Delete.ForeignKey
{
    /// <summary>
    /// Define the schema or foreign key column to delete
    /// </summary>
    public interface IDeleteForeignKeyForeignColumnOrInSchemaSyntax : IDeleteForeignKeyForeignColumnSyntax
    {
        /// <summary>
        /// Define the schema
        /// </summary>
        /// <param name="foreignSchemaName">The schema of the foreign key</param>
        /// <returns>The next step</returns>
        IDeleteForeignKeyForeignColumnSyntax InSchema(string foreignSchemaName);
    }
}
