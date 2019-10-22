// ***********************************************************************
// Assembly         : FluentMigrator.DotNet.Cli
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="Rollback.cs" company="FluentMigrator Project">
//     Sean Chambers and the FluentMigrator project 2008-2018
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License
// Copyright (c) 2007-2018, Sean Chambers and the FluentMigrator Project
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

using McMaster.Extensions.CommandLineUtils;

// ReSharper disable UnusedMember.Local
// ReSharper disable UnassignedGetOnlyAutoProperty

namespace FluentMigrator.DotNet.Cli.Commands
{
    /// <summary>
    /// Class Rollback.
    /// Implements the <see cref="FluentMigrator.DotNet.Cli.Commands.ConnectionCommand" />
    /// </summary>
    /// <seealso cref="FluentMigrator.DotNet.Cli.Commands.ConnectionCommand" />
    [HelpOption]
    [Command("rollback", Description = "Rollback last migration")]
    [Subcommand(typeof(RollbackBy))]
    [Subcommand(typeof(RollbackTo))]
    [Subcommand(typeof(RollbackAll))]
    public class Rollback : ConnectionCommand
    {
        /// <summary>
        /// Gets the transaction mode.
        /// </summary>
        /// <value>The transaction mode.</value>
        [Option("-m|--transaction-mode <MODE>", Description = "Overrides the transaction behavior of migrations, so that all migrations to be executed will run in one transaction.")]
        public TransactionMode TransactionMode { get; }

        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="console">The console.</param>
        /// <returns>System.Int32.</returns>
        private int OnExecute(IConsole console)
        {
            var options = MigratorOptions.CreateRollbackBy(this, null);
            return ExecuteMigrations(options, console);
        }
    }
}
