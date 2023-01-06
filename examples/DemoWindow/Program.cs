using System.Numerics;
using System.Runtime.InteropServices;
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
    private string text = "Hello World!";
    private string text2 = "";
    public override unsafe void OnUIRender()
    {
        ImGui.Begin("NervUI Demo");
        
        //Use other font by using PushFont('FontName')
        Application.PushFont("Roboto-BlackItalic");
        ImGui.Text(text);
        Application.PopFont();//Stop using the font
        ImGui.SameLine();
        if (ImGui.Button("Click here!", new Vector2(100, 20)))
        {
            num++;
        }
        ImGui.Text($"Button clicked {num} times.");
        ImGuiManaged.InputTextWithHint("Input", "Write here something", ref text, 200);
        ImGuiManaged.InputTextWithHint("##TextInput2", "Write here something", ref text2, 200);
        ImGui.Text(text2);
        
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
                Size = new(1280, 720),
                DefaultFont = new NervFont("Roboto", "Fonts/Roboto-Medium.ttf", 16f)//Set this as new DefaultFont
            };
            
            //Create new instance of the application
            _application = Application.CreateApplication(options);
            
            //Add other custom font named as Roboto-BlackItalic
            _application.AddFont(new NervFont("Roboto-BlackItalic", "Fonts/Roboto-BlackItalic.ttf", 16f));
            
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