// ***********************************************************************
// Assembly         : FluentMigrator.Abstractions
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="IMigrationProcessorOptions.cs" company="FluentMigrator Project">
//     Sean Chambers and the FluentMigrator project 2008-2018
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License
//
// Copyright (c) 2018, Fluent Migrator Project
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

namespace FluentMigrator
{
    /// <summary>
    /// Options for the <see cref="IMigrationProcessor" />
    /// </summary>
    [Obsolete]
    public interface IMigrationProcessorOptions
    {
        /// <summary>
        /// Gets a value indicating whether a preview-only mode is active
        /// </summary>
        /// <value><c>true</c> if [preview only]; otherwise, <c>false</c>.</value>
        bool PreviewOnly { get; }

        /// <summary>
        /// Gets the global timeout
        /// </summary>
        /// <value>The timeout.</value>
        int? Timeout { get; }

        /// <summary>
        /// Gets the provider switches
        /// </summary>
        /// <value>The provider switches.</value>
        string ProviderSwitches { get; }
    }
}
