using System.Numerics;
using Mochi.DearImGui;
using NervUI;

namespace DemoWindow;

//Layers are to help keep the imgui code cleaner so you can create new class for each imgui part you want.
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
        //Create main loop for the application
        while (g_applicationRunning)
        {
            //Options for App
            var options = new ApplicationOptions()
            {
                Title = "Demo Window",
                Size = new(1280, 720)
            };
            
            //Create new instance of the application
            _application = Application.CreateApplication(options);
            
            //Push DemoLayer and DemoLayer2 for the renderer
            _application.PushLayer<DemoLayer>();
            _application.PushLayer<DemoLayer2>();
            
            //Run application
            _application.Run();
            
            g_applicationRunning = false;
        }
        
        _application.Exit();
    }
}