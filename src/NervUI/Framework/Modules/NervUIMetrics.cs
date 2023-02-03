using System.Numerics;
using Mochi.DearImGui;

namespace NervUI.Framework.Modules;

public unsafe class NervUIMetrics
{
    public static bool Show = false;
    internal static void Render()
    {
        if (Show)
        {
            bool p_show = Show;
            ImGui.SetNextWindowSize(new Vector2(450, 100));
            ImGui.Begin("NervUI Metrics", &p_show);
            {
                var io = ImGui.GetIO();
                ImGui.TextWrapped($"Application average {1000f / io->Framerate} ms/frame ({io->Framerate} FPS)\nMemory Usage:{Util.SizeSuffix(GC.GetTotalMemory(true))}\nVSync:{Application.Instance.Options.VSync.ToString()}");
                ImGui.End();
            }
            Show = p_show;
        }
    }
}