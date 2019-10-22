// ***********************************************************************
// Assembly         : FluentMigrator.Tests
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="RedshiftDescriptionGeneratorTests.cs" company="FluentMigrator Project">
//     Sean Chambers and the FluentMigrator project 2008-2018
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License
// Copyright (c) 2007-2018, FluentMigrator Project
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

using System.Linq;

using FluentMigrator.Runner.Generators.Redshift;

using NUnit.Framework;

using Shouldly;

namespace FluentMigrator.Tests.Unit.Generators.Redshift
{
    /// <summary>
    /// Defines test class RedshiftDescriptionGeneratorTests.
    /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.BaseDescriptionGeneratorTests" />
    /// </summary>
    /// <seealso cref="FluentMigrator.Tests.Unit.Generators.BaseDescriptionGeneratorTests" />
    [TestFixture]
    public class RedshiftDescriptionGeneratorTests : BaseDescriptionGeneratorTests
    {
        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            DescriptionGenerator = new RedshiftDescriptionGenerator();
        }

        /// <summary>
        /// Defines the test method GenerateDescriptionStatementsForCreateTableReturnTableDescriptionStatement.
        /// </summary>
        [Test]
        public override void GenerateDescriptionStatementsForCreateTableReturnTableDescriptionStatement()
        {
            var createTableExpression = GeneratorTestHelper.GetCreateTableWithTableDescription();
            var statements = DescriptionGenerator.GenerateDescriptionStatements(createTableExpression);

            var result = statements.First();
            result.ShouldBe("COMMENT ON TABLE \"public\".\"TestTable1\" IS 'TestDescription';");
        }

        /// <summary>
        /// Defines the test method GenerateDescriptionStatementsForCreateTableReturnTableDescriptionAndColumnDescriptionsStatements.
        /// </summary>
        [Test]
        public override void
            GenerateDescriptionStatementsForCreateTableReturnTableDescriptionAndColumnDescriptionsStatements()
        {
            var createTableExpression = GeneratorTestHelper.GetCreateTableWithTableDescriptionAndColumnDescriptions();
            var statements = DescriptionGenerator.GenerateDescriptionStatements(createTableExpression).ToArray();

            var result = string.Join(string.Empty, statements);
            result.ShouldBe(
                "COMMENT ON TABLE \"public\".\"TestTable1\" IS 'TestDescription';COMMENT ON COLUMN \"public\".\"TestTable1\".\"TestColumn1\" IS 'TestColumn1Description';COMMENT ON COLUMN \"public\".\"TestTable1\".\"TestColumn2\" IS 'TestColumn2Description';");
        }

        /// <summary>
        /// Defines the test method GenerateDescriptionStatementForAlterTableReturnTableDescriptionStatement.
        /// </summary>
        [Test]
        public override void GenerateDescriptionStatementForAlterTableReturnTableDescriptionStatement()
        {
            var alterTableExpression = GeneratorTestHelper.GetAlterTableWithDescriptionExpression();
            var statement = DescriptionGenerator.GenerateDescriptionStatement(alterTableExpression);

            statement.ShouldBe("COMMENT ON TABLE \"public\".\"TestTable1\" IS 'TestDescription';");
        }

        /// <summary>
        /// Defines the test method GenerateDescriptionStatementForCreateColumnReturnColumnDescriptionStatement.
        /// </summary>
        [Test]
        public override void GenerateDescriptionStatementForCreateColumnReturnColumnDescriptionStatement()
        {
            var createColumnExpression = GeneratorTestHelper.GetCreateColumnExpressionWithDescription();
            var statement = DescriptionGenerator.GenerateDescriptionStatement(createColumnExpression);

            statement.ShouldBe("COMMENT ON COLUMN \"public\".\"TestTable1\".\"TestColumn1\" IS 'TestColumn1Description';");
        }

        /// <summary>
        /// Defines the test method GenerateDescriptionStatementForAlterColumnReturnColumnDescriptionStatement.
        /// </summary>
        [Test]
        public override void GenerateDescriptionStatementForAlterColumnReturnColumnDescriptionStatement()
        {
            var alterColumnExpression = GeneratorTestHelper.GetAlterColumnExpressionWithDescription();
            var statement = DescriptionGenerator.GenerateDescriptionStatement(alterColumnExpression);

            statement.ShouldBe("COMMENT ON COLUMN \"public\".\"TestTable1\".\"TestColumn1\" IS 'TestColumn1Description';");
        }
    }
}
