using ManagedBass;

namespace NervUI.Modules;

public class Audio
{
    private static bool _initialized = false;
    
    ~Audio()
    {
        Bass.Free();
    }

    internal static void Init()
    {
        if (_initialized) return;
        
        Bass.Init();

        _initialized = true;
    }

    private int _chan;
    
    public Audio(string filePath)
    {
        Bass.StreamFree(_chan);

        if ((_chan = Bass.CreateStream(filePath, 0, 0, BassFlags.Loop)) == 0)
        {
            MessageBox.ShowMessageBox("Audio Error", "This file can't be played");
        }
    }

    public void Play() => Bass.ChannelPlay(_chan);

    public void Pause() => Bass.ChannelPause(_chan);

    public void Stop() => Bass.ChannelStop(_chan);

    public void SetFX(EffectType type, int priority) => Bass.ChannelSetFX(_chan, type, priority);
    
    public void RemoveFX(int fx) => Bass.ChannelRemoveFX(_chan, fx);

    public void Forward(int amount)
    {
        Bass.ChannelSetPosition(_chan, (long)(GetAudioPosition() + amount));
    }
    
    public void Back(int amount)
    {
        Bass.ChannelSetPosition(_chan, (long)(GetAudioPosition() - amount));
    }

    public float GetAudioPosition()
    {
        return Bass.ChannelGetPosition(_chan);
    }
    public float GetAudioLength()
    {
        return Bass.ChannelGetLength(_chan);
    }
}