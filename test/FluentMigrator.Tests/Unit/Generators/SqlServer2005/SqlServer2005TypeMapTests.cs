﻿// ***********************************************************************
// Assembly         : FluentMigrator.Tests
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="SqlServer2005TypeMapTests.cs" company="FluentMigrator Project">
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

using System;
using System.Data;
using FluentMigrator.Runner.Generators.SqlServer;
using NUnit.Framework;
using Shouldly;

namespace FluentMigrator.Tests.Unit.Generators.SqlServer2005
{
    /// <summary>
    /// Defines test class SqlServer2005TypeMapTests.
    /// </summary>
    [TestFixture]
    [Category("SqlServer2005")]
    [Category("Generator")]
    [Category("TypeMap")]
    public abstract class SqlServer2005TypeMapTests
    {
        /// <summary>
        /// Gets or sets the type map.
        /// </summary>
        /// <value>The type map.</value>
        private SqlServer2005TypeMap TypeMap { get; set; }

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            TypeMap = new SqlServer2005TypeMap();
        }

        /// <summary>
        /// Defines test class AnsistringTests.
        /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        /// </summary>
        /// <seealso cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        [TestFixture]
        public class AnsistringTests : SqlServer2005TypeMapTests
        {
            /// <summary>
            /// Defines the test method ItMapsAnsistringByDefaultToVarchar255.
            /// </summary>
            [Test]
            public void ItMapsAnsistringByDefaultToVarchar255()
            {
                var template = TypeMap.GetTypeMap(DbType.AnsiString, size: null, precision: null);

                template.ShouldBe("VARCHAR(255)");
            }

            /// <summary>
            /// Defines the test method ItMapsAnsistringWithSizeToVarcharOfSize.
            /// </summary>
            /// <param name="size">The size.</param>
            [Test]
            [TestCase(1)]
            [TestCase(4000)]
            [TestCase(8000)]
            public void ItMapsAnsistringWithSizeToVarcharOfSize(int size)
            {
                var template = TypeMap.GetTypeMap(DbType.AnsiString, size, precision: null);

                template.ShouldBe($"VARCHAR({size})");
            }

            /// <summary>
            /// Defines the test method ItMapsAnsistringWithSizeAbove8000ToVarcharMax.
            /// </summary>
            /// <param name="size">The size.</param>
            [Test]
            [TestCase(8001)]
            [TestCase(2147483647)]
            public void ItMapsAnsistringWithSizeAbove8000ToVarcharMax(int size)
            {
                var template = TypeMap.GetTypeMap(DbType.AnsiString, size, precision: null);

                template.ShouldBe("VARCHAR(MAX)");
            }
        }

        /// <summary>
        /// Defines test class AnsistringFixedLengthTests.
        /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        /// </summary>
        /// <seealso cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        [TestFixture]
        public class AnsistringFixedLengthTests : SqlServer2005TypeMapTests
        {
            /// <summary>
            /// Defines the test method ItMapsAnsistringFixedLengthByDefaultToChar255.
            /// </summary>
            [Test]
            public void ItMapsAnsistringFixedLengthByDefaultToChar255()
            {
                var template = TypeMap.GetTypeMap(DbType.AnsiStringFixedLength, size: null, precision: null);

                template.ShouldBe("CHAR(255)");
            }

            /// <summary>
            /// Defines the test method ItMapsAnsistringFixedLengthWithSizeToCharOfSize.
            /// </summary>
            /// <param name="size">The size.</param>
            [Test]
            [TestCase(1)]
            [TestCase(4000)]
            [TestCase(8000)]
            public void ItMapsAnsistringFixedLengthWithSizeToCharOfSize(int size)
            {
                var template = TypeMap.GetTypeMap(DbType.AnsiStringFixedLength, size, precision: null);

                template.ShouldBe($"CHAR({size})");
            }

            /// <summary>
            /// Defines the test method ItThrowsIfAnsistringFixedLengthHasSizeAbove8000.
            /// </summary>
            [Test]
            public void ItThrowsIfAnsistringFixedLengthHasSizeAbove8000()
            {
                Should.Throw<NotSupportedException>(
                    () => TypeMap.GetTypeMap(DbType.AnsiStringFixedLength, 8001, precision: null));
            }
        }

        /// <summary>
        /// Defines test class StringTests.
        /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        /// </summary>
        /// <seealso cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        [TestFixture]
        public class StringTests : SqlServer2005TypeMapTests
        {
            /// <summary>
            /// Defines the test method ItMapsStringByDefaultToNvarchar255.
            /// </summary>
            [Test]
            public void ItMapsStringByDefaultToNvarchar255()
            {
                var template = TypeMap.GetTypeMap(DbType.String, size: null, precision: null);

                template.ShouldBe("NVARCHAR(255)");
            }

            /// <summary>
            /// Defines the test method ItMapsStringWithSizeToNvarcharOfSize.
            /// </summary>
            /// <param name="size">The size.</param>
            [Test]
            [TestCase(1)]
            [TestCase(4000)]
            public void ItMapsStringWithSizeToNvarcharOfSize(int size)
            {
                var template = TypeMap.GetTypeMap(DbType.String, size, precision: null);

                template.ShouldBe($"NVARCHAR({size})");
            }

            /// <summary>
            /// Defines the test method ItMapsStringWithSizeAbove4000ToNvarcharMax.
            /// </summary>
            /// <param name="size">The size.</param>
            [Test]
            [TestCase(4001)]
            [TestCase(1073741823)]
            public void ItMapsStringWithSizeAbove4000ToNvarcharMax(int size)
            {
                var template = TypeMap.GetTypeMap(DbType.String, size, precision: null);

                template.ShouldBe("NVARCHAR(MAX)");
            }

            /// <summary>
            /// Defines the test method ItMapsStringWithSizeAbove1073741823ToNvarcharMaxToAllowIntMaxvalueConvention.
            /// </summary>
            [Test]
            public void ItMapsStringWithSizeAbove1073741823ToNvarcharMaxToAllowIntMaxvalueConvention()
            {
                var template = TypeMap.GetTypeMap(DbType.String, int.MaxValue, precision: null);

                template.ShouldBe("NVARCHAR(MAX)");
            }
        }

        /// <summary>
        /// Defines test class StringFixedLengthTests.
        /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        /// </summary>
        /// <seealso cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        [TestFixture]
        public class StringFixedLengthTests : SqlServer2005TypeMapTests
        {
            /// <summary>
            /// Defines the test method ItMapsStringFixedLengthByDefaultToNchar255.
            /// </summary>
            [Test]
            public void ItMapsStringFixedLengthByDefaultToNchar255()
            {
                var template = TypeMap.GetTypeMap(DbType.StringFixedLength, size: null, precision: null);

                template.ShouldBe("NCHAR(255)");
            }


            /// <summary>
            /// Defines the test method ItMapsStringFixedLengthWithSizeToNcharOfSize.
            /// </summary>
            /// <param name="size">The size.</param>
            [Test]
            [TestCase(1)]
            [TestCase(4000)]
            public void ItMapsStringFixedLengthWithSizeToNcharOfSize(int size)
            {
                var template = TypeMap.GetTypeMap(DbType.StringFixedLength, size, precision: null);

                template.ShouldBe($"NCHAR({size})");
            }

            /// <summary>
            /// Defines the test method ItThrowsIfStringFixedLengthHasSizeAbove4000.
            /// </summary>
            [Test]
            public void ItThrowsIfStringFixedLengthHasSizeAbove4000()
            {
                Should.Throw<NotSupportedException>(
                    () => TypeMap.GetTypeMap(DbType.StringFixedLength, 4001, precision: null));
            }
        }

        /// <summary>
        /// Defines test class BinaryTests.
        /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        /// </summary>
        /// <seealso cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        [TestFixture]
        public class BinaryTests : SqlServer2005TypeMapTests
        {
            /// <summary>
            /// Defines the test method ItMapsBinaryByDefaultToVarbinary8000.
            /// </summary>
            [Test]
            public void ItMapsBinaryByDefaultToVarbinary8000()
            {
                var template = TypeMap.GetTypeMap(DbType.Binary, size: null, precision: null);

                template.ShouldBe("VARBINARY(8000)");
            }

            /// <summary>
            /// Defines the test method ItMapsBinaryWithSizeToVarbinaryOfSize.
            /// </summary>
            /// <param name="size">The size.</param>
            [Test]
            [TestCase(1)]
            [TestCase(4000)]
            [TestCase(8000)]
            public void ItMapsBinaryWithSizeToVarbinaryOfSize(int size)
            {
                var template = TypeMap.GetTypeMap(DbType.Binary, size, precision: null);

                template.ShouldBe($"VARBINARY({size})");
            }

            /// <summary>
            /// Defines the test method ItMapsBinaryWithSizeAbove8000ToVarbinaryMax.
            /// </summary>
            /// <param name="size">The size.</param>
            [Test]
            [TestCase(8001)]
            [TestCase(int.MaxValue)]
            public void ItMapsBinaryWithSizeAbove8000ToVarbinaryMax(int size)
            {
                var template = TypeMap.GetTypeMap(DbType.Binary, size, precision: null);

                template.ShouldBe("VARBINARY(MAX)");
            }
        }

        /// <summary>
        /// Defines test class NumericTests.
        /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        /// </summary>
        /// <seealso cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        [TestFixture]
        public class NumericTests : SqlServer2005TypeMapTests
        {
            /// <summary>
            /// Defines the test method ItMapsBooleanToBit.
            /// </summary>
            [Test]
            public void ItMapsBooleanToBit()
            {
                var template = TypeMap.GetTypeMap(DbType.Boolean, size: null, precision: null);

                template.ShouldBe("BIT");
            }

            /// <summary>
            /// Defines the test method ItMapsByteToTinyint.
            /// </summary>
            [Test]
            public void ItMapsByteToTinyint()
            {
                var template = TypeMap.GetTypeMap(DbType.Byte, size: null, precision: null);

                template.ShouldBe("TINYINT");
            }

            /// <summary>
            /// Defines the test method ItMapsInt16ToSmallint.
            /// </summary>
            [Test]
            public void ItMapsInt16ToSmallint()
            {
                var template = TypeMap.GetTypeMap(DbType.Int16, size: null, precision: null);

                template.ShouldBe("SMALLINT");
            }

            /// <summary>
            /// Defines the test method ItMapsInt32ToInt.
            /// </summary>
            [Test]
            public void ItMapsInt32ToInt()
            {
                var template = TypeMap.GetTypeMap(DbType.Int32, size: null, precision: null);

                template.ShouldBe("INT");
            }

            /// <summary>
            /// Defines the test method ItMapsInt64ToBigint.
            /// </summary>
            [Test]
            public void ItMapsInt64ToBigint()
            {
                var template = TypeMap.GetTypeMap(DbType.Int64, size: null, precision: null);

                template.ShouldBe("BIGINT");
            }

            /// <summary>
            /// Defines the test method ItMapsSingleToReal.
            /// </summary>
            [Test]
            public void ItMapsSingleToReal()
            {
                var template = TypeMap.GetTypeMap(DbType.Single, size: null, precision: null);

                template.ShouldBe("REAL");
            }

            /// <summary>
            /// Defines the test method ItMapsDoubleToDoublePrecision.
            /// </summary>
            [Test]
            public void ItMapsDoubleToDoublePrecision()
            {
                var template = TypeMap.GetTypeMap(DbType.Double, size: null, precision: null);

                template.ShouldBe("DOUBLE PRECISION");
            }

            /// <summary>
            /// Defines the test method ItMapsCurrencyToMoney.
            /// </summary>
            [Test]
            public void ItMapsCurrencyToMoney()
            {
                var template = TypeMap.GetTypeMap(DbType.Currency, size: null, precision: null);

                template.ShouldBe("MONEY");
            }

            /// <summary>
            /// Defines the test method ItMapsDecimalByDefaultToDecimal195.
            /// </summary>
            [Test]
            public void ItMapsDecimalByDefaultToDecimal195()
            {
                var template = TypeMap.GetTypeMap(DbType.Decimal, size: null, precision: null);

                template.ShouldBe("DECIMAL(19,5)");
            }

            /// <summary>
            /// Defines the test method ItMapsDecimalWithPrecisionToDecimal.
            /// </summary>
            /// <param name="precision">The precision.</param>
            [Test]
            [TestCase(1)]
            [TestCase(20)]
            [TestCase(38)]
            public void ItMapsDecimalWithPrecisionToDecimal(int precision)
            {
                var template = TypeMap.GetTypeMap(DbType.Decimal, (int?) precision, precision: 1);

                template.ShouldBe($"DECIMAL({precision},1)");
            }

            /// <summary>
            /// Defines the test method ItThrowsIfDecimalPrecisionIsAbove38.
            /// </summary>
            [Test]
            public void ItThrowsIfDecimalPrecisionIsAbove38()
            {
                Should.Throw<NotSupportedException>(
                    () => TypeMap.GetTypeMap(DbType.Decimal, 39, precision: null));
            }
        }

        /// <summary>
        /// Defines test class GuidTests.
        /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        /// </summary>
        /// <seealso cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        [TestFixture]
        public class GuidTests : SqlServer2005TypeMapTests
        {
            /// <summary>
            /// Defines the test method ItMapsGUIDToUniqueidentifier.
            /// </summary>
            [Test]
            public void ItMapsGUIDToUniqueidentifier()
            {
                var template = TypeMap.GetTypeMap(DbType.Guid, size: null, precision: null);

                template.ShouldBe("UNIQUEIDENTIFIER");
            }
        }

        /// <summary>
        /// Defines test class DateTimeTests.
        /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        /// </summary>
        /// <seealso cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        [TestFixture]
        public class DateTimeTests : SqlServer2005TypeMapTests
        {
            /// <summary>
            /// Defines the test method ItMapsTimeToDatetime.
            /// </summary>
            [Test]
            public void ItMapsTimeToDatetime()
            {
                var template = TypeMap.GetTypeMap(DbType.Time, size: null, precision: null);

                template.ShouldBe("DATETIME");
            }

            /// <summary>
            /// Defines the test method ItMapsDateToDatetime.
            /// </summary>
            [Test]
            public void ItMapsDateToDatetime()
            {
                var template = TypeMap.GetTypeMap(DbType.Date, size: null, precision: null);

                template.ShouldBe("DATETIME");
            }

            /// <summary>
            /// Defines the test method ItMapsDatetimeToDatetime.
            /// </summary>
            [Test]
            public void ItMapsDatetimeToDatetime()
            {
                var template = TypeMap.GetTypeMap(DbType.DateTime, size: null, precision: null);

                template.ShouldBe("DATETIME");
            }
        }

        /// <summary>
        /// Defines test class XmlTests.
        /// Implements the <see cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        /// </summary>
        /// <seealso cref="FluentMigrator.Tests.Unit.Generators.SqlServer2005.SqlServer2005TypeMapTests" />
        [TestFixture]
        public class XmlTests : SqlServer2005TypeMapTests
        {
            /// <summary>
            /// Defines the test method ItMapsXmlToXml.
            /// </summary>
            [Test]
            public void ItMapsXmlToXml()
            {
                var template = TypeMap.GetTypeMap(DbType.Xml, size: null, precision: null);

                template.ShouldBe("XML");
            }
        }
    }
}
