﻿using Biohazrd.Tests.Common;
using Biohazrd.Transformation.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace Biohazrd.Transformation.Tests
{
    // This test only handled Windows linking.
    // ELF (Linux) support is tested in LinkImportsTransformationElfTests.
    //
    // Note that all tests within this file are marked as Windows-only not because LinkImportsTransformation is Windows-only, but
    // because they rely on being able to invoke the MSVC librarian to generate static libraries for testing.
    // (Unfortunately lld-link cannot serve as a stand-in.)
    [RelatedIssue("https://github.com/InfectedLibraries/Biohazrd/issues/119")]
    public sealed class LinkImportsTransformationTests : BiohazrdTestBase
    {
        protected override string? DefaultTargetTriple
        {
            get
            {
                // Use the default target triple on Windows
                if (OperatingSystem.IsWindows())
                { return null; }

                // On non-Windows use an appropriate known triple or fall back on Windows x64
                return RuntimeInformation.OSArchitecture switch
                {
                    Architecture.X64 => "x86_64-pc-windows",
                    Architecture.Arm64 => "aarch64-pc-windows",
                    _ => "x86_64-pc-windows"
                };
            }
        }

        /// <summary>Creates an import library with the given name and exports.</summary>
        /// <param name="transformation">An optional transformation to automatically add the library to.</param>
        /// <param name="libName">The name of the library without any file extension.</param>
        /// <param name="exports">An export definition in the format used by LIB's <c>/EXPORT</c> command line switch.</param>
        /// <remarks>
        /// See https://docs.microsoft.com/en-us/cpp/build/reference/building-an-import-library-and-export-file for details the format of the values of <paramref name="exports"/>.
        /// </remarks>
        private void CreateImportLib(LinkImportsTransformation? transformation, string libName, params string[] exports)
        {
            if (!OperatingSystem.IsWindows())
            {
                Assert.Skip
                (
                    "This test can only be executed on Windows." +
                    " (NOTE: Dynamic skipping does not actually work in xunit v2. If you're reading this failure message mark the test with [WindowsFact].)"
                );
            }

            libName += ".lib";

            List<string> arguments = new()
            {
                "/NOLOGO",
                "/MACHINE:X64",
                $"/OUT:{libName}",
                "/DEF"
            };
            arguments.AddRange(exports.Select(e => $"/EXPORT:{e}"));

            MsvcTools.Lib(arguments);
            transformation?.AddLibrary(libName);
        }

        /// <summary>Creates an import library with the given name and exports.</summary>
        /// <param name="libName">The name of the library without any file extension.</param>
        /// <param name="exports">An export definition in the format used by LIB's <c>/EXPORT</c> command line switch.</param>
        /// <remarks>
        /// See https://docs.microsoft.com/en-us/cpp/build/reference/building-an-import-library-and-export-file for details the format of the values of <paramref name="exports"/>.
        /// </remarks>
        private void CreateImportLib(string libName, params string[] exports)
            => CreateImportLib(null, libName, exports);

        [WindowsFact]
        public void NormalSymbolTest()
        {
            LinkImportsTransformation transformation = new();
            CreateImportLib(transformation, nameof(NormalSymbolTest), "TestFunction");
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Empty(function.Diagnostics);
            Assert.Equal($"{nameof(NormalSymbolTest)}.dll", function.DllFileName);
            Assert.Equal("TestFunction", function.MangledName);
        }

        [WindowsFact]
        public void NormalSymbolTest_GlobalVariable()
        {
            LinkImportsTransformation transformation = new();
            CreateImportLib(transformation, nameof(NormalSymbolTest_GlobalVariable), "TestGlobal,DATA");
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" int TestGlobal;");
            library = transformation.Transform(library);

            TranslatedStaticField staticField = library.FindDeclaration<TranslatedStaticField>("TestGlobal");
            Assert.Empty(staticField.Diagnostics);
            Assert.Equal($"{nameof(NormalSymbolTest_GlobalVariable)}.dll", staticField.DllFileName);
            Assert.Equal("TestGlobal", staticField.MangledName);
        }

        [WindowsFact]
        public void OrdinalSymbolTest()
        {
            LinkImportsTransformation transformation = new();
            CreateImportLib(transformation, nameof(OrdinalSymbolTest), "TestFunction,@3226,NONAME");
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Equal($"{nameof(OrdinalSymbolTest)}.dll", function.DllFileName);
            Assert.Equal("#3226", function.MangledName);
            // Ordinals don't work in all contexts for C#, so we expect a warning.
            // It's not the most ideal that we have a C# concern in a common transformation, but ordinal imports aren't especially common and
            // it's not worth complicating this transformation to split its concerns between Biohazrd.Transformation.Common and Biohazrd.CSharp.
            // We can always improve this later if it becomes an issue.
            Assert.Contains(function.Diagnostics, d => d.Severity == Severity.Warning && d.Message.Contains("resolved to ordinal"));
        }

        [WindowsFact]
        public void MangledCppSymbolTest()
        {
            LinkImportsTransformation transformation = new();
            const string testFunctionMangled = "?TestFunction@@YAXXZ"; // The mangling of this symbol is the same between x86, x64, ARM32, and ARM64.
            CreateImportLib(transformation, nameof(MangledCppSymbolTest), testFunctionMangled);
            TranslatedLibrary library = CreateLibrary(@"void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Equal($"{nameof(MangledCppSymbolTest)}.dll", function.DllFileName);
            Assert.Equal(testFunctionMangled, function.MangledName);
        }

        [WindowsFact]
        public void MultipleSymbolTest()
        {
            LinkImportsTransformation transformation = new();
            CreateImportLib(transformation, nameof(MultipleSymbolTest), "TestFunction", "AnotherFunction");
            TranslatedLibrary library = CreateLibrary
            (@"
extern ""C"" void TestFunction();
extern ""C"" void AnotherFunction();
"
            );
            library = transformation.Transform(library);

            TranslatedFunction testFunction = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Equal($"{nameof(MultipleSymbolTest)}.dll", testFunction.DllFileName);
            Assert.Equal("TestFunction", testFunction.MangledName);

            TranslatedFunction anotherFunction = library.FindDeclaration<TranslatedFunction>("AnotherFunction");
            Assert.Equal($"{nameof(MultipleSymbolTest)}.dll", anotherFunction.DllFileName);
            Assert.Equal("AnotherFunction", anotherFunction.MangledName);
        }

        [WindowsFact]
        public void MultipleLibraries()
        {
            LinkImportsTransformation transformation = new();
            CreateImportLib(transformation, $"{nameof(MultipleLibraries)}_0", "TestFunction");
            CreateImportLib(transformation, $"{nameof(MultipleLibraries)}_1", "AnotherFunction");
            TranslatedLibrary library = CreateLibrary
            (@"
extern ""C"" void TestFunction();
extern ""C"" void AnotherFunction();
"
            );
            library = transformation.Transform(library);

            TranslatedFunction testFunction = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Equal($"{nameof(MultipleLibraries)}_0.dll", testFunction.DllFileName);
            Assert.Equal("TestFunction", testFunction.MangledName);

            TranslatedFunction anotherFunction = library.FindDeclaration<TranslatedFunction>("AnotherFunction");
            Assert.Equal($"{nameof(MultipleLibraries)}_1.dll", anotherFunction.DllFileName);
            Assert.Equal("AnotherFunction", anotherFunction.MangledName);
        }

        [WindowsFact]
        public void MergedImportLibraryTest()
        {
            CreateImportLib($"{nameof(MergedImportLibraryTest)}_0", "TestFunction");
            CreateImportLib($"{nameof(MergedImportLibraryTest)}_1", "AnotherFunction");
            MsvcTools.Lib
            (
                "/NOLOGO",
                "/MACHINE:X64",
                $"/OUT:{nameof(MergedImportLibraryTest)}_Combined.lib",
                $"{nameof(MergedImportLibraryTest)}_0.lib",
                $"{nameof(MergedImportLibraryTest)}_1.lib"
            );

            LinkImportsTransformation transformation = new();
            transformation.AddLibrary($"{nameof(MergedImportLibraryTest)}_Combined.lib");
            TranslatedLibrary library = CreateLibrary
            (@"
extern ""C"" void TestFunction();
extern ""C"" void AnotherFunction();
"
            );
            library = transformation.Transform(library);

            TranslatedFunction testFunction = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Equal($"{nameof(MergedImportLibraryTest)}_0.dll", testFunction.DllFileName);
            Assert.Equal("TestFunction", testFunction.MangledName);

            TranslatedFunction anotherFunction = library.FindDeclaration<TranslatedFunction>("AnotherFunction");
            Assert.Equal($"{nameof(MergedImportLibraryTest)}_1.dll", anotherFunction.DllFileName);
            Assert.Equal("AnotherFunction", anotherFunction.MangledName);
        }

        [WindowsFact]
        public void AmbiguousSymbolResolvesToFirst()
        {
            LinkImportsTransformation transformation = new();
            CreateImportLib(transformation, $"{nameof(AmbiguousSymbolResolvesToFirst)}_0", "TestFunction");
            CreateImportLib(transformation, $"{nameof(AmbiguousSymbolResolvesToFirst)}_1", "TestFunction");
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Equal($"{nameof(AmbiguousSymbolResolvesToFirst)}_0.dll", function.DllFileName);
            Assert.Equal("TestFunction", function.MangledName);
        }

        [WindowsFact]
        public void WarnOnAmbiguousSymbols_False()
        {
            LinkImportsTransformation transformation = new()
            {
                WarnOnAmbiguousSymbols = false
            };

            CreateImportLib(transformation, $"{nameof(WarnOnAmbiguousSymbols_True)}_0", "TestFunction");
            CreateImportLib(transformation, $"{nameof(WarnOnAmbiguousSymbols_True)}_1", "TestFunction");
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Equal($"{nameof(WarnOnAmbiguousSymbols_True)}_0.dll", function.DllFileName);
            Assert.Equal("TestFunction", function.MangledName);
            Assert.Empty(function.Diagnostics);
        }

        [WindowsFact]
        public void WarnOnAmbiguousSymbols_True()
        {
            LinkImportsTransformation transformation = new()
            {
                WarnOnAmbiguousSymbols = true
            };

            CreateImportLib(transformation, $"{nameof(WarnOnAmbiguousSymbols_True)}_0", "TestFunction");
            CreateImportLib(transformation, $"{nameof(WarnOnAmbiguousSymbols_True)}_1", "TestFunction");
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Equal($"{nameof(WarnOnAmbiguousSymbols_True)}_0.dll", function.DllFileName);
            Assert.Equal("TestFunction", function.MangledName);
            Assert.Contains(function.Diagnostics, d => d.Severity == Severity.Warning && d.Message.Contains("was ambiguous"));
        }

        [WindowsFact]
        public void WarnOnAmbiguousSymbols_NoWarningWhenSameImport()
        {
            LinkImportsTransformation transformation = new()
            {
                WarnOnAmbiguousSymbols = true
            };

            // We don't want a warning when two libraries specify the same import
            // (IE: If two import libraries say 'TestFunction' should come from the same DLL)
            // To simulate, we just clone the generated library and import it the clone.
            CreateImportLib(transformation, nameof(WarnOnAmbiguousSymbols_NoWarningWhenSameImport), "TestFunction");

            string cloneFileName = $"{nameof(WarnOnAmbiguousSymbols_NoWarningWhenSameImport)}_Clone.lib";
            File.Copy($"{nameof(WarnOnAmbiguousSymbols_NoWarningWhenSameImport)}.lib", cloneFileName, overwrite: true);
            transformation.AddLibrary(cloneFileName);

            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Equal($"{nameof(WarnOnAmbiguousSymbols_NoWarningWhenSameImport)}.dll", function.DllFileName);
            Assert.Equal("TestFunction", function.MangledName);
            Assert.DoesNotContain(function.Diagnostics, d => d.Severity == Severity.Warning && d.Message.Contains("was ambiguous"));
            Assert.Empty(function.Diagnostics);
        }

        [WindowsFact]
        public void ErrorOnMissing_False()
        {
            LinkImportsTransformation transformation = new()
            {
                ErrorOnMissing = false
            };

            CreateImportLib(transformation, nameof(ErrorOnMissing_False), "UnrelatedFunction");
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.NotEqual($"{nameof(ErrorOnMissing_False)}.dll", function.DllFileName);
            Assert.Empty(function.Diagnostics);
        }

        [WindowsFact]
        public void ErrorOnMissing_True()
        {
            LinkImportsTransformation transformation = new()
            {
                ErrorOnMissing = true
            };

            CreateImportLib(transformation, nameof(ErrorOnMissing_True), "UnrelatedFunction");
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.NotEqual($"{nameof(ErrorOnMissing_True)}.dll", function.DllFileName);
            Assert.Contains(function.Diagnostics, d => d.Severity == Severity.Error && d.Message.Contains("Could not resolve"));
        }

        [WindowsFact]
        public void SymbolResolvesToExport()
        {
            // Create static library
            string cFileName = $"{nameof(SymbolResolvesToExport)}.c";
            string libFileName = $"{nameof(SymbolResolvesToExport)}.lib";
            File.WriteAllText(cFileName, "void TestFunction() { }");
            MsvcTools.Cl("/nologo", "/c", cFileName);
            MsvcTools.Lib("/NOLOGO", $"/OUT:{libFileName}", $"{nameof(SymbolResolvesToExport)}.obj");

            // Create and transform library
            LinkImportsTransformation transformation = new() { ErrorOnMissing = false };
            transformation.AddLibrary(libFileName);
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.NotEqual(nameof(SymbolResolvesToExport), function.DllFileName);
            Assert.Contains(function.Diagnostics, d => d.Severity == Severity.Warning && d.Message.Contains("No import sources found"));
        }

        [WindowsFact]
        public void SymbolResolvesToExport_ErrorOnMissing()
        {
            // Create static library
            string cFileName = $"{nameof(SymbolResolvesToExport_ErrorOnMissing)}.c";
            string libFileName = $"{nameof(SymbolResolvesToExport_ErrorOnMissing)}.lib";
            File.WriteAllText(cFileName, "void TestFunction() { }");
            MsvcTools.Cl("/nologo", "/c", cFileName);
            MsvcTools.Lib("/NOLOGO", $"/OUT:{libFileName}", $"{nameof(SymbolResolvesToExport_ErrorOnMissing)}.obj");

            // Create and transform library
            LinkImportsTransformation transformation = new() { ErrorOnMissing = true };
            transformation.AddLibrary(libFileName);
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.DoesNotContain(nameof(SymbolResolvesToExport_ErrorOnMissing), function.DllFileName);
            Assert.Contains(function.Diagnostics, d => d.Severity == Severity.Error && d.Message.Contains("No import sources found"));
        }

        [WindowsFact]
        public void CodeResolvesToDataSymbol()
        {
            LinkImportsTransformation transformation = new();
            CreateImportLib(transformation, nameof(CodeResolvesToDataSymbol), "TestFunction,DATA");
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Equal($"{nameof(CodeResolvesToDataSymbol)}.dll", function.DllFileName);
            Assert.Equal("TestFunction", function.MangledName);
            Assert.Contains(function.Diagnostics, d => d.Severity == Severity.Warning && d.Message.Contains("resolved to non-code symbol"));
        }

        [WindowsFact]
        public void DataResolvesToCodeSymbol()
        {
            LinkImportsTransformation transformation = new();
            CreateImportLib(transformation, nameof(DataResolvesToCodeSymbol), "TestGlobal");
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" int TestGlobal;");
            library = transformation.Transform(library);

            TranslatedStaticField staticField = library.FindDeclaration<TranslatedStaticField>("TestGlobal");
            Assert.Equal($"{nameof(DataResolvesToCodeSymbol)}.dll", staticField.DllFileName);
            Assert.Equal("TestGlobal", staticField.MangledName);
            Assert.Contains(staticField.Diagnostics, d => d.Severity == Severity.Warning && d.Message.Contains("resolved to a code symbol"));
        }

        [WindowsFact]
        public void TrackVerboseImportInformation_False()
        {
            LinkImportsTransformation transformation = new()
            {
                WarnOnAmbiguousSymbols = true,
                TrackVerboseImportInformation = false
            };

            CreateImportLib(transformation, $"{nameof(TrackVerboseImportInformation_False)}_0", "TestFunction");
            CreateImportLib(transformation, $"{nameof(TrackVerboseImportInformation_False)}_1", "TestFunction");
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Equal($"{nameof(TrackVerboseImportInformation_False)}_0.dll", function.DllFileName);
            Assert.Equal("TestFunction", function.MangledName);

            Assert.Single(function.Diagnostics);
            TranslationDiagnostic diagnostic = function.Diagnostics[0];
            Assert.Equal(Severity.Warning, diagnostic.Severity);
            Assert.Contains("was ambiguous", diagnostic.Message);
            Assert.DoesNotContain($"{nameof(TrackVerboseImportInformation_False)}_0.lib", diagnostic.Message);
            Assert.DoesNotContain($"{nameof(TrackVerboseImportInformation_False)}_1.lib", diagnostic.Message);
        }

        [WindowsFact]
        public void TrackVerboseImportInformation_True()
        {
            LinkImportsTransformation transformation = new()
            {
                WarnOnAmbiguousSymbols = true,
                TrackVerboseImportInformation = true
            };

            CreateImportLib(transformation, $"{nameof(TrackVerboseImportInformation_True)}_0", "TestFunction");
            CreateImportLib(transformation, $"{nameof(TrackVerboseImportInformation_True)}_1", "TestFunction");
            TranslatedLibrary library = CreateLibrary(@"extern ""C"" void TestFunction();");
            library = transformation.Transform(library);

            TranslatedFunction function = library.FindDeclaration<TranslatedFunction>("TestFunction");
            Assert.Equal($"{nameof(TrackVerboseImportInformation_True)}_0.dll", function.DllFileName);
            Assert.Equal("TestFunction", function.MangledName);

            Assert.Single(function.Diagnostics);
            TranslationDiagnostic diagnostic = function.Diagnostics[0];
            Assert.Equal(Severity.Warning, diagnostic.Severity);
            Assert.Contains("was ambiguous", diagnostic.Message);
            Assert.Contains($"{nameof(TrackVerboseImportInformation_True)}_0.lib", diagnostic.Message);
            Assert.Contains($"{nameof(TrackVerboseImportInformation_True)}_1.lib", diagnostic.Message);
        }

        [WindowsFact]
        public void TrackVerboseImportInformation_MustBeSetBeforeAddingAnyLibraries()
        {
            LinkImportsTransformation transformation = new();
            CreateImportLib(transformation, nameof(TrackVerboseImportInformation_MustBeSetBeforeAddingAnyLibraries), "TestFunction");
            Assert.Throws<InvalidOperationException>(() => transformation.TrackVerboseImportInformation = true);
        }

        [WindowsFact]
        [RelatedIssue("https://github.com/InfectedLibraries/Biohazrd/issues/136")]
        public void VirtualMethod_NoErrorOnMissing()
        {
            LinkImportsTransformation transformation = new()
            {
                ErrorOnMissing = true
            };

            TranslatedLibrary library = CreateLibrary(@"
class Test
{
public:
    virtual void VirtualMethod();
};
"
            );

            TranslatedFunction methodBeforeTransformation = library.FindDeclaration<TranslatedRecord>("Test").FindDeclaration<TranslatedFunction>("VirtualMethod");
            library = transformation.Transform(library);
            TranslatedFunction methodAfterTransformation = library.FindDeclaration<TranslatedRecord>("Test").FindDeclaration<TranslatedFunction>("VirtualMethod");

            Assert.ReferenceEqual(methodBeforeTransformation, methodAfterTransformation);
        }

        [WindowsFact]
        [RelatedIssue("https://github.com/InfectedLibraries/Biohazrd/issues/136")]
        public void VirtualMethod_ErrorOnMissing()
        {
            LinkImportsTransformation transformation = new()
            {
                ErrorOnMissing = true,
                ErrorOnMissingVirtualMethods = true
            };

            TranslatedLibrary library = CreateLibrary(@"
class Test
{
public:
    virtual void VirtualMethod();
};
"
            );

            library = transformation.Transform(library);
            TranslatedFunction virtualMethod = library.FindDeclaration<TranslatedRecord>("Test").FindDeclaration<TranslatedFunction>("VirtualMethod");
            Assert.Contains(virtualMethod.Diagnostics, d => d.IsError && d.Message.Contains("Could not resolve"));
        }
    }
}
