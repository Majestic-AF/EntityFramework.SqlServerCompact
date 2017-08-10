﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;
using Microsoft.EntityFrameworkCore.ReverseEngineering;
using Microsoft.EntityFrameworkCore.TestUtilities.Xunit;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFramework.SqlServerCompact40.Design.FunctionalTest.ReverseEngineering
{
    public class SqlCeE2ETests : E2ETestBase, IClassFixture<SqlCeE2EFixture>
    {
        protected override string ProviderName => "EntityFrameworkCore.SqlServerCompact40.Design";

        protected override void ConfigureDesignTimeServices(IServiceCollection services)
            => new SqlCeDesignTimeServices().ConfigureDesignTimeServices(services);

        public virtual string TestNamespace => "E2ETest.Namespace";
        public virtual string TestProjectDir => Path.Combine("E2ETest", "Output");
        public virtual string TestSubDir => "SubDir";
        public virtual string CustomizedTemplateDir => Path.Combine("E2ETest", "CustomizedTemplate", "Dir");

        //public static Microsoft.EntityFrameworkCore.Scaffolding.TableSelectionSet Filter
        //    => new Microsoft.EntityFrameworkCore.Scaffolding.TableSelectionSet(new List<string>{
        //        "AllDataTypes",
        //        "PropertyConfiguration",
        //        "Test Spaces Keywords Table",
        //        "MultipleFKsDependent",
        //        "MultipleFKsPrincipal",
        //        "OneToManyDependent",
        //        "OneToManyPrincipal",
        //        "OneToOneDependent",
        //        "OneToOnePrincipal",
        //        "OneToOneSeparateFKDependent",
        //        "OneToOneSeparateFKPrincipal",
        //        "OneToOneFKToUniqueKeyDependent",
        //        "OneToOneFKToUniqueKeyPrincipal",
        //        "ReferredToByTableWithUnmappablePrimaryKeyColumn",
        //        "TableWithUnmappablePrimaryKeyColumn",
        //        "selfReferencing",
        //    });

        public static IEnumerable<string> Tables
            => new List<string>
            {
                "AllDataTypes",
                "PropertyConfiguration",
                "Test Spaces Keywords Table",
                "MultipleFKsDependent",
                "MultipleFKsPrincipal",
                "OneToManyDependent",
                "OneToManyPrincipal",
                "OneToOneDependent",
                "OneToOnePrincipal",
                "OneToOneSeparateFKDependent",
                "OneToOneSeparateFKPrincipal",
                "OneToOneFKToUniqueKeyDependent",
                "OneToOneFKToUniqueKeyPrincipal",
                "ReferredToByTableWithUnmappablePrimaryKeyColumn",
                "TableWithUnmappablePrimaryKeyColumn",
                "selfreferencing"
            };

        // ReSharper disable once UnusedParameter.Local
        public SqlCeE2ETests(SqlCeE2EFixture fixture, ITestOutputHelper output)
            : base(output)
        {
        }

        private string _connectionString = @"Data Source=E2E.sdf";

        private static readonly List<string> _expectedEntityTypeFiles = new List<string>
            {
                "AllDataTypes.expected",
                "MultipleFKsDependent.expected",
                "MultipleFKsPrincipal.expected",
                "OneToManyDependent.expected",
                "OneToManyPrincipal.expected",
                "OneToOneDependent.expected",
                "OneToOneFKToUniqueKeyDependent.expected",
                "OneToOneFKToUniqueKeyPrincipal.expected",
                "OneToOnePrincipal.expected",
                "OneToOneSeparateFKDependent.expected",
                "OneToOneSeparateFKPrincipal.expected",
                "PropertyConfiguration.expected",
                "ReferredToByTableWithUnmappablePrimaryKeyColumn.expected",
                "SelfReferencing.expected",
                "Test_Spaces_Keywords_Table.expected"
            };

        [Fact]
        [UseCulture("en-US")]
        public void E2ETestUseAttributesInsteadOfFluentApi()
        {
            var filePaths = Generator.Generate(
                    _connectionString,
                    Tables,
                    Enumerable.Empty<string>(),
                    TestProjectDir + Path.DirectorySeparatorChar, // tests that ending DirectorySeparatorChar does not affect namespace
                    TestSubDir,
                    TestNamespace,
                    contextName: "AttributesContext",
                    useDataAnnotations: true,
                    overwriteFiles: false,
                    useDatabaseNames: false);

            var actualFileSet = new FileSet(InMemoryFiles, Path.GetFullPath(Path.Combine(TestProjectDir, TestSubDir)))
            {
                Files = Enumerable.Repeat(filePaths.ContextFile, 1).Concat(filePaths.EntityTypeFiles).Select(Path.GetFileName).ToList()
            };

            var expectedFileSet = new FileSet(new FileSystemFileService(),
                Path.Combine("ReverseEngineering", "ExpectedResults", "E2E_UseAttributesInsteadOfFluentApi"),
                contents => contents.Replace("namespace " + TestNamespace, "namespace " + TestNamespace + "." + TestSubDir)
                    .Replace("{{connectionString}}", _connectionString))
            {
                Files = new List<string> { "AttributesContext.expected" }
                    .Concat(_expectedEntityTypeFiles).ToList()
            };

            AssertEqualFileContents(expectedFileSet, actualFileSet);
            //TODO ErikEJ Investigate compile issue
            //AssertCompile(actualFileSet);
        }

        //[Fact]
        //[UseCulture("en-US")]
        public void E2ETestAllFluentApi()
        {
            var filePaths = Generator.Generate(
                                _connectionString,
                                Tables,
                                Enumerable.Empty<string>(),
                                TestProjectDir,
                                outputPath: null, // not used for this test
                                rootNamespace: TestNamespace,
                                contextName: null,
                                useDataAnnotations: false,
                                overwriteFiles: false,
                                useDatabaseNames: false);

            var actualFileSet = new FileSet(InMemoryFiles, Path.GetFullPath(TestProjectDir))
            {
                Files = Enumerable.Repeat(filePaths.ContextFile, 1).Concat(filePaths.EntityTypeFiles).Select(Path.GetFileName).ToList()
            };

            var expectedFileSet = new FileSet(new FileSystemFileService(),
                Path.Combine("ReverseEngineering", "ExpectedResults", "E2E_AllFluentApi"),
                inputFile => inputFile.Replace("{{connectionString}}", _connectionString))
            {
                Files = new List<string> { "E2EContext.expected" }
                    .Concat(_expectedEntityTypeFiles).ToList()
            };

            AssertEqualFileContents(expectedFileSet, actualFileSet);
            AssertCompile(actualFileSet);
        }

        protected override ICollection<BuildReference> References { get; } = new List<BuildReference>
        {
            BuildReference.ByName("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"),
            BuildReference.ByName("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"),
            BuildReference.ByName("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"),
            BuildReference.ByName("System.ComponentModel.DataAnnotations, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"),
            BuildReference.ByName("EntityFrameworkCore.SqlServerCompact40"),
            BuildReference.ByName("System.Data.SqlServerCe, Version=4.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"),

            BuildReference.ByName("Microsoft.EntityFrameworkCore"),
            BuildReference.ByName("Microsoft.EntityFrameworkCore.Relational"),
            BuildReference.ByName("Microsoft.Extensions.Caching.Abstractions"),
            BuildReference.ByName("Microsoft.Extensions.Logging.Abstractions")
        };
    }
}
