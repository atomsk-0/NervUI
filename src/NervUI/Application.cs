using Mochi.DearImGui;
using NervUI.Modules;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace NervUI;

public class Application : IDisposable
{
    public delegate void MenuBarDelegate();

    internal static List<NervFont> Fonts = new();
    public ApplicationOptions Options;

    public GLFWWindow Window;

    public void Dispose()
    {
        Window.Dispose();
        GC.SuppressFinalize(this);
    }

    public event MenuBarDelegate MenuBar;

    private void CreateWindow()
    {
        var nativeWindowSettings = new NativeWindowSettings
        {
            Size = new Vector2i(Options.Size.X, Options.Size.Y),
            Title = Options.Title,
            APIVersion = new Version(3, 0),
            Profile = ContextProfile.Any
        };

        Window = new GLFWWindow(nativeWindowSettings, "#version 130", Options, this);
        Window.CenterWindow();
    }

    public static Application CreateApplication(ApplicationOptions options)
    {
        Audio.Init();
        var application = new Application();

        application.Options = options;
        application.CreateWindow();

        return application;
    }

    public void PushLayer<T>()
    {
        var layer = (Layer)Activator.CreateInstance(typeof(T));
        Window.Layers.Add(layer);
    }

    public static unsafe void PushFont(string fontName)
    {
        var font = Fonts.Find(c => c.Name == fontName);
        if (font == null)
        {
            Console.WriteLine($"ERROR: Failed to find font {fontName}. [NervUI]");
            return;
        }

        ImGui.PushFont(font.FontData);
    }

    public void SetMenuBarCallback(Action action)
    {
        Window.menuBarCallback = action;
    }
    
    public void SetDockspaceCallback(Action<uint, ImGuiDockNodeFlags> action)
    {
        Window.dockSpaceCallback = action;
    }

    public static void PopFont()
    {
        ImGui.PopFont();
    }

    public void AddFont(NervFont font)
    {
        Fonts.Add(font);
        Window.RefreshFonts();
    }

    public void Run()
    {
        Window.Run();
    }

    public void Exit()
    {
        Environment.Exit(0);
    }

    ~Application()
    {
        Dispose();
    }
}