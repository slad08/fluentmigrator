// ***********************************************************************
// Assembly         : FluentMigrator.Tests
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="SQLiteTableTests.cs" company="FluentMigrator Project">
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

using FluentMigrator.Builders.Create.Table;
using FluentMigrator.Expressions;
using FluentMigrator.Infrastructure;
using FluentMigrator.Runner.Generators.SQLite;

using Microsoft.Extensions.DependencyInjection;

using Moq;

using NUnit.Framework;

using Shouldly;

namespace FluentMigrator.Tests.Unit.Generators.SQLite
{
    /// <summary>
    /// Defines test class SQLiteTableTests.
    /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.BaseTableTests" />
    /// </summary>
    /// <seealso cref="FluentMigrator.Tests.Unit.Generators.BaseTableTests" />
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class SQLiteTableTests : BaseTableTests
    {
        /// <summary>
        /// The generator
        /// </summary>
        protected SQLiteGenerator Generator;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Generator = new SQLiteGenerator();
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
            expression.Columns[1].CustomType = "timestamp";
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" timestamp NOT NULL, PRIMARY KEY (\"TestColumn1\"))");
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
            expression.Columns[1].CustomType = "timestamp";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" timestamp NOT NULL, PRIMARY KEY (\"TestColumn1\"))");
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
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL)");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL)");
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
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL DEFAULT NULL, \"TestColumn2\" INTEGER NOT NULL DEFAULT 0)");
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
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL DEFAULT NULL, \"TestColumn2\" INTEGER NOT NULL DEFAULT 0)");
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
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL DEFAULT 'Default', \"TestColumn2\" INTEGER NOT NULL DEFAULT 0)");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithDefaultValueWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithDefaultValueWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithDefaultValue();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL DEFAULT 'Default', \"TestColumn2\" INTEGER NOT NULL DEFAULT 0)");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithIdentityWithCustomSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithIdentityWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithAutoIncrementExpression();
            //Have to force it to primary key for SQLite
            expression.Columns[0].IsPrimaryKey = true;
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, \"TestColumn2\" INTEGER NOT NULL)");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithIdentityWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithIdentityWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithAutoIncrementExpression();
            //Have to force it to primary key for SQLite
            expression.Columns[0].IsPrimaryKey = true;

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, \"TestColumn2\" INTEGER NOT NULL)");
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
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL, PRIMARY KEY (\"TestColumn1\", \"TestColumn2\"))");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithMultiColumnPrimaryKeyWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithMultiColumnPrimaryKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithMultiColumnPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL, PRIMARY KEY (\"TestColumn1\", \"TestColumn2\"))");
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
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL, CONSTRAINT \"TestKey\" PRIMARY KEY (\"TestColumn1\", \"TestColumn2\"))");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNamedMultiColumnPrimaryKeyWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithNamedMultiColumnPrimaryKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNamedMultiColumnPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL, CONSTRAINT \"TestKey\" PRIMARY KEY (\"TestColumn1\", \"TestColumn2\"))");
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
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL, CONSTRAINT \"TestKey\" PRIMARY KEY (\"TestColumn1\"))");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNamedPrimaryKeyWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithNamedPrimaryKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNamedPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL, CONSTRAINT \"TestKey\" PRIMARY KEY (\"TestColumn1\"))");
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
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT, \"TestColumn2\" INTEGER NOT NULL)");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNullableFieldWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithNullableFieldWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNullableColumn();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT, \"TestColumn2\" INTEGER NOT NULL)");
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
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL, PRIMARY KEY (\"TestColumn1\"))");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithPrimaryKeyWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithPrimaryKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL, PRIMARY KEY (\"TestColumn1\"))");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithForeignKey.
        /// </summary>
        [Test]
        public void CanCreateTableWithForeignKey()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithForeignKey();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL, CONSTRAINT \"FK_TestT_TestT\" FOREIGN KEY (\"TestColumn1\") REFERENCES \"TestTable2\" (\"TestColumn2\"))");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithMultiColumnForeignKey.
        /// </summary>
        [Test]
        public void CanCreateTableWithMultiColumnForeignKey()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithMultiColumnForeignKey();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL, CONSTRAINT \"FK_TestT_TestT\" FOREIGN KEY (\"TestColumn1\", \"TestColumn3\") REFERENCES \"TestTable2\" (\"TestColumn2\", \"TestColumn4\"))");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNameForeignKey.
        /// </summary>
        [Test]
        public void CanCreateTableWithNameForeignKey()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNameForeignKey();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL, CONSTRAINT \"FK_Test\" FOREIGN KEY (\"TestColumn1\") REFERENCES \"TestTable2\" (\"TestColumn2\"))");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNameMultiColumnForeignKey.
        /// </summary>
        [Test]
        public void CanCreateTableWithNameMultiColumnForeignKey()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNameMultiColumnForeignKey();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"TestTable1\" (\"TestColumn1\" TEXT NOT NULL, \"TestColumn2\" INTEGER NOT NULL, CONSTRAINT \"FK_Test\" FOREIGN KEY (\"TestColumn1\", \"TestColumn3\") REFERENCES \"TestTable2\" (\"TestColumn2\", \"TestColumn4\"))");
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
            result.ShouldBe("DROP TABLE \"TestTable1\"");
        }

        /// <summary>
        /// Defines the test method CanDropTableWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanDropTableWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteTableExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("DROP TABLE \"TestTable1\"");
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
            result.ShouldBe("ALTER TABLE \"TestTable1\" RENAME TO \"TestTable2\"");
        }

        /// <summary>
        /// Defines the test method CanRenameTableWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanRenameTableWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetRenameTableExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" RENAME TO \"TestTable2\"");
        }

        /// <summary>
        /// Defines the test method Issue804.
        /// </summary>
        [Test]
        public void Issue804()
        {
            var serviceProvider = new ServiceCollection().BuildServiceProvider();
            var querySchema = new Mock<IQuerySchema>();
            var context = new MigrationContext(querySchema.Object, serviceProvider, null, null);

            var expression = new CreateTableExpression()
            {
                TableName = "Contact",
            };

            var builder = new CreateTableExpressionBuilder(expression, context);
            builder
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(30).Nullable()
                .WithColumn("FamilyName").AsString(50).NotNullable()
                .WithColumn("Whatever1").AsString()
                .WithColumn("Whatever2").AsString(50).Nullable()
                .WithColumn("Whatever3").AsString();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE \"Contact\" (\"Id\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, \"FirstName\" TEXT, \"FamilyName\" TEXT NOT NULL, \"Whatever1\" TEXT NOT NULL, \"Whatever2\" TEXT, \"Whatever3\" TEXT NOT NULL)");
        }
    }
}
