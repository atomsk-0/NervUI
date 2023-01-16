using Mochi.DearImGui;
using NervUI.Entities;

namespace TestWindow;

public unsafe class MainLayer : Layer
{
    private bool m_DemoOpen;

    private int _clickTimes;

    //Initialize variables
    public MainLayer()
    {
        _clickTimes = 55;
        m_DemoOpen = true;
        Console.WriteLine("OO");
    }
    
    public override void OnUIRender()
    {
        var io = ImGui.GetIO();
        bool demoOpen = m_DemoOpen;
        ImGui.ShowDemoWindow(&demoOpen);
        m_DemoOpen = demoOpen;

        ImGui.Begin("NervUI Test");
        {
            ImGui.TextWrapped($"Application average {1000f / io->Framerate} ms/frame ({io->Framerate} FPS)");
            ImGui.Separator();
            if (ImGui.Button($"This button is clicked {_clickTimes} times.", default))
                _clickTimes++;
            ImGui.End();
        }
    }
}