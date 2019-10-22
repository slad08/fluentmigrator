// ***********************************************************************
// Assembly         : FluentMigrator.Runner
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="FluentMigratorConsoleLoggerProvider.cs" company="FluentMigrator Project">
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

using System;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FluentMigrator.Runner.Logging
{
    /// <summary>
    /// The default FluentMigrator console output
    /// </summary>
    public class FluentMigratorConsoleLoggerProvider : ILoggerProvider
    {
        /// <summary>
        /// The options
        /// </summary>
        private readonly FluentMigratorLoggerOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentMigratorConsoleLoggerProvider" /> class.
        /// </summary>
        /// <param name="options">The logger options</param>
        public FluentMigratorConsoleLoggerProvider(IOptions<FluentMigratorLoggerOptions> options)
        {
            _options = options.Value;
            Console.ResetColor();
        }

        /// <inheritdoc />
        public ILogger CreateLogger(string categoryName)
        {
            return new FluentMigratorConsoleLogger(_options);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            // Nothing to do here...
        }
    }
}
