﻿// ***********************************************************************
// Assembly         : FluentMigrator.Tests
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="DeleteConstriantTest.cs" company="FluentMigrator Project">
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

using System.Collections.Generic;
using NUnit.Framework;
using FluentMigrator.Expressions;
using Moq;
using FluentMigrator.Infrastructure;
using FluentMigrator.Builders.Delete;

namespace FluentMigrator.Tests.Unit.Builders.Delete
{
    /// <summary>
    /// Defines test class DeleteConstraintTest.
    /// </summary>
    [TestFixture]
    public class DeleteConstraintTest
    {
        /// <summary>
        /// Defines the test method CallingDeletePrimaryKeyCreatesADeleteConstraintExpression.
        /// </summary>
        [Test]
        public void CallingDeletePrimaryKeyCreatesADeleteConstraintExpression()
        {
            var collectionMock = new Mock<ICollection<IMigrationExpression>>();

            var contextMock = new Mock<IMigrationContext>();
            contextMock.Setup(x => x.Expressions).Returns(collectionMock.Object);

            var root = new DeleteExpressionRoot(contextMock.Object);
            root.PrimaryKey("TestKey");

            collectionMock.Verify(x => x.Add(It.Is<DeleteConstraintExpression>(e => e.Constraint.IsPrimaryKeyConstraint)));
            collectionMock.Verify(x => x.Add(It.Is<DeleteConstraintExpression>(e => e.Constraint.ConstraintName == "TestKey")));
            contextMock.VerifyGet(x => x.Expressions);
        }

        /// <summary>
        /// Defines the test method CallingDeleteUniqueConstraintCreatesADeleteConstraintExpression.
        /// </summary>
        [Test]
        public void CallingDeleteUniqueConstraintCreatesADeleteConstraintExpression()
        {
            var collectionMock = new Mock<ICollection<IMigrationExpression>>();

            var contextMock = new Mock<IMigrationContext>();
            contextMock.Setup(x => x.Expressions).Returns(collectionMock.Object);

            var root = new DeleteExpressionRoot(contextMock.Object);
            root.UniqueConstraint("TestUniqueConstraintName");

            collectionMock.Verify(x => x.Add(It.Is<DeleteConstraintExpression>(e => e.Constraint.IsUniqueConstraint)));
            collectionMock.Verify(x => x.Add(It.Is<DeleteConstraintExpression>(e => e.Constraint.ConstraintName == "TestUniqueConstraintName")));
            contextMock.VerifyGet(x => x.Expressions);
        }
    }
}
