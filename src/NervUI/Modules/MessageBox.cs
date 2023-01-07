using System.Drawing;
using System.Numerics;
using System.Windows;
using Mochi.DearImGui;

namespace NervUI.Modules;

public class MessageBox
{
    internal static string Title = "";
    internal static string Message = "";
    internal static Color _color = Color.FromArgb(66, 135, 245);
    internal static bool showMB = false;

    public static void ShowMessageBox(string title, string message)
    {
        Title = title;
        Message = message;
        showMB = true;

    }
    
    public static void ShowMessageBox(string title, string message, Color title_color)
    {
        Title = title;
        Message = message;
        _color = title_color;
        showMB = true;
    }
    
    internal static unsafe void RenderMessageBox()
    {
        if (showMB)
        {
            var center = new Vector2(ImGui.GetWindowPos().X + ImGui.GetWindowSize().X * 0.5f, ImGui.GetWindowPos().Y + ImGui.GetWindowSize().Y * 0.5f);
            ImGui.SetNextWindowPos(center, ImGuiCond.Appearing, new Vector2(0.5f, 0.5f));
            if (ImGui.BeginPopupModal("MessageBoxPopup"))
            {
                ImGui.TextColored(Util.Vec_Color(_color.R, _color.G, _color.B, _color.A), Title);
                ImGui.Separator();
                ImGuiManaged.TextWrapped(Message);
                if (ImGui.Button("OK", new Vector2()))
                {
                    ImGui.CloseCurrentPopup();
                    showMB = false;
                }
                ImGui.EndPopup();
            }
        }
    }
}