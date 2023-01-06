using Mochi.DearImGui;

namespace NervUI;

public unsafe class NervFont
{
    public string Name { get; set; }
    
    public string FontPath { get; set; }
    
    public float FontSize { get; set; }
    
    public ImFont* FontData { get; set; }
    
    public NervFont DefaultFont { get; set; }

    internal bool Loaded = false;

    public NervFont(string name, string fontPath, float fontSize, NervFont defaultFont = null)
    {
        Name = name;
        FontPath = fontPath;
        FontSize = fontSize;
        DefaultFont = defaultFont;
    }
}