﻿// ***********************************************************************
// Assembly         : FluentMigrator.Abstractions
// Author           : eivin
// Created          : 10-10-2019
//
// Last Modified By : eivin
// Last Modified On : 10-10-2019
// ***********************************************************************
// <copyright file="ErrorMessages.Designer.cs" company="FluentMigrator Project">
//     Sean Chambers and the FluentMigrator project 2008-2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace FluentMigrator.Infrastructure {
    using System;


    /// <summary>
    /// Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    /// </summary>
    // Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    // -Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    // Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    // mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorMessages {

        /// <summary>
        /// The resource man
        /// </summary>
        private static global::System.Resources.ResourceManager resourceMan;

        /// <summary>
        /// The resource culture
        /// </summary>
        private static global::System.Globalization.CultureInfo resourceCulture;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorMessages"/> class.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }

        /// <summary>
        /// Gibt die zwischengespeicherte ResourceManager-Instanz zurück, die von dieser Klasse verwendet wird.
        /// </summary>
        /// <value>The resource manager.</value>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FluentMigrator.Infrastructure.ErrorMessages", typeof(ErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        /// Überschreibt die CurrentUICulture-Eigenschaft des aktuellen Threads für alle
        /// Ressourcenzuordnungen, die diese stark typisierte Ressourcenklasse verwenden.
        /// </summary>
        /// <value>The culture.</value>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The column's name cannot be null or an empty string. ähnelt.
        /// </summary>
        /// <value>The column name cannot be null or empty.</value>
        public static string ColumnNameCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("ColumnNameCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die Column names must be unique. ähnelt.
        /// </summary>
        /// <value>The column names must be unique.</value>
        public static string ColumnNamesMustBeUnique {
            get {
                return ResourceManager.GetString("ColumnNamesMustBeUnique", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The column does not have a type defined. ähnelt.
        /// </summary>
        /// <value>The column type must be defined.</value>
        public static string ColumnTypeMustBeDefined {
            get {
                return ResourceManager.GetString("ColumnTypeMustBeDefined", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The constraint must have at least one column specified. ähnelt.
        /// </summary>
        /// <value>The constraint must have at least one column.</value>
        public static string ConstraintMustHaveAtLeastOneColumn {
            get {
                return ResourceManager.GetString("ConstraintMustHaveAtLeastOneColumn", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The default value cannot be null. ähnelt.
        /// </summary>
        /// <value>The default value cannot be null.</value>
        public static string DefaultValueCannotBeNull {
            get {
                return ResourceManager.GetString("DefaultValueCannotBeNull", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The destination schema's name cannot be null or an empty string. ähnelt.
        /// </summary>
        /// <value>The destination schema cannot be null.</value>
        public static string DestinationSchemaCannotBeNull {
            get {
                return ResourceManager.GetString("DestinationSchemaCannotBeNull", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die expression.TableName must not be empty ähnelt.
        /// </summary>
        /// <value>The expression table name missing.</value>
        public static string ExpressionTableNameMissing {
            get {
                return ResourceManager.GetString("ExpressionTableNameMissing", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die Table name not specified, ensure you have appended the OnTable extension. Format should be Delete.ForeignKey(KeyName).OnTable(TableName) ähnelt.
        /// </summary>
        /// <value>The expression table name missing with hints.</value>
        public static string ExpressionTableNameMissingWithHints {
            get {
                return ResourceManager.GetString("ExpressionTableNameMissingWithHints", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The foreign key must have one or more foreign columns. ähnelt.
        /// </summary>
        /// <value>The foreign key must have one or more foreign columns.</value>
        public static string ForeignKeyMustHaveOneOrMoreForeignColumns {
            get {
                return ResourceManager.GetString("ForeignKeyMustHaveOneOrMoreForeignColumns", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The foreign key must have one or more primary columns. ähnelt.
        /// </summary>
        /// <value>The foreign key must have one or more primary columns.</value>
        public static string ForeignKeyMustHaveOneOrMorePrimaryColumns {
            get {
                return ResourceManager.GetString("ForeignKeyMustHaveOneOrMorePrimaryColumns", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The foreign key's name cannot be null or an empty string. ähnelt.
        /// </summary>
        /// <value>The foreign key name cannot be null or empty.</value>
        public static string ForeignKeyNameCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("ForeignKeyNameCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The foreign table name cannot be null or empty. ähnelt.
        /// </summary>
        /// <value>The foreign table name cannot be null or empty.</value>
        public static string ForeignTableNameCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("ForeignTableNameCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The index must have one or more columns. ähnelt.
        /// </summary>
        /// <value>The index must have one or more columns.</value>
        public static string IndexMustHaveOneOrMoreColumns {
            get {
                return ResourceManager.GetString("IndexMustHaveOneOrMoreColumns", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The index's name cannot be null or an empty string. ähnelt.
        /// </summary>
        /// <value>The index name cannot be null or empty.</value>
        public static string IndexNameCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("IndexNameCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The {0} method must be called on an object that implements {1}. ähnelt.
        /// </summary>
        /// <value>The method x must be called on object implementing y.</value>
        public static string MethodXMustBeCalledOnObjectImplementingY {
            get {
                return ResourceManager.GetString("MethodXMustBeCalledOnObjectImplementingY", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The new column name cannot be null or empty. ähnelt.
        /// </summary>
        /// <value>The new column name cannot be null or empty.</value>
        public static string NewColumnNameCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("NewColumnNameCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The new table name cannot be null or empty. ähnelt.
        /// </summary>
        /// <value>The new table name cannot be null or empty.</value>
        public static string NewTableNameCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("NewTableNameCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The old column name cannot be null or empty. ähnelt.
        /// </summary>
        /// <value>The old column name cannot be null or empty.</value>
        public static string OldColumnNameCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("OldColumnNameCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The old table name cannot be null or empty. ähnelt.
        /// </summary>
        /// <value>The old table name cannot be null or empty.</value>
        public static string OldTableNameCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("OldTableNameCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The operation to be performed using the database connection cannot be null. ähnelt.
        /// </summary>
        /// <value>The operation cannot be null.</value>
        public static string OperationCannotBeNull {
            get {
                return ResourceManager.GetString("OperationCannotBeNull", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The primary table name cannot be null or empty. ähnelt.
        /// </summary>
        /// <value>The primary table name cannot be null or empty.</value>
        public static string PrimaryTableNameCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("PrimaryTableNameCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The schema's name cannot be null or an empty string. ähnelt.
        /// </summary>
        /// <value>The schema name cannot be null or empty.</value>
        public static string SchemaNameCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("SchemaNameCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The sequence's name cannot be null or an empty string. ähnelt.
        /// </summary>
        /// <value>The sequence name cannot be null or empty.</value>
        public static string SequenceNameCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("SequenceNameCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The sql script cannot be null or an empty string. ähnelt.
        /// </summary>
        /// <value>The SQL script cannot be null or empty.</value>
        public static string SqlScriptCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("SqlScriptCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The sql statement cannot be null or an empty string. ähnelt.
        /// </summary>
        /// <value>The SQL statement cannot be null or empty.</value>
        public static string SqlStatementCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("SqlStatementCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die The table's name cannot be null or an empty string. ähnelt.
        /// </summary>
        /// <value>The table name cannot be null or empty.</value>
        public static string TableNameCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("TableNameCannotBeNullOrEmpty", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die Update statement specifies both a .Where() condition and that .AllRows() should be targeted. Specify one or the other, but not both. ähnelt.
        /// </summary>
        /// <value>The update data expression must not specify both where clause and all rows.</value>
        public static string UpdateDataExpressionMustNotSpecifyBothWhereClauseAndAllRows {
            get {
                return ResourceManager.GetString("UpdateDataExpressionMustNotSpecifyBothWhereClauseAndAllRows", resourceCulture);
            }
        }

        /// <summary>
        /// Sucht eine lokalisierte Zeichenfolge, die Update statement is missing a condition. Specify one by calling .Where() or target all rows by calling .AllRows(). ähnelt.
        /// </summary>
        /// <value>The update data expression must specify where clause or all rows.</value>
        public static string UpdateDataExpressionMustSpecifyWhereClauseOrAllRows {
            get {
                return ResourceManager.GetString("UpdateDataExpressionMustSpecifyWhereClauseOrAllRows", resourceCulture);
            }
        }
    }
}
