using System.Runtime.InteropServices;
using Mochi.DearImGui;
using NervUI.Common;
using NervUI.Entities;
using NervUI.Framework;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Common.Input;
using OpenTK.Windowing.Desktop;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;
using Image = OpenTK.Windowing.Common.Input.Image;

namespace NervUI;

public unsafe class Application
{
    internal static Application Instance;
    public ApplicationOptions Options { get; private set; }
    public NervWindow Window { get; private set; }

    internal List<Layer> Layers = new();

    internal NervFont DefaultFont;

    internal List<NervFont> Fonts = new();

    /// <summary>
    /// Create new instance of Application
    /// </summary>
    /// <param name="options">Options for Application</param>
    /// <returns>Returns new instance of Application</returns>
    public static Application CreateApplication(ApplicationOptions options)
    {
        Core.Initialize();

        Application app = new Application();
        app.Options = options;
        Instance = app;

        return app;
    }

    /// <summary>
    /// Add layer to Render queue
    /// </summary>
    /// <param name="layer">Render Layer</param>
    public void PushLayer(Layer layer)
        => Layers.Add(layer);

    /// <summary>
    /// Remove layer from Render queue
    /// </summary>
    /// <param name="layer">Render Layer</param>
    public void RemoveLayer(Layer layer)
        => Layers.Remove(layer);
    
    /// <summary>
    /// Setup MenuBar for Application
    /// </summary>
    /// <param name="action">Action what is called on this callback</param>
    public void SetMenuBarCallback(Action action)
        => Window.MenuBarCallback = action;
    
    /// <summary>
    /// Setup Dockspace for Application
    /// </summary>
    /// <param name="action">Action what is called on this callback</param>
    public void SetDockspaceCallback(Action<uint> action)
        => Window.DockSpaceCallback = action;

    /// <summary>
    /// Called when application is closing
    /// </summary>
    /// <param name="action">Action what is called on this callback</param>
    public void SetApplicationClosingCallback(Action action)
        => Window.ApplicationClosing = action;

    /// <summary>
    /// Called when window is loaded
    /// </summary>
    /// <param name="action">Action what is called on this callback</param>
    public void SetWindowLoadCallback(Action action)
        => Window.WindowLoad = action;

    /// <summary>
    /// Called when File is being dropped to the window
    /// </summary>
    /// <param name="action">Action what is called on this callback</param>
    public void SetFileDropCallback(Action<FileDropEventArgs> action)
        => Window.FileDrop = action;

    /// <summary>
    /// Called when window focus is changed
    /// </summary>
    /// <param name="action">Action what is called on this callback</param>
    public void SetFocusChangedCallback(Action<FocusedChangedEventArgs> action)
        => Window.FocusChanged = action;

    /// <summary>
    /// Called when any mouse button is pushed down
    /// </summary>
    /// <param name="action">Action what is called on this callback</param>
    public void SetMouseDownCallback(Action<MouseButtonEventArgs> action)
        => Window.MouseDown = action;

    /// <summary>
    /// Called when any key is released
    /// </summary>
    /// <param name="action">Action what is called on this callback</param>
    public void SetKeyUpCallback(Action<KeyboardKeyEventArgs> action)
        => Window.KeyUp = action;
    
    /// <summary>
    /// Called when any key is pushed down
    /// </summary>
    /// <param name="action">Action what is called on this callback</param>
    public void SetKeyDownCallback(Action<KeyboardKeyEventArgs> action)
        => Window.KeyDown = action;

    /// <summary>
    /// Change ImGui Default font
    /// </summary>
    /// <param name="font"></param>
    public void SetDefaultFont(NervFont font)
        => DefaultFont = font;
    
    /// <summary>
    /// Finds font by fontName from Fonts and calls ImGui.PushFont for it.
    /// </summary>
    /// <param name="fontName">Font name you want to push</param>
    public unsafe void PushFont(string fontName)
    {
        var font = Fonts.Find(c => c.Name == fontName);
        if (font == null)
        {
            Core.Log($"Failed to load font {fontName}.", LogType.ERROR, ConsoleColor.Red);
            return;
        }

        ImGui.PushFont(font.FontData);
    }
    
    /// <summary>
    /// Add font to fonts list
    /// </summary>
    /// <param name="font"></param>
    public void AddFont(NervFont font)
    {
        var io = ImGui.GetIO();
        Fonts.Add(font);
        font.FontData = io->Fonts->AddFontFromFileTTF(font.Path, font.Size);
        font.Loaded = true;
    }

    /// <summary>
    /// Starts Window Loop
    /// </summary>
    public void Run()
        => Window.Run();

    /// <summary>
    /// Creates new Window
    /// </summary>
    public void CreateWindow()
    {
        var nativeWindowSettings = new NativeWindowSettings
        {
            Title = Options.Title,
            Size = new Vector2i(Options.Width, Options.Height),
            APIVersion = new Version(Options.OpenGlVersion.Major, Options.OpenGlVersion.Minor),
            API = ContextAPI.OpenGL,
            Profile = ContextProfile.Core
        };

        this.Window = new NervWindow(nativeWindowSettings, Options, this);
    }

    /// <summary>
    /// Disable NervUI Logs
    /// </summary>
    public static void DisableLogs()
        => Core.LogsEnabled = false;

    /// <summary>
    /// Turn image to OpenTK WindowIcon
    /// </summary>
    /// <param name="path">path to image file</param>
    /// <returns>WindowIcon</returns>
    public static WindowIcon GetIcon(string path)
    {
        var image = (Image<Rgba32>)SixLabors.ImageSharp.Image.Load(Configuration.Default, path);
        var _IMemoryGroup = image.GetPixelMemoryGroup();
        var _MemoryGroup = _IMemoryGroup.ToArray()[0];
        var PixelData = MemoryMarshal.AsBytes(_MemoryGroup.Span).ToArray();
        var windowIcon = new WindowIcon(new OpenTK.Windowing.Common.Input.Image(image.Width, image.Height, PixelData));

        return windowIcon;
    }

    ~Application()
    {
        Layers.Clear();
        DefaultFont = null;
        Fonts.Clear();
    }
}