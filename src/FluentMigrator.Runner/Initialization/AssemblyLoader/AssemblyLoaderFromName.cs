// ***********************************************************************
// Assembly         : FluentMigrator.Runner
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="AssemblyLoaderFromName.cs" company="FluentMigrator Project">
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

using System.Reflection;

namespace FluentMigrator.Runner.Initialization.AssemblyLoader
{
    /// <summary>
    /// Class AssemblyLoaderFromName.
    /// Implements the <see cref="FluentMigrator.Runner.Initialization.AssemblyLoader.IAssemblyLoader" />
    /// </summary>
    /// <seealso cref="FluentMigrator.Runner.Initialization.AssemblyLoader.IAssemblyLoader" />
    public class AssemblyLoaderFromName : IAssemblyLoader
    {
        /// <summary>
        /// The name
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyLoaderFromName"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public AssemblyLoaderFromName(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        /// <returns>Assembly.</returns>
        public Assembly Load()
        {
            Assembly assembly = Assembly.Load(_name);
            return assembly;
        }
    }
}
