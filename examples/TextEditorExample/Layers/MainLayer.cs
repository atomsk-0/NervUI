using Mochi.DearImGui;
using NervUI;
using NervUI.Modules;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace TextEditorExample.Layers;

public unsafe class MainLayer : Layer
{
    public static List<TextEditor> Editors = new();

    public static TextEditor CurrentEditor;

    public override void OnFileDrop(FileDropEventArgs e)
    {
        foreach (var fn in e.FileNames)
        {
            var fi = new FileInfo(fn);
            Editors.Add(new TextEditor(fi.Name, File.ReadAllText(fn), fn));
        }

    }

    public override void OnKeyDown(KeyboardKeyEventArgs obj)
    {
        if (obj.Control && obj.Key == Keys.S)
        {
            if (File.Exists(CurrentEditor.FilePath))
            {
                File.WriteAllText(CurrentEditor.FilePath, CurrentEditor.Text);
                CurrentEditor.isSaved = true;
            }
            else
            {
                File.WriteAllText($"C:\\Users\\{Environment.UserName}\\Documents\\{CurrentEditor.Title}.txt",
                    CurrentEditor.Text);
                CurrentEditor.isSaved = true;
                CurrentEditor.FilePath = $"C:\\Users\\{Environment.UserName}\\Documents\\{CurrentEditor.Title}.txt";
            }
        }
        
        if (obj.Control && obj.Key == Keys.N)
        {
            Editors.Add(new TextEditor($"Untitled{Editors.Count}"));
        }
        
        if (obj.Control && obj.Key == Keys.O)
        {
            FileDialog.ShowFileDialog($"C:\\Users\\{Environment.UserName}\\Documents", FileDialogType.OpenFile, delegate(string s)
            {
                if (File.Exists(s))
                {
                    var fi = new FileInfo(s);
                    Editors.Add(new TextEditor(fi.Name, File.ReadAllText(s), s));
                }
            });
        }
        base.OnKeyDown(obj);
    }

    public override void OnUIRender()
    {
        ImGui.Begin($"Text Editor", null, ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove);
        if (ImGui.BeginTabBar("TextEditors", ImGuiTabBarFlags.TabListPopupButton))
        {
            for (int i = 0; i < Editors.Count; i++)
            {
                var editor = Editors[i];
                bool iOpened = editor.isOpened;
                if (!editor.isSaved)
                {
                    if (ImGui.BeginTabItem(editor.Title, &iOpened, ImGuiTabItemFlags.UnsavedDocument))
                    {
                        if (ImGuiManaged.TextEditor($"##textEditor{editor.Title}", ref editor.Text,
                                new Vector2(ImGui.GetWindowWidth() - 15, ImGui.GetWindowHeight() - 60)))
                        {
                            if (File.Exists(editor.FilePath) && editor.isSaved)
                            {
                                if (File.ReadAllText(editor.FilePath) != editor.Text)
                                {
                                    editor.isSaved = false;
                                }
                            }
                            CurrentEditor = editor;
                        }
                        ImGui.EndTabItem();
                    }
                }
                else
                {
                    if (ImGui.BeginTabItem(editor.Title, &iOpened))
                    {
                        if (ImGuiManaged.TextEditor($"##textEditor{editor.Title}", ref editor.Text,
                                new Vector2(ImGui.GetWindowWidth() - 15, ImGui.GetWindowHeight() - 60)))
                        {
                            if (File.Exists(editor.FilePath) && editor.isSaved)
                            {
                                if (File.ReadAllText(editor.FilePath) != editor.Text)
                                {
                                    editor.isSaved = false;
                                }
                            }
                            CurrentEditor = editor;
                        }
                        ImGui.EndTabItem();
                    }
                }

                editor.isOpened = iOpened;
            }
            ImGui.EndTabBar();
        }
        ImGui.End();
    }
}