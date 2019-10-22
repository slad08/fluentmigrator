// ***********************************************************************
// Assembly         : FluentMigrator.Tests
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="HanaTableTests.cs" company="FluentMigrator Project">
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
    /// Defines test class HanaTableTests.
    /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.BaseTableTests" />
    /// </summary>
    /// <seealso cref="FluentMigrator.Tests.Unit.Generators.BaseTableTests" />
    [TestFixture]
    [Category("Hana")]
    public class HanaTableTests : BaseTableTests
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
        /// Defines the test method CanCreateTableWithCustomColumnTypeWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithCustomColumnTypeWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableExpression();
            expression.Columns[0].IsPrimaryKey = true;
            expression.Columns[1].Type = null;
            expression.Columns[1].CustomType = "json";
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255), \"TestColumn2\" json, PRIMARY KEY (\"TestColumn1\"));");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithCustomColumnTypeWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithCustomColumnTypeWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableExpression();
            expression.Columns[0].IsPrimaryKey = true;
            expression.Columns[1].Type = null;
            expression.Columns[1].CustomType = "json";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255), \"TestColumn2\" json, PRIMARY KEY (\"TestColumn1\"));");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255), \"TestColumn2\" INTEGER);");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255), \"TestColumn2\" INTEGER);");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithDefaultValueExplicitlySetToNullWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithDefaultValueExplicitlySetToNullWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithDefaultValue();
            expression.Columns[0].DefaultValue = null;
            expression.Columns[0].TableName = expression.TableName;
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255) DEFAULT NULL, \"TestColumn2\" INTEGER DEFAULT 0);");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithDefaultValueExplicitlySetToNullWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithDefaultValueExplicitlySetToNullWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithDefaultValue();
            expression.Columns[0].DefaultValue = null;
            expression.Columns[0].TableName = expression.TableName;

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255) DEFAULT NULL, \"TestColumn2\" INTEGER DEFAULT 0);");

        }

        /// <summary>
        /// Defines the test method CanCreateTableWithDefaultValueWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithDefaultValueWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithDefaultValue();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255) DEFAULT N'Default', \"TestColumn2\" INTEGER DEFAULT 0);");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithIdentityWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithIdentityWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithAutoIncrementExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" INTEGER GENERATED ALWAYS AS IDENTITY, \"TestColumn2\" INTEGER);");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithIdentityWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithIdentityWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithAutoIncrementExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" INTEGER GENERATED ALWAYS AS IDENTITY, \"TestColumn2\" INTEGER);");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithDefaultValueWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithDefaultValueWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithDefaultValue();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255) DEFAULT N'Default', \"TestColumn2\" INTEGER DEFAULT 0);");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithMultiColumnPrimaryKeyWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithMultiColumnPrimaryKeyWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithMultiColumnPrimaryKeyExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255), \"TestColumn2\" INTEGER, PRIMARY KEY (\"TestColumn1\", \"TestColumn2\"));");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithMultiColumnPrimaryKeyWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithMultiColumnPrimaryKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithMultiColumnPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255), \"TestColumn2\" INTEGER," +
                            " PRIMARY KEY (\"TestColumn1\", \"TestColumn2\"));");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNamedMultiColumnPrimaryKeyWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithNamedMultiColumnPrimaryKeyWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNamedMultiColumnPrimaryKeyExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255), \"TestColumn2\" INTEGER, PRIMARY KEY (\"TestColumn1\", \"TestColumn2\"));");
            // HANA doesn't support a contraint name for a composite primary key in a CREATE statement
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNamedMultiColumnPrimaryKeyWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithNamedMultiColumnPrimaryKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNamedMultiColumnPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255), \"TestColumn2\" INTEGER," +
                            " PRIMARY KEY (\"TestColumn1\", \"TestColumn2\"));");
            // HANA doesn't support a contraint name for a composite primary key in a CREATE statement
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNamedPrimaryKeyWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithNamedPrimaryKeyWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNamedPrimaryKeyExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255), \"TestColumn2\" INTEGER, PRIMARY KEY (\"TestColumn1\"));");
            // HANA doesn't support a contraint name for a primary key
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNamedPrimaryKeyWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithNamedPrimaryKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNamedPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255), \"TestColumn2\" INTEGER, PRIMARY KEY (\"TestColumn1\"));");
            // HANA doesn't support a contraint name for a primary key
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNullableFieldWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithNullableFieldWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNullableColumn();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255) NULL, \"TestColumn2\" INTEGER);");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNullableFieldWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithNullableFieldWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNullableColumn();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255) NULL, \"TestColumn2\" INTEGER);");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithPrimaryKeyWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithPrimaryKeyWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithPrimaryKeyExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255), \"TestColumn2\" INTEGER, PRIMARY KEY (\"TestColumn1\"));");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithPrimaryKeyWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithPrimaryKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE COLUMN TABLE \"TestTable1\" (\"TestColumn1\" NVARCHAR(255), \"TestColumn2\" INTEGER, PRIMARY KEY (\"TestColumn1\"));");
        }

        /// <summary>
        /// Defines the test method CanDropTableWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanDropTableWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteTableExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("DROP TABLE \"TestTable1\";");
        }

        /// <summary>
        /// Defines the test method CanDropTableWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanDropTableWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteTableExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("DROP TABLE \"TestTable1\";");
        }

        /// <summary>
        /// Defines the test method CanRenameTableWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanRenameTableWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetRenameTableExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("RENAME TABLE \"TestTable1\" TO \"TestTable2\";");
        }

        /// <summary>
        /// Defines the test method CanRenameTableWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanRenameTableWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetRenameTableExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("RENAME TABLE \"TestTable1\" TO \"TestTable2\";");
        }
    }
}
