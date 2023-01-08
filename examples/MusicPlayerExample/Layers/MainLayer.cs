using System.Numerics;
using ManagedBass;
using Mochi.DearImGui;
using NervUI;
using NervUI.Modules;

namespace MusicPlayerExample.Layers;

public class MainLayer : Layer
{
    public static Audio Audio;

    public float vol = 1;
    public override unsafe void OnUIRender()
    {
        ImGui.Begin("Music Player", null, ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove);
        if (Audio == null)
            ImGui.Text("Select song to play from file -> open");
        else
        {
            float v = vol;
            ImGui.Text(Audio.Path.Split(@"\").Last());
            ImGui.Separator();

            if (ImGui.Button("Play", new Vector2())) Audio.Play();
            ImGui.SameLine();
            if (ImGui.Button("Pause", new Vector2())) Audio.Pause();
            ImGui.SameLine();
            if (ImGui.Button("Stop", new Vector2())) Audio.Stop();
            ImGui.SameLine();
            if (ImGui.Button("<<", new Vector2())) Audio.Back(100000);
            ImGui.SameLine();
            if (ImGui.Button(">>", new Vector2())) Audio.Forward(100000);

            ImGui.DragFloat("Volume", &v, 0.01f, 0f, 1f, "%f");
            vol = v;
            Bass.Volume = vol;
            ImGui.Separator();
            ImGui.ProgressBar(Audio.GetAudioPosition() / Audio.GetAudioLength(), new Vector2(400, 20));
        }
        ImGui.End();
    }
}