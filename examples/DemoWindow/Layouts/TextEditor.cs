using Mochi.DearImGui;
using NervUI;
using OpenTK.Mathematics;

namespace DemoWindow.Layouts;

//Layers are to help keep the imgui code cleaner so you can create new class for each imgui part you want.
public class TextEditor : Layer
{
    private bool open = true;
    private string text = "";

    public override unsafe void OnUIRender()
    {
        ImGui.Begin("TextEditor Demo", null, ImGuiWindowFlags.NoScrollbar);
        ImGuiManaged.TextEditor("##Test", ref text, new Vector2(750, 661));
        ImGui.End();
    }
}