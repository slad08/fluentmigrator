// ***********************************************************************
// Assembly         : FluentMigrator.Tests
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="HanaSequenceTests.cs" company="FluentMigrator Project">
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

using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors.Hana;
using FluentMigrator.Tests.Helpers;

using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using Shouldly;

namespace FluentMigrator.Tests.Integration.Processors.Hana
{
    /// <summary>
    /// Defines test class HanaSequenceTests.
    /// Implements the <see cref="FluentMigrator.Tests.Integration.Processors.BaseSequenceTests" />
    /// </summary>
    /// <seealso cref="FluentMigrator.Tests.Integration.Processors.BaseSequenceTests" />
    [TestFixture]
    [Category("Integration")]
    [Category("Hana")]
    public class HanaSequenceTests : BaseSequenceTests
    {
        /// <summary>
        /// Gets or sets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        private ServiceProvider ServiceProvider { get; set; }
        /// <summary>
        /// Gets or sets the service scope.
        /// </summary>
        /// <value>The service scope.</value>
        private IServiceScope ServiceScope { get; set; }
        /// <summary>
        /// Gets or sets the processor.
        /// </summary>
        /// <value>The processor.</value>
        private HanaProcessor Processor { get; set; }

        /// <summary>
        /// Defines the test method CallingSequenceExistsReturnsFalseIfSequenceDoesNotExist.
        /// </summary>
        [Test]
        public override void CallingSequenceExistsReturnsFalseIfSequenceDoesNotExist()
        {
            Processor.SequenceExists(null, "DoesNotExist").ShouldBeFalse();
        }

        /// <summary>
        /// Defines the test method CallingSequenceExistsReturnsFalseIfSequenceDoesNotExistWithSchema.
        /// </summary>
        [Test]
        public override void CallingSequenceExistsReturnsFalseIfSequenceDoesNotExistWithSchema()
        {
            Processor.SequenceExists("test_schema", "DoesNotExist").ShouldBeFalse();
        }

        /// <summary>
        /// Defines the test method CallingSequenceExistsReturnsTrueIfSequenceExists.
        /// </summary>
        [Test]
        public override void CallingSequenceExistsReturnsTrueIfSequenceExists()
        {
            using (new HanaTestSequence(Processor, null, "test_sequence"))
                Processor.SequenceExists(null, "test_sequence").ShouldBeTrue();
        }

        /// <summary>
        /// Defines the test method CallingSequenceExistsReturnsTrueIfSequenceExistsWithSchema.
        /// </summary>
        [Test]
        public override void CallingSequenceExistsReturnsTrueIfSequenceExistsWithSchema()
        {
            Assert.Ignore("Schemas aren't supported by this SAP Hana runner");
        }

        /// <summary>
        /// Classes the set up.
        /// </summary>
        [OneTimeSetUp]
        public void ClassSetUp()
        {
            if (!IntegrationTestOptions.Hana.IsEnabled)
                Assert.Ignore();

            var serivces = ServiceCollectionExtensions.CreateServices()
                .ConfigureRunner(builder => builder.AddHana())
                .AddScoped<IConnectionStringReader>(
                    _ => new PassThroughConnectionStringReader(IntegrationTestOptions.Hana.ConnectionString));
            ServiceProvider = serivces.BuildServiceProvider();
        }

        /// <summary>
        /// Classes the tear down.
        /// </summary>
        [OneTimeTearDown]
        public void ClassTearDown()
        {
            ServiceProvider?.Dispose();
        }

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            ServiceScope = ServiceProvider.CreateScope();
            Processor = ServiceScope.ServiceProvider.GetRequiredService<HanaProcessor>();
        }

        /// <summary>
        /// Tears down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            ServiceScope?.Dispose();
        }
    }
}
