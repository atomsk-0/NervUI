using System.Drawing;
using Mochi.DearImGui;
using Mochi.DearImGui.Internal;
using MusicPlayerExample.Layers;
using NervUI;
using NervUI.Modules;
using OpenTK.Windowing.Common;

namespace MusicPlayerExample;

internal static unsafe class Program
{
    private static Application _application;

    private static bool g_applicationRunning = true;
    
    private static void Main()
    {
        while (g_applicationRunning)
        {
            var options = new ApplicationOptions()
            {
                Title = "NervUI MusicPlayer Demo",
                Size = new Point(500, 150),
                WindowBorder = WindowBorder.Fixed
            };
            
            _application = Application.CreateApplication(options);
            
            _application.PushLayer<MainLayer>();
            
             _application.SetMenuBarCallback(() =>
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGuiManaged.MenuItem("Open", ""))
                        FileDialog.ShowFileDialog($"C:\\Users\\{Environment.UserName}\\Documents", FileDialogType.OpenFile, delegate(string s)
                        {
                            if (File.Exists(s))
                            {
                                MainLayer.Audio = new Audio(s);
                            }
                        });
                    ImGui.EndMenu();
                }
            });
            
            _application.SetDockspaceCallback((u, flags) =>
            {
                var dockspace_id = u;

                var dock_id_left =
                    ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Left, 0.2f, null, &dockspace_id);
                var dock_id_right =
                    ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Right, 0.25f, null, &dockspace_id);
                var dock_id_down =
                    ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Down, 0.25f, null, &dockspace_id);

                ImGuiInternal.DockBuilderDockWindow("Music Player", dock_id_down);
                ImGuiInternal.DockBuilderFinish(dockspace_id);
            });
            
            _application.Run();

            g_applicationRunning = false;
        }
    }
}