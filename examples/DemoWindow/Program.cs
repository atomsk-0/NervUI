using System.Drawing;
using System.Numerics;
using System.Windows;
using Mochi.DearImGui;
using NervUI;
using NervUI.Modules;
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
        {
            ImGui.Text($"This button is clicked {num} times.");
            if (ImGui.Button("Click to increase value", new Vector2()))
            {
                num++;
            }
            if (ImGui.Button("MessageBox example", new Vector2()))
            {
                MessageBox.ShowMessageBox("Hello World", "Test");
            }
        }
        ImGui.End();
    }
}


internal static class Program
{
    private static Application _application;
    private static bool g_applicationRunning = true;

    public static string imageLocation = "";
    
    private static void Main()
    {
        NotifyIconExample();
        //Create main loop for the application
        while (g_applicationRunning)
        {
            //Options for App
            var options = new ApplicationOptions()
            {
                Title = "NervUI Demo Window",
                Size = new(1280, 720),
                DefaultFont = new NervFont("Roboto", "Fonts/Roboto-Medium.ttf", 16f),//Set this as new DefaultFont
            };
            
            //Create new instance of the application
            _application = Application.CreateApplication(options);
            
            //Add other custom font named as Roboto-BlackItalic
            _application.AddFont(new NervFont("Roboto-BlackItalic", "Fonts/Roboto-BlackItalic.ttf", 16f));
            
            //Push DemoLayer and DemoLayer2 for the renderer
            _application.PushLayer<DemoLayer>();
            _application.PushLayer<DemoLayer2>();

            //Create Menubar for app
            _application.SetMenuBarCallback(() =>
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGuiManaged.MenuItem("Open", ""))
                    {
                        FileDialog.ShowFileDialog("C:\\", FileDialogType.OpenFile, delegate(string s)
                        {
                            Console.WriteLine(s);
                            //Prints the selected path/file location
                        });
                    }
                    if (ImGuiManaged.MenuItem("MessageBox", ""))
                    {
                        MessageBox.ShowMessageBox("Hello World", "Test");
                    }
                    if (ImGuiManaged.MenuItem("Exit", ""))
                    {
                        _application.Exit();
                    }
                    ImGui.EndMenu();
                }
            });

            //Run application
            _application.Run();
            
            g_applicationRunning = false;
        }
        
        _application.Exit();
    }

    private static NotifyIcon _notifyIcon;
    private static void NotifyIconExample()
    {
        _notifyIcon = NotifyIcon.Create();
        //_notifyIcon.Icon = new Bitmap("path to icon");
        _notifyIcon.Text = "NervUI Example";
        ContextMenuStrip.MenuItem menuItem = new ContextMenuStrip.MenuItem();
        menuItem.Text = "Exit";
        menuItem.Visible = true;
        menuItem.Click += (sender, args) => _application.Exit();
        _notifyIcon.ContextMenuStrip.Items.Add(menuItem);
        _notifyIcon.Visible = true;
        _notifyIcon.ShowBalloonTip("Hello", "test", ToolTipIcon.Info);
    }
}