// ***********************************************************************
// Assembly         : FluentMigrator.Runner.Core
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="IAssemblySource.cs" company="FluentMigrator Project">
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

using System.Collections.Generic;
using System.Reflection;

namespace FluentMigrator.Runner.Initialization
{
    /// <summary>
    /// Interface for an assembly provider
    /// </summary>
    /// <remarks>This will be used to find some user-defined interface implementations of out-of-process runners</remarks>
    public interface IAssemblySource
    {
        /// <summary>
        /// Gets the assemblies
        /// </summary>
        /// <value>The assemblies.</value>
        IReadOnlyCollection<Assembly> Assemblies { get; }
    }
}
