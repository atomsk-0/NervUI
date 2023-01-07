using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using Mochi.DearImGui;

namespace NervUI;

public static unsafe class Util
{
    internal const int StackAllocationSizeLimit = 2048;

    public static Vector4 Vec_Color(int r, int g, int b, int a = 255)
    {
        return new Vector4(
            r / 255.0f,
            g / 255.0f,
            b / 255.0f,
            a / 255.0f);
    }

    public static string StringFromPtr(byte* ptr)
    {
        var characters = 0;
        while (ptr[characters] != 0) characters++;

        return Encoding.UTF8.GetString(ptr, characters);
    }

    internal static bool AreStringsEqual(byte* a, int aLength, byte* b)
    {
        for (var i = 0; i < aLength; i++)
            if (a[i] != b[i])
                return false;

        if (b[aLength] != 0) return false;

        return true;
    }

    internal static byte* Allocate(int byteCount)
    {
        return (byte*)Marshal.AllocHGlobal(byteCount);
    }

    internal static void Free(byte* ptr)
    {
        Marshal.FreeHGlobal((IntPtr)ptr);
    }

    internal static int CalcSizeInUtf8(string s, int start, int length)
    {
        if (start < 0 || length < 0 || start + length > s.Length) throw new ArgumentOutOfRangeException();

        fixed (char* utf16Ptr = s)
        {
            return Encoding.UTF8.GetByteCount(utf16Ptr + start, length);
        }
    }

    internal static int GetUtf8(string s, byte* utf8Bytes, int utf8ByteCount)
    {
        fixed (char* utf16Ptr = s)
        {
            return Encoding.UTF8.GetBytes(utf16Ptr, s.Length, utf8Bytes, utf8ByteCount);
        }
    }

    internal static int GetUtf8(string s, int start, int length, byte* utf8Bytes, int utf8ByteCount)
    {
        if (start < 0 || length < 0 || start + length > s.Length) throw new ArgumentOutOfRangeException();

        fixed (char* utf16Ptr = s)
        {
            return Encoding.UTF8.GetBytes(utf16Ptr + start, length, utf8Bytes, utf8ByteCount);
        }
    }

    internal static void SetStyle()
    {
        var io = ImGui.GetIO();
        io->IniFilename = null;
        var style = ImGui.GetStyle();
        ImGui.StyleColorsDark(style);
        style->Colors[(int)ImGuiCol.Text] = new Vector4(0.84f, 0.84f, 0.84f, 1.00f);
        style->Colors[(int)ImGuiCol.WindowBg] = new Vector4(0.22f, 0.22f, 0.22f, 1.00f);
        style->Colors[(int)ImGuiCol.ChildBg] = new Vector4(0.19f, 0.19f, 0.19f, 1.00f);
        style->Colors[(int)ImGuiCol.PopupBg] = new Vector4(0.09f, 0.09f, 0.09f, 1.00f);
        style->Colors[(int)ImGuiCol.Border] = new Vector4(0.17f, 0.17f, 0.17f, 1.00f);
        style->Colors[(int)ImGuiCol.BorderShadow] = new Vector4(0.10f, 0.10f, 0.10f, 0.00f);
        style->Colors[(int)ImGuiCol.FrameBg] = new Vector4(0.33f, 0.33f, 0.33f, 1.00f);
        style->Colors[(int)ImGuiCol.FrameBgHovered] = new Vector4(0.47f, 0.47f, 0.47f, 1.00f);
        style->Colors[(int)ImGuiCol.FrameBgActive] = new Vector4(0.16f, 0.16f, 0.16f, 1.00f);
        style->Colors[(int)ImGuiCol.TitleBg] = new Vector4(0.11f, 0.11f, 0.11f, 1.00f);
        style->Colors[(int)ImGuiCol.TitleBgActive] = new Vector4(0.16f, 0.16f, 0.16f, 1.00f);
        style->Colors[(int)ImGuiCol.MenuBarBg] = new Vector4(0.11f, 0.11f, 0.11f, 1.00f);
        style->Colors[(int)ImGuiCol.ScrollbarGrab] = new Vector4(0.33f, 0.33f, 0.33f, 1.00f);
        style->Colors[(int)ImGuiCol.ScrollbarGrabHovered] = new Vector4(0.33f, 0.33f, 0.33f, 1.00f);
        style->Colors[(int)ImGuiCol.ScrollbarGrabActive] = new Vector4(0.35f, 0.35f, 0.35f, 1.00f);
        style->Colors[(int)ImGuiCol.CheckMark] = new Vector4(0.28f, 0.45f, 0.70f, 1.00f);
        style->Colors[(int)ImGuiCol.SliderGrab] = new Vector4(0.28f, 0.45f, 0.70f, 1.00f);
        style->Colors[(int)ImGuiCol.SliderGrabActive] = new Vector4(0.28f, 0.45f, 0.70f, 1.00f);
        style->Colors[(int)ImGuiCol.Button] = new Vector4(0.33f, 0.33f, 0.33f, 1.00f);
        style->Colors[(int)ImGuiCol.ButtonHovered] = new Vector4(0.40f, 0.40f, 0.40f, 1.00f);
        style->Colors[(int)ImGuiCol.ButtonActive] = new Vector4(0.28f, 0.45f, 0.70f, 1.00f);
        style->Colors[(int)ImGuiCol.Header] = new Vector4(0.27f, 0.27f, 0.27f, 1.00f);
        style->Colors[(int)ImGuiCol.HeaderHovered] = new Vector4(0.28f, 0.45f, 0.70f, 1.00f);
        style->Colors[(int)ImGuiCol.HeaderActive] = new Vector4(0.27f, 0.27f, 0.27f, 1.00f);
        style->Colors[(int)ImGuiCol.Separator] = new Vector4(0.18f, 0.18f, 0.18f, 1.00f);
        style->Colors[(int)ImGuiCol.SeparatorHovered] = new Vector4(0.28f, 0.45f, 0.70f, 1.00f);
        style->Colors[(int)ImGuiCol.SeparatorActive] = new Vector4(0.28f, 0.45f, 0.70f, 1.00f);
        style->Colors[(int)ImGuiCol.ResizeGrip] = new Vector4(0.54f, 0.54f, 0.54f, 1.00f);
        style->Colors[(int)ImGuiCol.ResizeGripHovered] = new Vector4(0.28f, 0.45f, 0.70f, 1.00f);
        style->Colors[(int)ImGuiCol.ResizeGripActive] = new Vector4(0.19f, 0.39f, 0.69f, 1.00f);
        style->Colors[(int)ImGuiCol.Tab] = new Vector4(0.11f, 0.11f, 0.11f, 1.00f);
        style->Colors[(int)ImGuiCol.TabHovered] = new Vector4(0.14f, 0.14f, 0.14f, 1.00f);
        style->Colors[(int)ImGuiCol.TabActive] = new Vector4(0.19f, 0.19f, 0.19f, 1.00f);
        style->Colors[(int)ImGuiCol.PlotHistogram] = new Vector4(0.28f, 0.45f, 0.70f, 1.00f);
        style->Colors[(int)ImGuiCol.PlotHistogramHovered] = new Vector4(0.20f, 0.39f, 0.69f, 1.00f);
        style->Colors[(int)ImGuiCol.TextSelectedBg] = new Vector4(0.28f, 0.45f, 0.70f, 1.00f);
        style->Colors[(int)ImGuiCol.NavHighlight] = new Vector4(0.28f, 0.45f, 0.70f, 1.00f);
    }
}