using System.Runtime.Serialization;
using NervUI.Common;
using NervUI.Entities;
using NervUI.Framework;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace NervUI;

public class Application
{
    public ApplicationOptions Options { get; private set; }
    public NervWindow Window { get; private set; }
    
    public delegate void MenuBarDelegate();

    internal List<Layer> Layers = new();

    public static Application CreateApplication(ApplicationOptions options)
    {
        Core.Initialize();

        Application app = new Application();
        app.Options = options;

        return app;
    }

    //AOT Does not support reflection so this method is disabled for now maybe will use mapper to do the trick
    /*public void PushLayer<T>()
    {
        //=> Layers.Add(((Layer)Activator.CreateInstance(typeof(T))));
        //var mapper = typeof(T);
        //Layers.Add((Layer)FormatterServices.GetSafeUninitializedObject(typeof(T)));
    }*/

    public void PushLayer(Layer layer)
        => Layers.Add(layer);
    
    public void SetMenuBarCallback(Action action)
        => Window.MenuBarCallback = action;
    
    public void SetDockspaceCallback(Action<uint> action)
        => Window.DockSpaceCallback = action;

    public void Run()
        => Window.Run();

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

    public static void DisableLogs()
        => Core.LogsEnabled = false;
}