using Silk.NET.Windowing;

namespace NervUI;

public struct ApplicationOptions
{
    public string Title { get; set; }
    
    public int Width { get; set; }
    
    public int Height { get; set; }
    
    public WindowBorder WindowBorder { get; set; }
    
    public WindowState WindowState { get; set; }

    public ApplicationOptions()
    {
        Title = "Debug";
        Width = 1250;
        Height = 850;
        WindowBorder = WindowBorder.Resizable;
        WindowState = WindowState.Normal;
    }
}