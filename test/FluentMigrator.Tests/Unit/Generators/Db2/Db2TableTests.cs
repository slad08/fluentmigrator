// ***********************************************************************
// Assembly         : FluentMigrator.Tests
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="Db2TableTests.cs" company="FluentMigrator Project">
//     Sean Chambers and the FluentMigrator project 2008-2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using FluentMigrator.Runner.Generators.DB2;
using FluentMigrator.Runner.Generators.DB2.iSeries;

using NUnit.Framework;

using Shouldly;

namespace FluentMigrator.Tests.Unit.Generators.Db2
{
    /// <summary>
    /// Defines test class Db2TableTests.
    /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.BaseTableTests" />
    /// </summary>
    /// <seealso cref="FluentMigrator.Tests.Unit.Generators.BaseTableTests" />
    [TestFixture]
    public class Db2TableTests : BaseTableTests
    {
        /// <summary>
        /// The generator
        /// </summary>
        protected Db2Generator Generator;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Generator = new Db2Generator(new Db2ISeriesQuoter());
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
            result.ShouldBe("CREATE TABLE TestSchema.TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL, TestColumn2 json NOT NULL, PRIMARY KEY (TestColumn1))");
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
            result.ShouldBe("CREATE TABLE TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL, TestColumn2 json NOT NULL, PRIMARY KEY (TestColumn1))");
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
            result.ShouldBe("CREATE TABLE TestSchema.TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL, TestColumn2 INTEGER NOT NULL)");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL, TestColumn2 INTEGER NOT NULL)");
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
            result.ShouldBe("CREATE TABLE TestSchema.TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL DEFAULT NULL, TestColumn2 INTEGER NOT NULL DEFAULT 0)");
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
            result.ShouldBe("CREATE TABLE TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL DEFAULT NULL, TestColumn2 INTEGER NOT NULL DEFAULT 0)");

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
            result.ShouldBe("CREATE TABLE TestSchema.TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL DEFAULT 'Default', TestColumn2 INTEGER NOT NULL DEFAULT 0)");
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
            result.ShouldBe("CREATE TABLE TestSchema.TestTable1 (TestColumn1 INTEGER NOT NULL AS IDENTITY, TestColumn2 INTEGER NOT NULL)");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithIdentityWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithIdentityWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithAutoIncrementExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE TestTable1 (TestColumn1 INTEGER NOT NULL AS IDENTITY, TestColumn2 INTEGER NOT NULL)");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithDefaultValueWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithDefaultValueWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithDefaultValue();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL DEFAULT 'Default', TestColumn2 INTEGER NOT NULL DEFAULT 0)");
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
            result.ShouldBe("CREATE TABLE TestSchema.TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL, TestColumn2 INTEGER NOT NULL, PRIMARY KEY (TestColumn1, TestColumn2))");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithMultiColumnPrimaryKeyWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithMultiColumnPrimaryKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithMultiColumnPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL, TestColumn2 INTEGER NOT NULL, PRIMARY KEY (TestColumn1, TestColumn2))");
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
            result.ShouldBe("CREATE TABLE TestSchema.TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL, TestColumn2 INTEGER NOT NULL, CONSTRAINT TestKey PRIMARY KEY (TestColumn1, TestColumn2))");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNamedMultiColumnPrimaryKeyWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithNamedMultiColumnPrimaryKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNamedMultiColumnPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL, TestColumn2 INTEGER NOT NULL, CONSTRAINT TestKey PRIMARY KEY (TestColumn1, TestColumn2))");
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
            result.ShouldBe("CREATE TABLE TestSchema.TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL, TestColumn2 INTEGER NOT NULL, CONSTRAINT TestKey PRIMARY KEY (TestColumn1))");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNamedPrimaryKeyWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithNamedPrimaryKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNamedPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL, TestColumn2 INTEGER NOT NULL, CONSTRAINT TestKey PRIMARY KEY (TestColumn1))");
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
            result.ShouldBe("CREATE TABLE TestSchema.TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200, TestColumn2 INTEGER NOT NULL)");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithNullableFieldWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithNullableFieldWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithNullableColumn();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200, TestColumn2 INTEGER NOT NULL)");
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
            result.ShouldBe("CREATE TABLE TestSchema.TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL, TestColumn2 INTEGER NOT NULL, PRIMARY KEY (TestColumn1))");
        }

        /// <summary>
        /// Defines the test method CanCreateTableWithPrimaryKeyWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanCreateTableWithPrimaryKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateTableWithPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("CREATE TABLE TestTable1 (TestColumn1 DBCLOB(1048576) CCSID 1200 NOT NULL, TestColumn2 INTEGER NOT NULL, PRIMARY KEY (TestColumn1))");
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
            result.ShouldBe("DROP TABLE TestSchema.TestTable1");
        }

        /// <summary>
        /// Defines the test method CanDropTableWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanDropTableWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteTableExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("DROP TABLE TestTable1");
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
            result.ShouldBe("RENAME TABLE TestSchema.TestTable1 TO TestTable2");
        }

        /// <summary>
        /// Defines the test method CanRenameTableWithDefaultSchema.
        /// </summary>
        [Test]
        public override void CanRenameTableWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetRenameTableExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("RENAME TABLE TestTable1 TO TestTable2");
        }
    }
}
