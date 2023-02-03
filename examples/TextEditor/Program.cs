using Mochi.DearImGui;
using Mochi.DearImGui.Internal;
using NervUI;
using NervUI.Entities;
using NervUI.Framework;
using NervUI.Framework.Modules;
using OpenTK.Windowing.GraphicsLibraryFramework;
using TextEditor.Layers;

//This example is designed to work in Windows

namespace TextEditor;

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
                Title = "Text Editor Demo"
            };
        
            _application = Application.CreateApplication(options);
            
            
            _application.SetDefaultFont(new NervFont("Roboto-Regular", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts", "Roboto-Regular.ttf"), 16f));

            _application.PushLayer(new MainLayer());
            
            _application.CreateWindow();

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
                
                ImGuiInternal.DockBuilderDockWindow("Text Editor", dock_id_down);
                ImGuiInternal.DockBuilderFinish(dockspace_id);
            });
            
            _application.SetFileDropCallback(args =>
            {
                foreach (var fn in args.FileNames)
                {
                    var fi = new FileInfo(fn);
                    MainLayer.Editors.Add(new TextEditor(fi.Name, File.ReadAllText(fn), fn));
                }
            });
            
            _application.SetKeyDownCallback(args =>
            {
                var obj = args;
                if (obj.Control && obj.Key == Keys.S)
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
        
                if (obj.Control && obj.Key == Keys.N)
                {
                    MainLayer.Editors.Add(new TextEditor($"Untitled{MainLayer.Editors.Count}"));
                }
        
                if (obj.Control && obj.Key == Keys.O)
                {
                    FileDialog.ShowFileDialog($"C:\\Users\\{Environment.UserName}\\Documents", FileDialogType.OpenFile, delegate(string s)
                    {
                        if (File.Exists(s))
                        {
                            var fi = new FileInfo(s);
                            MainLayer.Editors.Add(new TextEditor(fi.Name, File.ReadAllText(s), s));
                        }
                    });
                }
            });
        
            _application.Run();
        
            g_applicationRunning = false;
        }
        
        
        return 0;
    }
}