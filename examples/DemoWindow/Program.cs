using ImGuiNET;
using NervUI;

namespace DemoWindow;

public class DemoLayer : Layer//TODO!
{
    protected override void OnUIRender()
    {
        ImGui.ShowDemoWindow();
    }
}

internal static class Program
{
    private static Application _application;
    private static bool g_applicationRunning = true;
    
    private static void Main(string[] args)
    {
        while (g_applicationRunning)
        {
            var options = new ApplicationOptions();
            
            options.Title = "Demo Window";
            _application = Application.CreateApplication(options);
            _application.PushLayer<DemoLayer>();//TODO!
            _application.Run();
            
            g_applicationRunning = false;
        }
        //Application is no more running..
        Environment.Exit(0);
    }
}