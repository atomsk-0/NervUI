using Mochi.DearImGui;
using NervUI;

namespace DemoWindow.Layouts;

//Layers are to help keep the imgui code cleaner so you can create new class for each imgui part you want.
public class DemoLayer : Layer
{
    public override unsafe void OnUIRender()
    {
        var open = true;
        ImGui.ShowDemoWindow(&open);
    }
}