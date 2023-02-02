using Mochi.DearImGui;

namespace NervUI.Entities;

public unsafe class NervFont
{
    public string Name { get; private set; }
    
    public string Path { get; private set; }
    
    public float Size { get; private set; }
    
    public ImFont* FontData { get; set; }

    public NervFont(string name, string path, float size)
    {
        Name = name;
        Path = path;
        Size = size;
    }
    
    internal bool Loaded = false;
}