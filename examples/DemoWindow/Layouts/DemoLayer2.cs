using System.Numerics;
using Mochi.DearImGui;
using NervUI;
using NervUI.Modules;

namespace DemoWindow.Layouts;

//Layers are to help keep the imgui code cleaner so you can create new class for each imgui part you want.
public class DemoLayer2 : Layer
{
    private Audio _audio;
    private int num;

    public override unsafe void OnUIRender()
    {
        ImGui.Begin("NervUI Demo");
        {
            ImGui.Text($"This button is clicked {num} times.");
            if (ImGui.Button("Click to increase value", new Vector2())) num++;
            if (ImGui.Button("MessageBox example", new Vector2())) MessageBox.ShowMessageBox("Hello World", "Test");

            if (ImGui.Button("Select audio to play", new Vector2()))
                FileDialog.ShowFileDialog($@"C:\Users\{Environment.UserName}\Documents", FileDialogType.OpenFile,
                    delegate(string s) { _audio = new Audio(s); });
            if (_audio != null)
            {
                if (ImGui.Button("Play", new Vector2())) _audio.Play();
                ImGui.SameLine();
                if (ImGui.Button("Pause", new Vector2())) _audio.Pause();

                ImGui.ProgressBar(_audio.GetAudioPosition() / _audio.GetAudioLength(), new Vector2(400, 20));

                if (ImGui.Button("<<", new Vector2())) _audio.Back(1000000);
                ImGui.SameLine();
                if (ImGui.Button(">>", new Vector2())) _audio.Forward(1000000);
            }
        }
        ImGui.End();
    }
}