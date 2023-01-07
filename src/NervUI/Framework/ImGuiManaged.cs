using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Mochi.DearImGui;
using Mochi.DearImGui.Internal;
using OpenTK.Graphics.OpenGL;
using Vector2 = OpenTK.Mathematics.Vector2;

namespace NervUI;

public class ImGuiManaged
{
    #if false
    //Disabled
    public unsafe static void Image(NervImage image)
    {
        if (image == null)
            return;
        GL.BindTexture(TextureTarget.Texture2D, image.texture);
        
        ImGui.Image((void*)image.texture, new System.Numerics.Vector2(image.Width, image.Height),
            new System.Numerics.Vector2(), new System.Numerics.Vector2(1, 1), new Vector4(1, 1, 1, 1), new Vector4());
    }
#endif

    public static unsafe void TextWrapped(string fmt)
    {
        byte* native_fmt;
        int fmt_byteCount = 0;
        if (fmt != null)
        {
            fmt_byteCount = Encoding.UTF8.GetByteCount(fmt);
            if (fmt_byteCount > Util.StackAllocationSizeLimit)
            {
                native_fmt = Util.Allocate(fmt_byteCount + 1);
            }
            else
            {
                byte* native_fmt_stackBytes = stackalloc byte[fmt_byteCount + 1];
                native_fmt = native_fmt_stackBytes;
            }
            int native_fmt_offset = Util.GetUtf8(fmt, native_fmt, fmt_byteCount);
            native_fmt[native_fmt_offset] = 0;
        }
        else { native_fmt = null; }
        ImGui.TextWrapped(fmt);
        if (fmt_byteCount > Util.StackAllocationSizeLimit)
        {
            Util.Free(native_fmt);
        }
    }
    
    public static unsafe void TextColored(Vector4 col, string fmt)
    {
        byte* native_fmt;
        int fmt_byteCount = 0;
        if (fmt != null)
        {
            fmt_byteCount = Encoding.UTF8.GetByteCount(fmt);
            if (fmt_byteCount > Util.StackAllocationSizeLimit)
            {
                native_fmt = Util.Allocate(fmt_byteCount + 1);
            }
            else
            {
                byte* native_fmt_stackBytes = stackalloc byte[fmt_byteCount + 1];
                native_fmt = native_fmt_stackBytes;
            }
            int native_fmt_offset = Util.GetUtf8(fmt, native_fmt, fmt_byteCount);
            native_fmt[native_fmt_offset] = 0;
        }
        else { native_fmt = null; }
        ImGui.TextColored(col, native_fmt);
        if (fmt_byteCount > Util.StackAllocationSizeLimit)
        {
            Util.Free(native_fmt);
        }
    }
    
    public static bool MenuItem(string label, string shortcut)
    {
        unsafe
        {
            byte* native_label;
            var label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    var native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }

                var native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else
            {
                native_label = null;
            }

            byte* native_shortcut;
            var shortcut_byteCount = 0;
            if (shortcut != null)
            {
                shortcut_byteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcut_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_shortcut = Util.Allocate(shortcut_byteCount + 1);
                }
                else
                {
                    var native_shortcut_stackBytes = stackalloc byte[shortcut_byteCount + 1];
                    native_shortcut = native_shortcut_stackBytes;
                }

                var native_shortcut_offset = Util.GetUtf8(shortcut, native_shortcut, shortcut_byteCount);
                native_shortcut[native_shortcut_offset] = 0;
            }
            else
            {
                native_shortcut = null;
            }

            byte selected = 0;
            byte enabled = 1;
            var result = ImGui.MenuItem(native_label, native_shortcut);
            if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
            if (shortcut_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_shortcut);
            return result;
        }
    }

    public static bool MenuItem(string label, string shortcut, bool selected)
    {
        unsafe
        {
            byte* native_label;
            var label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    var native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }

                var native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else
            {
                native_label = null;
            }

            byte* native_shortcut;
            var shortcut_byteCount = 0;
            if (shortcut != null)
            {
                shortcut_byteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcut_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_shortcut = Util.Allocate(shortcut_byteCount + 1);
                }
                else
                {
                    var native_shortcut_stackBytes = stackalloc byte[shortcut_byteCount + 1];
                    native_shortcut = native_shortcut_stackBytes;
                }

                var native_shortcut_offset = Util.GetUtf8(shortcut, native_shortcut, shortcut_byteCount);
                native_shortcut[native_shortcut_offset] = 0;
            }
            else
            {
                native_shortcut = null;
            }

            var native_selected = selected ? (byte)1 : (byte)0;
            byte enabled = 1;
            var result = ImGui.MenuItem(native_label, native_shortcut, selected);
            if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
            if (shortcut_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_shortcut);
            return result;
        }
    }

    public static bool MenuItem(string label, string shortcut, bool selected, bool enabled)
    {
        unsafe
        {
            byte* native_label;
            var label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    var native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }

                var native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else
            {
                native_label = null;
            }

            byte* native_shortcut;
            var shortcut_byteCount = 0;
            if (shortcut != null)
            {
                shortcut_byteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcut_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_shortcut = Util.Allocate(shortcut_byteCount + 1);
                }
                else
                {
                    var native_shortcut_stackBytes = stackalloc byte[shortcut_byteCount + 1];
                    native_shortcut = native_shortcut_stackBytes;
                }

                var native_shortcut_offset = Util.GetUtf8(shortcut, native_shortcut, shortcut_byteCount);
                native_shortcut[native_shortcut_offset] = 0;
            }
            else
            {
                native_shortcut = null;
            }

            var native_selected = selected ? (byte)1 : (byte)0;
            var native_enabled = enabled ? (byte)1 : (byte)0;
            var result = ImGui.MenuItem(native_label, native_shortcut, selected, enabled);
            if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
            if (shortcut_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_shortcut);
            return result;
        }
    }

    public static bool MenuItem(string label, string shortcut, ref bool p_selected)
    {
        unsafe
        {
            byte* native_label;
            var label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    var native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }

                var native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else
            {
                native_label = null;
            }

            byte* native_shortcut;
            var shortcut_byteCount = 0;
            if (shortcut != null)
            {
                shortcut_byteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcut_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_shortcut = Util.Allocate(shortcut_byteCount + 1);
                }
                else
                {
                    var native_shortcut_stackBytes = stackalloc byte[shortcut_byteCount + 1];
                    native_shortcut = native_shortcut_stackBytes;
                }

                var native_shortcut_offset = Util.GetUtf8(shortcut, native_shortcut, shortcut_byteCount);
                native_shortcut[native_shortcut_offset] = 0;
            }
            else
            {
                native_shortcut = null;
            }

            var native_p_selected_val = p_selected ? (byte)1 : (byte)0;
            //var native_p_selected = &native_p_selected_val;
            byte enabled = 1;
            //        public static bool MenuItem(byte* label, byte* shortcut, bool* p_selected, bool enabled = true)
            //NOT SURE IF THIS WORKS
            bool hi = p_selected;
            bool* test = &hi;
            var result = ImGui.MenuItem(native_label, native_shortcut, test);
            if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
            if (shortcut_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_shortcut);
            p_selected = native_p_selected_val != 0;
            return result;
        }
    }

    public static bool MenuItem(string label, string shortcut, ref bool p_selected, bool enabled)
    {
        unsafe
        {
            byte* native_label;
            var label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    var native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }

                var native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else
            {
                native_label = null;
            }

            byte* native_shortcut;
            var shortcut_byteCount = 0;
            if (shortcut != null)
            {
                shortcut_byteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcut_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_shortcut = Util.Allocate(shortcut_byteCount + 1);
                }
                else
                {
                    var native_shortcut_stackBytes = stackalloc byte[shortcut_byteCount + 1];
                    native_shortcut = native_shortcut_stackBytes;
                }

                var native_shortcut_offset = Util.GetUtf8(shortcut, native_shortcut, shortcut_byteCount);
                native_shortcut[native_shortcut_offset] = 0;
            }
            else
            {
                native_shortcut = null;
            }
            
            var native_p_selected_val = p_selected ? (byte)1 : (byte)0;
            var native_p_selected = &native_p_selected_val;
            var native_enabled = enabled ? (byte)1 : (byte)0;
            bool hi = p_selected;
            bool* test = &hi;
            var result = ImGui.MenuItem(native_label, native_shortcut, test, enabled);
            if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
            if (shortcut_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_shortcut);
            p_selected = native_p_selected_val != 0;
            return result;
        }
    }
    
    
    public static unsafe bool Selectable(string label)
        {
            byte* native_label;
            int label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    byte* native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }
                int native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else { native_label = null; }
            ImGuiSelectableFlags flags = (ImGuiSelectableFlags)0;
            Vector2 size = new Vector2();
            var result = ImGui.Selectable(native_label, false, flags,
                new System.Numerics.Vector2(size.X, size.Y));
            if (label_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_label);
            }

            return result;
        }
        public static unsafe bool Selectable(string label, bool selected)
        {
            byte* native_label;
            int label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    byte* native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }
                int native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else { native_label = null; }
            byte native_selected = selected ? (byte)1 : (byte)0;
            ImGuiSelectableFlags flags = (ImGuiSelectableFlags)0;
            Vector2 size = new Vector2();
            var result = ImGui.Selectable(native_label, selected, flags,
                new System.Numerics.Vector2(size.X, size.Y));
            if (label_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_label);
            }

            return result;
        }
        public static unsafe bool Selectable(string label, bool selected, ImGuiSelectableFlags flags)
        {
            byte* native_label;
            int label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    byte* native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }
                int native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else { native_label = null; }
            byte native_selected = selected ? (byte)1 : (byte)0;
            Vector2 size = new Vector2();
            var result = ImGui.Selectable(native_label, selected, flags,
                new System.Numerics.Vector2(size.X, size.Y));
            if (label_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_label);
            }
            return result;
        }
        public static unsafe bool Selectable(string label, bool selected, ImGuiSelectableFlags flags, Vector2 size)
        {
            byte* native_label;
            int label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    byte* native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }
                int native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else { native_label = null; }
            byte native_selected = selected ? (byte)1 : (byte)0;
            var result = ImGui.Selectable(native_label, selected, flags,
                new System.Numerics.Vector2(size.X, size.Y));
            if (label_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_label);
            }

            return result;
        }
        public static unsafe bool Selectable(string label, ref bool p_selected)
        {
            byte* native_label;
            int label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    byte* native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }
                int native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else { native_label = null; }
            byte native_p_selected_val = p_selected ? (byte)1 : (byte)0;
            byte* native_p_selected = &native_p_selected_val;
            ImGuiSelectableFlags flags = (ImGuiSelectableFlags)0;
            Vector2 size = new Vector2();
            bool ok = p_selected;
            bool* test = &ok;
            var result = ImGui.Selectable(native_label, test, flags,
                new System.Numerics.Vector2(size.X, size.Y));
            if (label_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_label);
            }
            p_selected = native_p_selected_val != 0;
            return result;
        }
        public static unsafe bool Selectable(string label, ref bool p_selected, ImGuiSelectableFlags flags)
        {
            byte* native_label;
            int label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    byte* native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }
                int native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else { native_label = null; }
            byte native_p_selected_val = p_selected ? (byte)1 : (byte)0;
            byte* native_p_selected = &native_p_selected_val;
            Vector2 size = new Vector2();
            bool ok = p_selected;
            bool* test = &ok;
            var result = ImGui.Selectable(native_label, test, flags,
                new System.Numerics.Vector2(size.X, size.Y));
            if (label_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_label);
            }
            p_selected = native_p_selected_val != 0;
            return result;
        }
        public static unsafe bool Selectable(string label, ref bool p_selected, ImGuiSelectableFlags flags, Vector2 size)
        {
            byte* native_label;
            int label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    byte* native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }
                int native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else { native_label = null; }
            byte native_p_selected_val = p_selected ? (byte)1 : (byte)0;
            byte* native_p_selected = &native_p_selected_val;
            bool ok = p_selected;
            bool* test = &ok;
            var result = ImGui.Selectable(native_label, test, flags,
                new System.Numerics.Vector2(size.X, size.Y));
            if (label_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_label);
            }
            p_selected = native_p_selected_val != 0;
            return result;
        }

    public static unsafe bool InputText(string label, ref string input, uint maxLength,
        ImGuiInputTextFlags flags = ImGuiInputTextFlags.None,
        delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback = null, void* user_data = null)
    {
        var utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
        byte* utf8LabelBytes;
        if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
        {
            utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
        }
        else
        {
            var stackPtr = stackalloc byte[utf8LabelByteCount + 1];
            utf8LabelBytes = stackPtr;
        }

        Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

        var utf8InputByteCount = Encoding.UTF8.GetByteCount(input);
        var inputBufSize = Math.Max((int)maxLength + 1, utf8InputByteCount + 1);

        byte* utf8InputBytes;
        byte* originalUtf8InputBytes;
        if (inputBufSize > Util.StackAllocationSizeLimit)
        {
            utf8InputBytes = Util.Allocate(inputBufSize);
            originalUtf8InputBytes = Util.Allocate(inputBufSize);
        }
        else
        {
            var inputStackBytes = stackalloc byte[inputBufSize];
            utf8InputBytes = inputStackBytes;
            var originalInputStackBytes = stackalloc byte[inputBufSize];
            originalUtf8InputBytes = originalInputStackBytes;
        }

        Util.GetUtf8(input, utf8InputBytes, inputBufSize);
        var clearBytesCount = (uint)(inputBufSize - utf8InputByteCount);
        Unsafe.InitBlockUnaligned(utf8InputBytes + utf8InputByteCount, 0, clearBytesCount);
        Unsafe.CopyBlock(originalUtf8InputBytes, utf8InputBytes, (uint)inputBufSize);

        var result = ImGui.InputText(utf8LabelBytes, utf8InputBytes, (nuint)inputBufSize, flags, callback, user_data);

        if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, utf8InputBytes))
            input = Util.StringFromPtr(utf8InputBytes);

        if (utf8LabelByteCount > Util.StackAllocationSizeLimit) Util.Free(utf8LabelBytes);
        if (inputBufSize > Util.StackAllocationSizeLimit)
        {
            Util.Free(utf8InputBytes);
            Util.Free(originalUtf8InputBytes);
        }

        return result;
    }

    public static unsafe bool InputTextMultiLine(string label, ref string input, uint maxLength, Vector2 size,
        ImGuiInputTextFlags flags = ImGuiInputTextFlags.None,
        delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback = null, void* user_data = null)
    {
        var utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
        byte* utf8LabelBytes;
        if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
        {
            utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
        }
        else
        {
            var stackPtr = stackalloc byte[utf8LabelByteCount + 1];
            utf8LabelBytes = stackPtr;
        }

        Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

        var utf8InputByteCount = Encoding.UTF8.GetByteCount(input);
        var inputBufSize = Math.Max((int)maxLength + 1, utf8InputByteCount + 1);

        byte* utf8InputBytes;
        byte* originalUtf8InputBytes;
        if (inputBufSize > Util.StackAllocationSizeLimit)
        {
            utf8InputBytes = Util.Allocate(inputBufSize);
            originalUtf8InputBytes = Util.Allocate(inputBufSize);
        }
        else
        {
            var inputStackBytes = stackalloc byte[inputBufSize];
            utf8InputBytes = inputStackBytes;
            var originalInputStackBytes = stackalloc byte[inputBufSize];
            originalUtf8InputBytes = originalInputStackBytes;
        }

        Util.GetUtf8(input, utf8InputBytes, inputBufSize);
        var clearBytesCount = (uint)(inputBufSize - utf8InputByteCount);
        Unsafe.InitBlockUnaligned(utf8InputBytes + utf8InputByteCount, 0, clearBytesCount);
        Unsafe.CopyBlock(originalUtf8InputBytes, utf8InputBytes, (uint)inputBufSize);

        var result = ImGui.InputTextMultiline(utf8LabelBytes, utf8InputBytes, (nuint)inputBufSize,
            new System.Numerics.Vector2(size.X, size.Y), flags, callback, user_data);

        if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, utf8InputBytes))
            input = Util.StringFromPtr(utf8InputBytes);

        if (utf8LabelByteCount > Util.StackAllocationSizeLimit) Util.Free(utf8LabelBytes);
        if (inputBufSize > Util.StackAllocationSizeLimit)
        {
            Util.Free(utf8InputBytes);
            Util.Free(originalUtf8InputBytes);
        }

        return result;
    }

    public static unsafe bool InputTextWithHint(string label, string hint, ref string input, uint maxLength,
        ImGuiInputTextFlags flags = ImGuiInputTextFlags.None,
        delegate* unmanaged[Cdecl]<ImGuiInputTextCallbackData*, int> callback = null, void* user_data = null)
    {
        var utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
        byte* utf8LabelBytes;
        if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
        {
            utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
        }
        else
        {
            var stackPtr = stackalloc byte[utf8LabelByteCount + 1];
            utf8LabelBytes = stackPtr;
        }

        Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

        var utf8HintByteCount = Encoding.UTF8.GetByteCount(hint);
        byte* utf8HintBytes;
        if (utf8HintByteCount > Util.StackAllocationSizeLimit)
        {
            utf8HintBytes = Util.Allocate(utf8HintByteCount + 1);
        }
        else
        {
            var stackPtr = stackalloc byte[utf8HintByteCount + 1];
            utf8HintBytes = stackPtr;
        }

        Util.GetUtf8(hint, utf8HintBytes, utf8HintByteCount);

        var utf8InputByteCount = Encoding.UTF8.GetByteCount(input);
        var inputBufSize = Math.Max((int)maxLength + 1, utf8InputByteCount + 1);

        byte* utf8InputBytes;
        byte* originalUtf8InputBytes;
        if (inputBufSize > Util.StackAllocationSizeLimit)
        {
            utf8InputBytes = Util.Allocate(inputBufSize);
            originalUtf8InputBytes = Util.Allocate(inputBufSize);
        }
        else
        {
            var inputStackBytes = stackalloc byte[inputBufSize];
            utf8InputBytes = inputStackBytes;
            var originalInputStackBytes = stackalloc byte[inputBufSize];
            originalUtf8InputBytes = originalInputStackBytes;
        }

        Util.GetUtf8(input, utf8InputBytes, inputBufSize);
        var clearBytesCount = (uint)(inputBufSize - utf8InputByteCount);
        Unsafe.InitBlockUnaligned(utf8InputBytes + utf8InputByteCount, 0, clearBytesCount);
        Unsafe.CopyBlock(originalUtf8InputBytes, utf8InputBytes, (uint)inputBufSize);

        var result = ImGui.InputTextWithHint(utf8LabelBytes, utf8HintBytes, utf8InputBytes, (nuint)inputBufSize,
            flags, callback, user_data);

        if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, utf8InputBytes))
            input = Util.StringFromPtr(utf8InputBytes);

        if (utf8LabelByteCount > Util.StackAllocationSizeLimit) Util.Free(utf8LabelBytes);
        if (utf8HintByteCount > Util.StackAllocationSizeLimit) Util.Free(utf8HintBytes);
        if (inputBufSize > Util.StackAllocationSizeLimit)
        {
            Util.Free(utf8InputBytes);
            Util.Free(originalUtf8InputBytes);
        }

        return result;
    }
    
    //From https://github.com/ocornut/imgui/issues/1901 and for some reason it's not working
    #if false
    public static unsafe void BufferingBar(string label, float value, Vector2 size_arg, uint bg_col, uint fg_col)
    {
        ImGuiWindow* window = ImGuiInternal.GetCurrentWindow();
        if (!window->SkipItems)
        {
            ImGuiContext* g = *ImGuiInternal.GImGui;
            ImGuiStyle style = g->Style;
            var id = window->GetID(label);

            var pos = window->DC.CursorPos;
            var size = size_arg;
            size.X -= style.FramePadding.X * 2;
        
            ImRect bb = new ImRect(pos, new System.Numerics.Vector2(pos.X + size.X, pos.Y + size.Y));
            ImGuiInternal.ItemSize(bb, style.FramePadding.Y);
            if (ImGuiInternal.ItemAdd(bb, id))
            {
                // Render
                float circleStart = size.X * 0.7f;
                float circleEnd = size.X;
                float circleWidth = circleEnd - circleStart;
        
                window->DrawList->AddRectFilled(bb.Min, new System.Numerics.Vector2(pos.X + circleStart, bb.Max.Y), bg_col);
                window->DrawList->AddRectFilled(bb.Min, new System.Numerics.Vector2(pos.X + circleStart*value, bb.Max.Y), fg_col);
        
                float t = (float)g->Time;
                float r = size.Y / 2;
                const float speed = 1.5f;
        
                const float a = speed*0;
                const float b = speed*0.333f;
                const float c = speed*0.666f;
        
                float o1 = (circleWidth+r) * (t+a - speed * (int)((t+a) / speed)) / speed;
                float o2 = (circleWidth+r) * (t+b - speed * (int)((t+b) / speed)) / speed;
                float o3 = (circleWidth+r) * (t+c - speed * (int)((t+c) / speed)) / speed;
        
                window->DrawList->AddCircleFilled(new System.Numerics.Vector2(pos.X + circleEnd - o1, bb.Min.Y + r), r, bg_col);
                window->DrawList->AddCircleFilled(new (pos.X + circleEnd - o2, bb.Min.Y + r), r, bg_col);
                window->DrawList->AddCircleFilled(new (pos.X + circleEnd - o3, bb.Min.Y + r), r, bg_col);
            }
        }
    }
    #endif
}