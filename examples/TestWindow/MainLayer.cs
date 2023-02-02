using System.Numerics;
using Mochi.DearImGui;
using NervUI.Entities;
using NervUI.Framework;

namespace TestWindow;

public unsafe class MainLayer : Layer
{
    private bool m_DemoOpen = false;

    private int _clickTimes = 0;

    public static string text1 = "Hello World";

    public override void OnUIRender()
    {
        var io = ImGui.GetIO();
        bool demoOpen = m_DemoOpen;
        ImGui.ShowDemoWindow(&demoOpen);
        m_DemoOpen = demoOpen;

        ImGui.SetNextWindowSize(new Vector2(900, 600));
        ImGui.Begin("NervUI Test");
        {
            ImGui.TextWrapped($"Application average {1000f / io->Framerate} ms/frame ({io->Framerate} FPS)\nMemory Usage:{Util.SizeSuffix(GC.GetTotalMemory(true))}");
            ImGui.Text($"Lines in text editor: {text1.Split('\n').Length.ToString().ToCharArray().Length}");
            ImGui.Separator();
            if (ImGui.Button($"This button is clicked {_clickTimes} times.", default))
                _clickTimes++;
            ImGuiManaged.TextEditor("textEditor1", ref text1, new Vector2(900, 500));
            ImGui.End();
        }
    }
}