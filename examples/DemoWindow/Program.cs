using System.Numerics;
using Mochi.DearImGui;
using NervUI;

namespace DemoWindow;

public class DemoLayer : Layer
{
    public override unsafe void OnUIRender()
    {
        bool open = true;
        ImGui.ShowDemoWindow(&open);
    }
}

public class DemoLayer2 : Layer
{
    private int num = 0;
    public override unsafe void OnUIRender()
    {
        ImGui.Begin("NervUI Demo");
        ImGui.Text("Hello World!");
        if (ImGui.Button("Click here!", new Vector2(100, 20)))
        {
            num++;
        }
        ImGui.Text($"Button clicked {num} times.");
        ImGui.End();
    }
}

internal static class Program
{
    private static Application _application;
    private static bool g_applicationRunning = true;
    private static void Main()
    {
        while (g_applicationRunning)
        {
            var options = new ApplicationOptions()
            {
                Title = "Demo Window",
                Size = new(1280, 720)
            };
            
            _application = Application.CreateApplication(options);
            
            _application.PushLayer<DemoLayer>();
            _application.PushLayer<DemoLayer2>();
            
            _application.Run();
            
            g_applicationRunning = false;
        }
        
        _application.Exit();
    }
}