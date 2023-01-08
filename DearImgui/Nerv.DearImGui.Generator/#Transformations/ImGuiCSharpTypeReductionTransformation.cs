﻿using Biohazrd;
using Biohazrd.CSharp;
using Biohazrd.Transformation;
using ClangSharp;
using ClangSharp.Interop;

namespace Nerv.DearImGui.Generator
{
    public class ImGuiCSharpTypeReductionTransformation : CSharpTypeReductionTransformation
    {
        protected override TypeTransformationResult TransformClangTypeReference(TypeTransformationContext context, ClangTypeReference type)
        {
            if (type.ClangType is TemplateSpecializationType templateSpecializationType
                && context.Library.FindClangCursor(templateSpecializationType.Handle.Declaration) is ClassTemplateSpecializationDecl templateSpecialization
                && templateSpecialization.Spelling == "ImVector")
            {
                if (templateSpecialization.TemplateArgs.Count != 1)
                {
                    TypeTransformationResult result = type;
                    result.AddDiagnostic(Severity.Error, "ImVector should have exactly one template argument.");
                    return result;
                }

                // Note: This ends up implicitly using the canonical types for template arguments, which eliminates typedefs.
                // (In particular, this is causing ImVector<ImWchar16> to translate as ImVector<ushort>.)
                // This is a quirk of how Clang processes templates. Ideally we should avoid looking up the ClassTemplateSpecializationDecl and use the arguments exposed on the
                // TemplateSpecializationType, but libclang nor ClangShapr expose this yet.
                // See https://github.com/MochiLibraries/Biohazrd/issues/178 for detials.
                TemplateArgument elementType = templateSpecialization.TemplateArgs[0];

                if (elementType.Kind != CXTemplateArgumentKind.CXTemplateArgumentKind_Type)
                {
                    TypeTransformationResult result = type;
                    result.AddDiagnostic(Severity.Error, "ImVector's only template argument should be a type.");
                    return result;
                }

                return new ImVectorTypeReference(new ClangTypeReference(elementType.AsType));
            }
            else
            { return base.TransformClangTypeReference(context, type); }
        }
    }
}
