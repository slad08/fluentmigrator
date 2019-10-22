﻿// ***********************************************************************
// Assembly         : FluentMigrator.Runner.Core
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="PassThroughMigrationRunnerConventionsAccessor.cs" company="FluentMigrator Project">
//     Sean Chambers and the FluentMigrator project 2008-2018
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License
// Copyright (c) 2018, FluentMigrator Project
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

using FluentMigrator.Runner.Infrastructure;

using JetBrains.Annotations;

namespace FluentMigrator.Runner.Initialization
{
    /// <summary>
    /// Implementation of <see cref="IMigrationRunnerConventionsAccessor" /> that just passes through the given <see cref="IMigrationRunnerConventions" />
    /// </summary>
    public class PassThroughMigrationRunnerConventionsAccessor : IMigrationRunnerConventionsAccessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PassThroughMigrationRunnerConventionsAccessor" /> class.
        /// </summary>
        /// <param name="conventions">The conventions to return</param>
        public PassThroughMigrationRunnerConventionsAccessor([CanBeNull] IMigrationRunnerConventions conventions = null)
        {
            MigrationRunnerConventions = conventions ?? DefaultMigrationRunnerConventions.Instance;
        }

        /// <inheritdoc />
        public IMigrationRunnerConventions MigrationRunnerConventions { get; }
    }
}
