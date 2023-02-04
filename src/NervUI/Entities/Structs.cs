using OpenTK.Windowing.Common;


namespace NervUI.Entities;

public struct ApplicationOptions
{
    public string Title { get; set; }
    public ushort Width { get; set; }
    public ushort Height { get; set; }
    /// <summary>
    /// Its recommended that VSync is turned on to avoid useless high resource usage what causes more power usage.
    /// </summary>
    public bool VSync { get; set; }
    /// <summary>
    /// By default it's set to 3.3 and its the recommended version since most modern computers support this version
    /// </summary>
    public OpenGLVersion OpenGlVersion { get; set; }
    public WindowState WindowState { get; set; }
    public WindowBorder WindowBorder { get; set; }
    
    //Experimental currently supports only Windows. if disabled it removes Window borders and turn the imgui as window borders
    public bool NativeWindow { get; set; }
    
    /// <summary>
    /// Disabling Docking disables ImGui Docking system by default it's enabled
    /// </summary>
    public bool Docking { get; set; }
    
    public Action StyleCallback { get; set; }

    public ApplicationOptions()
    {
        Title = "NervUI Application";
        Width = 1280;
        Height = 720;
        VSync = true;
        OpenGlVersion = new OpenGLVersion();
        WindowState = WindowState.Normal;
        WindowBorder = WindowBorder.Resizable;
        Docking = true;
        StyleCallback = null;
        NativeWindow = true;
    }
}

public struct OpenGLVersion
{
    public ushort Major { get; set; }
    public ushort Minor { get; set; }

    public OpenGLVersion()
    {
        Major = 3;
        Minor = 3;
    }
}