using System.Drawing;
using Mochi.DearImGui;
using Mochi.DearImGui.Internal;
using NervUI;
using NervUI.Modules;
using TextEditorExample.Layers;

namespace TextEditorExample;

internal static class Program
{
    private static Application _application;
    

    private static bool g_applicationRunning = true;
    
    private static void Main()
    {
        MainLayer.Editors.Add(new TextEditor("Untitled0"));
        while (g_applicationRunning)
        {
            var options = new ApplicationOptions()
            {
                Title = "NervUI Notepad Demo",
                Size = new Point(1280, 720),
                //WindowBorder = WindowBorder.Fixed
            };
        
            _application = Application.CreateApplication(options);
            
            _application.PushLayer<MainLayer>();
            
            _application.SetMenuBarCallback(() =>
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGuiManaged.MenuItem("New File", "CTRL + N"))
                    {
                        MainLayer.Editors.Add(new TextEditor($"Untitled{MainLayer.Editors.Count}"));
                    }
                    if (ImGuiManaged.MenuItem("Open", "CTRL + O"))
                        FileDialog.ShowFileDialog($"C:\\Users\\{Environment.UserName}\\Documents", FileDialogType.OpenFile, delegate(string s)
                        {
                            if (File.Exists(s))
                            {
                                var fi = new FileInfo(s);
                                MainLayer.Editors.Add(new TextEditor(fi.Name, File.ReadAllText(s), s));
                            }
                        });
                    if (ImGuiManaged.MenuItem("Save", "CTRL + S"))
                    {
                        if (File.Exists(MainLayer.CurrentEditor.FilePath))
                        {
                            File.WriteAllText(MainLayer.CurrentEditor.FilePath, MainLayer.CurrentEditor.Text);
                            MainLayer.CurrentEditor.isSaved = true;
                        }
                        else
                        {
                            File.WriteAllText($"C:\\Users\\{Environment.UserName}\\Documents\\{MainLayer.CurrentEditor.Title}.txt",
                                MainLayer.CurrentEditor.Text);
                            MainLayer.CurrentEditor.isSaved = true;
                            MainLayer.CurrentEditor.FilePath = $"C:\\Users\\{Environment.UserName}\\Documents\\{MainLayer.CurrentEditor.Title}.txt";
                        }
                    }
                    if (ImGuiManaged.MenuItem("Exit", "")) _application.Exit();
                    ImGui.EndMenu();
                }
            });
            
            _application.SetDockspaceCallback((u, flags) =>
            {
                unsafe
                {
                    var dockspace_id = u;

                    var dock_id_left =
                        ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Left, 0.2f, null, &dockspace_id);
                    var dock_id_right =
                        ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Right, 0.25f, null, &dockspace_id);
                    var dock_id_down =
                        ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Down, 0.25f, null, &dockspace_id);

                    ImGuiInternal.DockBuilderDockWindow("Text Editor", dock_id_down);
                    ImGuiInternal.DockBuilderFinish(dockspace_id);
                }
            });
            
            _application.Run();

            g_applicationRunning = false;
        }
    }
}