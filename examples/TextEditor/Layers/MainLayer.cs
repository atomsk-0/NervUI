using System.Numerics;
using Mochi.DearImGui;
using NervUI.Entities;
using NervUI.Framework;

namespace TextEditor.Layers;

public unsafe class MainLayer : Layer
{
    public static List<TextEditor> Editors = new();

    public static TextEditor CurrentEditor;
    
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
                        //This method of applying maxlength gonna use alot memory...
                        if (ImGuiManaged.TextEditor($"##textEditor{editor.Title}", ref editor.Text,
                                9999, new Vector2(ImGui.GetWindowWidth() - 15, ImGui.GetWindowHeight() - 60)))
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
                        //This method of applying maxlength gonna use alot memory...
                        if (ImGuiManaged.TextEditor($"##textEditor{editor.Title}", ref editor.Text,
                                9999, new Vector2(ImGui.GetWindowWidth() - 15, ImGui.GetWindowHeight() - 60)))
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