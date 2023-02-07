using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Mochi.DearImGui;
using Mochi.DearImGui.Internal;

namespace NervUI.Framework;

public class ImGuiManaged
{
    public static unsafe void TextWrapped(string fmt)
    {
        byte* native_fmt;
        var fmt_byteCount = 0;
        if (fmt != null)
        {
            fmt_byteCount = Encoding.UTF8.GetByteCount(fmt);
            if (fmt_byteCount > Util.StackAllocationSizeLimit)
            {
                native_fmt = Util.Allocate(fmt_byteCount + 1);
            }
            else
            {
                var native_fmt_stackBytes = stackalloc byte[fmt_byteCount + 1];
                native_fmt = native_fmt_stackBytes;
            }

            var native_fmt_offset = Util.GetUtf8(fmt, native_fmt, fmt_byteCount);
            native_fmt[native_fmt_offset] = 0;
        }
        else
        {
            native_fmt = null;
        }

        ImGui.TextWrapped(fmt);
        if (fmt_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_fmt);
    }

    public static unsafe bool Checkbox(string label, ref bool v)
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

        var test = v;
        var ret = ImGui.Checkbox(native_label, &test);
        if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
        v = test;
        return ret;
    }

    public static unsafe void TextColored(Vector4 col, string fmt)
    {
        byte* native_fmt;
        var fmt_byteCount = 0;
        if (fmt != null)
        {
            fmt_byteCount = Encoding.UTF8.GetByteCount(fmt);
            if (fmt_byteCount > Util.StackAllocationSizeLimit)
            {
                native_fmt = Util.Allocate(fmt_byteCount + 1);
            }
            else
            {
                var native_fmt_stackBytes = stackalloc byte[fmt_byteCount + 1];
                native_fmt = native_fmt_stackBytes;
            }

            var native_fmt_offset = Util.GetUtf8(fmt, native_fmt, fmt_byteCount);
            native_fmt[native_fmt_offset] = 0;
        }
        else
        {
            native_fmt = null;
        }

        ImGui.TextColored(col, native_fmt);
        if (fmt_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_fmt);
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
            var hi = p_selected;
            var test = &hi;
            var result = ImGui.MenuItem(native_label, native_shortcut, test);
            if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
            if (shortcut_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_shortcut);
            p_selected = native_p_selected_val != 0;
            return result;
        }
    }

    public static unsafe bool ListBox(string label, ref int current_item, string[] items, int items_count)
    {
        var result = false;
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

        var items_byteCounts = stackalloc int[items.Length];
        var items_byteCount = 0;
        for (var i = 0; i < items.Length; i++)
        {
            var s = items[i];
            items_byteCounts[i] = Encoding.UTF8.GetByteCount(s);
            items_byteCount += items_byteCounts[i] + 1;
        }

        var native_items_data = stackalloc byte[items_byteCount];
        var offset = 0;
        for (var i = 0; i < items.Length; i++)
        {
            var s = items[i];
            fixed (char* sPtr = s)
            {
                offset += Encoding.UTF8.GetBytes(sPtr, s.Length, native_items_data + offset, items_byteCounts[i]);
                native_items_data[offset] = 0;
                offset += 1;
            }
        }

        var native_items = stackalloc byte*[items.Length];
        offset = 0;
        for (var i = 0; i < items.Length; i++)
        {
            native_items[i] = &native_items_data[offset];
            offset += items_byteCounts[i] + 1;
        }

        var height_in_items = -1;
        fixed (int* native_current_item = &current_item)
        {
            result = ImGui.ListBox(native_label, native_current_item, native_items, items_count, height_in_items);
            if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
        }

        return result;
    }

    public static unsafe bool ListBox(string label, ref int current_item, string[] items, int items_count,
        int height_in_items)
    {
        var result = false;
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

        var items_byteCounts = stackalloc int[items.Length];
        var items_byteCount = 0;
        for (var i = 0; i < items.Length; i++)
        {
            var s = items[i];
            items_byteCounts[i] = Encoding.UTF8.GetByteCount(s);
            items_byteCount += items_byteCounts[i] + 1;
        }

        var native_items_data = stackalloc byte[items_byteCount];
        var offset = 0;
        for (var i = 0; i < items.Length; i++)
        {
            var s = items[i];
            fixed (char* sPtr = s)
            {
                offset += Encoding.UTF8.GetBytes(sPtr, s.Length, native_items_data + offset, items_byteCounts[i]);
                native_items_data[offset] = 0;
                offset += 1;
            }
        }

        var native_items = stackalloc byte*[items.Length];
        offset = 0;
        for (var i = 0; i < items.Length; i++)
        {
            native_items[i] = &native_items_data[offset];
            offset += items_byteCounts[i] + 1;
        }

        fixed (int* native_current_item = &current_item)
        {
            result = ImGui.ListBox(native_label, native_current_item, native_items, items_count, height_in_items);
            if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
        }

        return result;
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
            var hi = p_selected;
            var test = &hi;
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
        
        ImGuiSelectableFlags flags = 0;
        var size = new Vector2();
        bool ret = ImGui.Selectable(native_label, false, flags, size);
        if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
        return ret;
    }

    public static unsafe bool Selectable(string label, bool selected)
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
        
        ImGuiSelectableFlags flags = 0;
        var size = new Vector2();
        bool ret = ImGui.Selectable(native_label, selected, flags, size);
        if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
        return ret;
    }

    public static unsafe bool Selectable(string label, bool selected, ImGuiSelectableFlags flags)
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
        
        var size = new Vector2();
        bool ret = ImGui.Selectable(native_label, selected, flags, size);
        if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
        return ret;
    }

    public static unsafe bool Selectable(string label, bool selected, ImGuiSelectableFlags flags, Vector2 size)
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
        bool ret = ImGui.Selectable(native_label, selected, flags, size);
        if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
        return ret;
    }

    public static unsafe bool Selectable(string label, ref bool selected)
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
        ImGuiSelectableFlags flags = 0;
        var size = new Vector2();
        bool p_selected = selected;
        bool ret = ImGui.Selectable(native_label, &p_selected, flags, size);
        if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
        selected = p_selected;
        return ret;
    }

    public static unsafe bool Selectable(string label, ref bool selected, ImGuiSelectableFlags flags)
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
        
        var size = new Vector2();
        bool p_selected = selected;
        bool ret = ImGui.Selectable(native_label, &p_selected, flags, size);
        if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
        selected = p_selected;
        return ret;
    }

    public static unsafe bool Selectable(string label, ref bool selected, ImGuiSelectableFlags flags, Vector2 size)
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

        bool p_selected = selected;
        bool ret = ImGui.Selectable(native_label, &p_selected, flags, size);
        if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
        selected = p_selected;
        return ret;
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
            new Vector2(size.X, size.Y), flags, callback, user_data);

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

    public static unsafe bool TextEditor(string label, ref string text, uint maxLength, Vector2 size,
        ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
    {
        bool result;

        ImGui.PushStyleColor(ImGuiCol.FrameBg, Util.Vec_Color(44, 44, 44));

        ImGui.BeginChild($"{label}tec1", new Vector2(size.X, size.Y), false,
            ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse);
        {
            var numChildWidth = 6.7f * text.Split('\n').Length.ToString().ToCharArray().Length;
            ImGui.BeginChild($"{label}tec2", new Vector2(7f + numChildWidth, size.Y), false,
                ImGuiWindowFlags.NoScrollbar);
            {
                ImGui.PushStyleColor(ImGuiCol.Text, Util.Vec_Color(66, 135, 245));
                ImGui.SetScrollY(ImGui.GetScrollMaxY());
                ImGui.BeginGroup();
                ImGui.Spacing();

                var linesText = "0\n";
                for (var i = 1; i < text.Split('\n').Length; i++)
                    linesText += $"{i}\n";


                ImGui.SameLine(2.5f);

                ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 2);
                ImGui.SetCursorPosX(ImGui.GetCursorPosX() + 2);
                ImGui.Text(linesText); //TODO Fix crash issue with loading large or file with alot lines

                ImGui.EndGroup();
                ImGui.PopStyleColor();
                ImGui.EndChild();
            }
            ImGui.SameLine();
            ImGui.BeginChild("txt3", new Vector2(size.X - 5, size.Y), false, ImGuiWindowFlags.NoScrollbar);
            {
                result = InputTextMultiLine($"##{label}", ref text, maxLength, new Vector2(size.X - 5, size.Y), flags);
                ImGui.EndChild();
            }
            ImGui.EndChild();
        }
        ImGui.PopStyleColor();
        return result;
    }

    public static unsafe void ImFormatStringToTempBufferV(char** out_buf, char** out_buf_end, string txt)
    {
        var g = ImGui.GetCurrentContext();
        var buf_len =
            ImGuiInternal.ImFormatStringV((byte*)g->TablesTempData.Data, (nuint)g->TempBuffer.Size, txt, null);
        *out_buf = (char*)g->TempBuffer.Data;
        if (out_buf_end != null) *out_buf_end = (char*)(g->TempBuffer.Data + buf_len);
    }

    public static unsafe bool Begin(string name, ref bool p_open, ImGuiWindowFlags flags)
    {
        byte* native_name;
        var name_byteCount = 0;
        if (name != null)
        {
            name_byteCount = Encoding.UTF8.GetByteCount(name);
            if (name_byteCount > Util.StackAllocationSizeLimit)
            {
                native_name = Util.Allocate(name_byteCount + 1);
            }
            else
            {
                var native_name_stackBytes = stackalloc byte[name_byteCount + 1];
                native_name = native_name_stackBytes;
            }

            var native_name_offset = Util.GetUtf8(name, native_name, name_byteCount);
            native_name[native_name_offset] = 0;
        }
        else
        {
            native_name = null;
        }

        var native_p_open_val = p_open ? (byte)1 : (byte)0;
        var ok = p_open;
        var test = &ok;
        var ret = ImGui.Begin(native_name, test, flags);
        if (name_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_name);
        p_open = native_p_open_val != 0;
        return ret;
    }

    public static unsafe bool SliderInt(string label, ref int v, int v_min, int v_max)
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

        byte* native_format;
        var format_byteCount = 0;
        format_byteCount = Encoding.UTF8.GetByteCount("%d");
        if (format_byteCount > Util.StackAllocationSizeLimit)
        {
            native_format = Util.Allocate(format_byteCount + 1);
        }
        else
        {
            var native_format_stackBytes = stackalloc byte[format_byteCount + 1];
            native_format = native_format_stackBytes;
        }

        var native_format_offset = Util.GetUtf8("%d", native_format, format_byteCount);
        native_format[native_format_offset] = 0;
        ImGuiSliderFlags flags = 0;
        fixed (int* native_v = &v)
        {
            var ret = ImGui.SliderInt(native_label, native_v, v_min, v_max, native_format, flags);
            if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
            if (format_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_format);
            return ret;
        }
    }

    public static unsafe bool SliderInt(string label, ref int v, int v_min, int v_max, string format)
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

        byte* native_format;
        var format_byteCount = 0;
        if (format != null)
        {
            format_byteCount = Encoding.UTF8.GetByteCount(format);
            if (format_byteCount > Util.StackAllocationSizeLimit)
            {
                native_format = Util.Allocate(format_byteCount + 1);
            }
            else
            {
                var native_format_stackBytes = stackalloc byte[format_byteCount + 1];
                native_format = native_format_stackBytes;
            }

            var native_format_offset = Util.GetUtf8(format, native_format, format_byteCount);
            native_format[native_format_offset] = 0;
        }
        else
        {
            native_format = null;
        }

        ImGuiSliderFlags flags = 0;
        fixed (int* native_v = &v)
        {
            var ret = ImGui.SliderInt(native_label, native_v, v_min, v_max, native_format, flags);
            if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
            if (format_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_format);
            return ret;
        }
    }

    public static unsafe bool SliderInt(string label, ref int v, int v_min, int v_max, string format,
        ImGuiSliderFlags flags)
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

        byte* native_format;
        var format_byteCount = 0;
        if (format != null)
        {
            format_byteCount = Encoding.UTF8.GetByteCount(format);
            if (format_byteCount > Util.StackAllocationSizeLimit)
            {
                native_format = Util.Allocate(format_byteCount + 1);
            }
            else
            {
                var native_format_stackBytes = stackalloc byte[format_byteCount + 1];
                native_format = native_format_stackBytes;
            }

            var native_format_offset = Util.GetUtf8(format, native_format, format_byteCount);
            native_format[native_format_offset] = 0;
        }
        else
        {
            native_format = null;
        }

        fixed (int* native_v = &v)
        {
            var ret = ImGui.SliderInt(native_label, native_v, v_min, v_max, native_format, flags);
            if (label_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_label);
            if (format_byteCount > Util.StackAllocationSizeLimit) Util.Free(native_format);

            return ret;
        }
    }
}