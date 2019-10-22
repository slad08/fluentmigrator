// ***********************************************************************
// Assembly         : FluentMigrator.Runner.SqlServer
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="SqlServer2012Processor.cs" company="FluentMigrator Project">
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

using FluentMigrator.Runner.Generators.SqlServer;
using FluentMigrator.Runner.Initialization;

using JetBrains.Annotations;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FluentMigrator.Runner.Processors.SqlServer
{
    /// <summary>
    /// Class SqlServer2012Processor.
    /// Implements the <see cref="FluentMigrator.Runner.Processors.SqlServer.SqlServerProcessor" />
    /// </summary>
    /// <seealso cref="FluentMigrator.Runner.Processors.SqlServer.SqlServerProcessor" />
    public class SqlServer2012Processor : SqlServerProcessor
    {
        /// <inheritdoc />
        public SqlServer2012Processor(
            [NotNull] ILogger<SqlServer2012Processor> logger,
            [NotNull] SqlServer2008Quoter quoter,
            [NotNull] SqlServer2012Generator generator,
            [NotNull] IOptionsSnapshot<ProcessorOptions> options,
            [NotNull] IConnectionStringAccessor connectionStringAccessor,
            [NotNull] IServiceProvider serviceProvider)
            : base(new[] { "SqlServer2012", "SqlServer" }, generator, quoter, logger, options, connectionStringAccessor, serviceProvider)
        {
        }
    }
}
