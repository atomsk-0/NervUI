using ManagedBass;

namespace NervUI.Modules;

public class Audio
{
    private static bool _initialized;

    private readonly int _chan;

    public string Path;

    public Audio(string filePath)
    {
        Bass.StreamFree(_chan);
        Path = filePath;
        if ((_chan = Bass.CreateStream(filePath, 0, 0, BassFlags.Loop)) == 0)
            MessageBox.ShowMessageBox("Audio Error", "This file can't be played");
    }

    ~Audio()
    {
        Bass.Free();
    }

    internal static void Init()
    {
        if (_initialized) return;

        Bass.Init();
        NervUIDebug.Log("BASS initialized");
        NervUIDebug.Log($"BASS version:           {Bass.Version}");

        _initialized = true;
    }

    public void Play()
    {
        Bass.ChannelPlay(_chan);
    }

    public void Pause()
    {
        Bass.ChannelPause(_chan);
    }

    public void Stop()
    {
        Bass.ChannelStop(_chan);
    }

    public void SetFX(EffectType type, int priority)
    {
        Bass.ChannelSetFX(_chan, type, priority);
    }

    public void RemoveFX(int fx)
    {
        Bass.ChannelRemoveFX(_chan, fx);
    }

    public void Forward(int amount)
    {
        Bass.ChannelSetPosition(_chan, (long)(GetAudioPosition() + amount));
    }

    public void Back(int amount)
    {
        Bass.ChannelSetPosition(_chan, (long)(GetAudioPosition() - amount));
    }

    public int GetChannel() => _chan;

    public float GetAudioPosition()
    {
        return Bass.ChannelGetPosition(_chan);
    }

    public float GetAudioLength()
    {
        return Bass.ChannelGetLength(_chan);
    }
}