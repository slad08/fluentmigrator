// ***********************************************************************
// Assembly         : FluentMigrator.Tests
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="HanaDataTests.cs" company="FluentMigrator Project">
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

using FluentMigrator.Runner.Generators.Hana;
using NUnit.Framework;

using Shouldly;

namespace FluentMigrator.Tests.Unit.Generators.Hana
{
    /// <summary>
    /// Defines test class HanaDataTests.
    /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.BaseDataTests" />
    /// </summary>
    /// <seealso cref="FluentMigrator.Tests.Unit.Generators.BaseDataTests" />
    [TestFixture]
    [Category("Hana")]
    public class HanaDataTests : BaseDataTests
    {
        /// <summary>
        /// The generator
        /// </summary>
        protected HanaGenerator Generator;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Generator = new HanaGenerator();
        }

        /// <summary>
        /// Defines the test method CanDeleteDataForAllRowsWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanDeleteDataForAllRowsWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteDataAllRowsExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("DELETE FROM \"TestTable1\" WHERE 1 = 1;");
        }

        /// <summary>
        /// Defines the test method CanDeleteDataForAllRowsWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanDeleteDataForAllRowsWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteDataAllRowsExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("DELETE FROM \"TestTable1\" WHERE 1 = 1;");
        }

        /// <summary>
        /// Defines the test method CanDeleteDataForMultipleRowsWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanDeleteDataForMultipleRowsWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteDataMultipleRowsExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("DELETE FROM \"TestTable1\" WHERE \"Name\" = N'Just''in' AND \"Website\" IS NULL; " +
                            "DELETE FROM \"TestTable1\" WHERE \"Website\" = N'github.com';");
        }

        /// <summary>
        /// Defines the test method CanDeleteDataForMultipleRowsWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanDeleteDataForMultipleRowsWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteDataMultipleRowsExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("DELETE FROM \"TestTable1\" WHERE \"Name\" = N'Just''in' AND \"Website\" IS NULL; " +
                            "DELETE FROM \"TestTable1\" WHERE \"Website\" = N'github.com';");
        }

        /// <summary>
        /// Defines the test method CanDeleteDataWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanDeleteDataWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteDataExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("DELETE FROM \"TestTable1\" WHERE \"Name\" = N'Just''in' AND \"Website\" IS NULL;");
        }

        /// <summary>
        /// Defines the test method CanDeleteDataWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanDeleteDataWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteDataExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("DELETE FROM \"TestTable1\" WHERE \"Name\" = N'Just''in' AND \"Website\" IS NULL;");
        }

        /// <summary>
        /// Defines the test method CanDeleteDataWithDbNullCriteria.
        /// </summary>
        [Test]
        public override void CanDeleteDataWithDbNullCriteria()
        {
            var expression = GeneratorTestHelper.GetDeleteDataExpressionWithDbNullValue();
            var result = Generator.Generate(expression);
            result.ShouldBe("DELETE FROM \"TestTable1\" WHERE \"Name\" = N'Just''in' AND \"Website\" IS NULL;");
        }

        /// <summary>
        /// Defines the test method CanInsertDataWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanInsertDataWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetInsertDataExpression();
            expression.SchemaName = "TestSchema";

            var expected = "INSERT INTO \"TestTable1\" (\"Id\", \"Name\", \"Website\") VALUES (1, N'Just''in', N'codethinked.com');";
            expected += " INSERT INTO \"TestTable1\" (\"Id\", \"Name\", \"Website\") VALUES (2, N'Na\\te', N'kohari.org');";

            var result = Generator.Generate(expression);
            result.ShouldBe(expected);
        }

        /// <summary>
        /// Defines the test method CanInsertDataWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanInsertDataWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetInsertDataExpression();

            var expected = "INSERT INTO \"TestTable1\" (\"Id\", \"Name\", \"Website\") VALUES (1, N'Just''in', N'codethinked.com');";
            expected += " INSERT INTO \"TestTable1\" (\"Id\", \"Name\", \"Website\") VALUES (2, N'Na\\te', N'kohari.org');";

            var result = Generator.Generate(expression);
            result.ShouldBe(expected);
        }

        /// <summary>
        /// Defines the test method CanInsertGuidDataWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanInsertGuidDataWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetInsertGUIDExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe(string.Format("INSERT INTO \"TestTable1\" (\"guid\") VALUES ('{0}');", GeneratorTestHelper.TestGuid));
        }

        /// <summary>
        /// Defines the test method CanInsertGuidDataWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanInsertGuidDataWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetInsertGUIDExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe(string.Format("INSERT INTO \"TestTable1\" (\"guid\") VALUES ('{0}');", GeneratorTestHelper.TestGuid));
        }

        /// <summary>
        /// Defines the test method CanUpdateDataForAllDataWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanUpdateDataForAllDataWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetUpdateDataExpressionWithAllRows();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("UPDATE \"TestTable1\" SET \"Name\" = N'Just''in', \"Age\" = 25 WHERE 1 = 1;");
        }

        /// <summary>
        /// Defines the test method CanUpdateDataForAllDataWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanUpdateDataForAllDataWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetUpdateDataExpressionWithAllRows();

            var result = Generator.Generate(expression);
            result.ShouldBe("UPDATE \"TestTable1\" SET \"Name\" = N'Just''in', \"Age\" = 25 WHERE 1 = 1;");
        }

        /// <summary>
        /// Defines the test method CanUpdateDataWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanUpdateDataWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetUpdateDataExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("UPDATE \"TestTable1\" SET \"Name\" = N'Just''in', \"Age\" = 25 WHERE \"Id\" = 9 AND \"Homepage\" IS NULL;");
        }

        /// <summary>
        /// Defines the test method CanUpdateDataWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanUpdateDataWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetUpdateDataExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("UPDATE \"TestTable1\" SET \"Name\" = N'Just''in', \"Age\" = 25 WHERE \"Id\" = 9 AND \"Homepage\" IS NULL;");
        }

        /// <summary>
        /// Defines the test method CanUpdateDataWithDbNullCriteria.
        /// </summary>
        [Test]
        public override void CanUpdateDataWithDbNullCriteria()
        {
            var expression = GeneratorTestHelper.GetUpdateDataExpressionWithDbNullValue();

            var result = Generator.Generate(expression);
            result.ShouldBe("UPDATE \"TestTable1\" SET \"Name\" = N'Just''in', \"Age\" = 25 WHERE \"Id\" = 9 AND \"Homepage\" IS NULL;");
        }
    }
}
