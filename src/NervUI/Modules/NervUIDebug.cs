using System.Numerics;
using Mochi.DearImGui;

namespace NervUI.Modules;

public static unsafe class NervUIDebug
{
    internal static string DebugLogText = "";
    private static readonly bool* show = null;

    public static void Show()
    {
        var io = ImGui.GetIO();
        ImGui.SetNextWindowSize(new Vector2(740, 420));
        ImGui.Begin("NervUI Debug", show, ImGuiWindowFlags.NoResize);
        {
            ImGui.Text($"Application average {1000f / io->Framerate} ms/frame ({io->Framerate} FPS)");
            ImGui.Text($"Dear ImGui {ImGui.IMGUI_VERSION}");
            ImGui.Text($"OpenGL 3.0");
            ImGui.Text("NervUI by byte-0x74");
            ImGui.Separator();
            ImGui.Text("NervUI Logs");
            ImGui.PushStyleColor(ImGuiCol.FrameBg, Util.Vec_Color(44, 44, 44));
            ImGuiManaged.InputTextMultiLine("##nvuidbgl", ref DebugLogText, 9999999,
                new OpenTK.Mathematics.Vector2(720, 270),
                ImGuiInputTextFlags.ReadOnly);
            ImGui.PopStyleColor();
            ImGui.End();
        }
    }

    internal static void Log(string text)
    {
        DebugLogText += text + "\n";
    }
}