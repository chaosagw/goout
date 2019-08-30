<?xml version="1.0"?>
<doc>
    <assembly>
        <name>dnSpy.Decompiler.ILSpy.Core</name>
    </assembly>
    <members>
        <member name="T:dnSpy.Decompiler.ILSpy.Core.CSharp.AstBuilderState">
            <summary>
            State for one decompiler thread. There should be at most one of these per CPU. This class
            is not thread safe and must only be accessed by the owner thread.
            </summary>
        </member>
        <member name="F:dnSpy.Decompiler.ILSpy.Core.CSharp.AstBuilderState.XmlDoc_StringBuilder">
            <summary>
            <see cref="T:System.Text.StringBuilder"/> instance used by XML doc code. This is always in a random
            state (random text) and caller must Clear() it before use.
            </summary>
        </member>
        <member name="M:dnSpy.Decompiler.ILSpy.Core.CSharp.AstBuilderState.Reset">
            <summary>
            Called to re-use this instance for another decompilation. Only the fields that need
            resetting will be reset.
            </summary>
        </member>
        <member name="T:dnSpy.Decompiler.ILSpy.Core.CSharp.BuilderCache">
            <summary>
            One instance is created and stored in <see cref="T:dnSpy.Contracts.Decompiler.DecompilationContext"/>. It's used by the
            decompiler threads to get an <see cref="T:dnSpy.Decompiler.ILSpy.Core.CSharp.AstBuilderState"/> instance.
            </summary>
        </member>
        <member name="T:dnSpy.Decompiler.ILSpy.Core.CSharp.BuilderState">
            <summary>
            Gets the <see cref="T:dnSpy.Decompiler.ILSpy.Core.CSharp.AstBuilderState"/> from the pool and returns it when <see cref="M:dnSpy.Decompiler.ILSpy.Core.CSharp.BuilderState.Dispose"/>
            gets called.
            </summary>
        </member>
        <member name="T:dnSpy.Decompiler.ILSpy.Core.CSharp.CSharpDecompiler">
            <summary>
            Decompiler logic for C#.
            </summary>
        </member>
        <member name="T:dnSpy.Decompiler.ILSpy.Core.CSharp.CSharpDecompiler.SelectFieldTransform">
            <summary>
            Removes all top-level members except for the specified fields.
            </summary>
        </member>
        <member name="T:dnSpy.Decompiler.ILSpy.Core.IL.ILDecompiler">
            <summary>
            IL language support.
            </summary>
            <remarks>
            Currently comes in two versions:
            flat IL (detectControlStructure=false) and structured IL (detectControlStructure=true).
            </remarks>
        </member>
        <member name="T:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources">
            <summary>
              A strongly-typed resource class, for looking up localized strings, etc.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.ResourceManager">
            <summary>
              Returns the cached ResourceManager instance used by this class.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.Culture">
            <summary>
              Overrides the current thread's CurrentUICulture property for all
              resource lookups using this strongly typed resource class.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_AddUsingDeclarations">
            <summary>
              Looks up a localized string similar to Add using declarations.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_AllowFieldInitializers">
            <summary>
              Looks up a localized string similar to Allow field initializers.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject">
            <summary>
              Looks up a localized string similar to Always generate exception variables in catch blocks unless type is Object.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompilationOrder">
            <summary>
              Looks up a localized string similar to Decompilation order.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileAnonMethods">
            <summary>
              Looks up a localized string similar to Decompile anonymous methods/lambdas.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileAsyncMethods">
            <summary>
              Looks up a localized string similar to Decompile async methods (async/await).
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileAutoEvents">
            <summary>
              Looks up a localized string similar to Decompile automatic events.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileAutoProps">
            <summary>
              Looks up a localized string similar to Decompile automatic properties.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileEnumerators">
            <summary>
              Looks up a localized string similar to Decompile enumerators (yield return).
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileExprTrees">
            <summary>
              Looks up a localized string similar to Decompile expression trees.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileForeachStatements">
            <summary>
              Looks up a localized string similar to Decompile foreach statements.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileLockStatements">
            <summary>
              Looks up a localized string similar to Decompile lock statements.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileQueryExpr">
            <summary>
              Looks up a localized string similar to Decompile query expressions.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileSwitchOnString">
            <summary>
              Looks up a localized string similar to Decompile switch on string.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileUsingStatements">
            <summary>
              Looks up a localized string similar to Decompile using statements.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_FullyQualifyAllTypes">
            <summary>
              Looks up a localized string similar to Add namespaces to all types.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_FullyQualifyAmbiguousTypeNames">
            <summary>
              Looks up a localized string similar to Add a namespace to types with the same name.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_IntroduceIncrementAndDecrement">
            <summary>
              Looks up a localized string similar to Use increment and decrement operators.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_MakeAssignmentExpressions">
            <summary>
              Looks up a localized string similar to Use assignment expressions such as in while ((count = Do()) != 0) ;.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_MaxArrayElements">
            <summary>
              Looks up a localized string similar to Max number of array elements to show.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_MemberAddPrivateModifier">
            <summary>
              Looks up a localized string similar to Add &apos;private&apos; modifier to type members.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ObjectOrCollectionInitializers">
            <summary>
              Looks up a localized string similar to Decompile object or collection initializers.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_OneCustomAttributePerLine">
            <summary>
              Looks up a localized string similar to Show one custom attribute per line.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_RemoveEmptyDefaultCtors">
            <summary>
              Looks up a localized string similar to Remove empty default constructors.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_RemoveNewDelegateClass">
            <summary>
              Looks up a localized string similar to Replace &apos;new delegate-class(xxx)&apos; with &apos;xxx&apos;.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowCompilerGeneratedTypes">
            <summary>
              Looks up a localized string similar to Show hidden compiler generated types and methods.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowILComments">
            <summary>
              Looks up a localized string similar to Show IL opcode comments.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowILInstrBytes">
            <summary>
              Looks up a localized string similar to Show IL instruction bytes.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowPdbInfo">
            <summary>
              Looks up a localized string similar to Show line numbers and filenames if available.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowTokensRvasOffsets">
            <summary>
              Looks up a localized string similar to Show tokens, RVAs and file offsets.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowXMLDocComments">
            <summary>
              Looks up a localized string similar to Show XML documentation in decompiled code.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_SortCustomAttributes">
            <summary>
              Looks up a localized string similar to Sort custom attributes.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_SortMethods">
            <summary>
              Looks up a localized string similar to Sort methods, fields, properties, events and types.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_SortSystemFirst">
            <summary>
              Looks up a localized string similar to Place &apos;System&apos; directives first when sorting usings.
            </summary>
        </member>
        <member name="P:dnSpy.Decompiler.ILSpy.Core.Properties.dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_TypeAddInternalModifier">
            <summary>
              Looks up a localized string similar to Add &apos