using System.Runtime.InteropServices;
using Mochi.DearImGui;
using Mochi.DearImGui.Internal;
using NervUI;
using NervUI.Common;
using NervUI.Entities;
using NervUI.Framework;
using NervUI.Framework.Modules;
using NervUI.Platforms;

//This program is made to test stuff in NervUI this is not a example project!
namespace TestWindow;

internal static unsafe class Program
{
    internal static Application _application;
    
    private static int Main()
    {
        bool g_applicationRunning = true;
        
        while (g_applicationRunning)
        {
            var options = new ApplicationOptions()
            {
                Title = "TestWindow"
            };
        
            _application = Application.CreateApplication(options);

            _application.PushLayer<MainLayer>();
            
            _application.CreateWindow();

            _application.SetMenuBarCallback(() =>
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGuiManaged.MenuItem("Open", ""))
                        FileDialog.ShowFileDialog(Core.Platform == OSPlatform.Linux ? Linux.DefaultFilePath : Windows.DefaultFilePath, FileDialogType.OpenFile, delegate(string s)
                        {
                            Console.WriteLine(s);
                            //Prints the selected path/file location
                        });
                    if (ImGuiManaged.MenuItem("MessageBox", "")) MessageBox.ShowMessageBox("Hello World", "Test");
                    if (ImGuiManaged.MenuItem("Exit", "")) Environment.Exit(0);
                    ImGui.EndMenu();
                }
            });
        
            _application.SetDockspaceCallback(u =>
            {
                var dockspace_id = u;
        
                var dock_id_left =
                    ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Left, 0.2f, null, &dockspace_id);
                var dock_id_right =
                    ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Right, 0.25f, null, &dockspace_id);
                var dock_id_down =
                    ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Down, 0.25f, null, &dockspace_id);
                var dock_id_top =
                    ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Up, 0.25f, null, &dockspace_id);
                
                ImGuiInternal.DockBuilderDockWindow("Dear ImGui Demo", dock_id_right);
                ImGuiInternal.DockBuilderDockWindow("NervUI Test", dock_id_left);
                ImGuiInternal.DockBuilderFinish(dockspace_id);
            });
        
            _application.Run();
        
            g_applicationRunning = false;
        }
        
        
        return 0;
    }
}