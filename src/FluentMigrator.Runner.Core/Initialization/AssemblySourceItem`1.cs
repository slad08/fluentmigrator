// ***********************************************************************
// Assembly         : FluentMigrator.Runner.Core
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="AssemblySourceItem`1.cs" company="FluentMigrator Project">
//     Sean Chambers and the FluentMigrator project 2008-2018
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License
// Copyright (c) 2019, FluentMigrator Project
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using JetBrains.Annotations;

namespace FluentMigrator.Runner.Initialization
{
    /// <summary>
    /// Class AssemblySourceItem.
    /// Implements the <see cref="FluentMigrator.Runner.Initialization.ITypeSourceItem{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="FluentMigrator.Runner.Initialization.ITypeSourceItem{T}" />
    public class AssemblySourceItem<T> : ITypeSourceItem<T>
        where T : class
    {
        /// <summary>
        /// The assemblies
        /// </summary>
        [NotNull, ItemNotNull]
        private readonly Assembly[] _assemblies;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblySourceItem" /> class.
        /// </summary>
        /// <param name="assemblies">The assemblies to load the type from</param>
        public AssemblySourceItem([NotNull, ItemNotNull] params Assembly[] assemblies)
        {
            _assemblies = assemblies;
        }

        /// <inheritdoc />
        public IEnumerable<Type> GetCandidates(Predicate<Type> predicate)
        {
            return _assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(t => !t.IsAbstract && t.IsClass)
                .Where(t => typeof(T).IsAssignableFrom(t))
                .Where(t => predicate(t));
        }
    }
}
