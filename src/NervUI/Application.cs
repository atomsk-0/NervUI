using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace NervUI;

public class Application
{
    public ApplicationOptions Options;

    public GLFWWindow Window;

    private void CreateWindow()
    {
        var nativeWindowSettings = new NativeWindowSettings
        {
            Size = new Vector2i(Options.Size.X, Options.Size.Y),
            Title = Options.Title,
            APIVersion = new Version(3, 0),
            Profile = ContextProfile.Any,
        };

        Window = new GLFWWindow(nativeWindowSettings, "#version 130", Options);
        Window.CenterWindow();
    }

    public static Application CreateApplication(ApplicationOptions options)
    {
        var application = new Application();

        application.Options = options;
        application.CreateWindow();

        return application;
    }
    
    public void PushLayer<T>()//TODO!
    {
       Layer layer = (Layer)Activator.CreateInstance(typeof(T));
       Window.Layers.Add(layer);
    }
    
    public void Run() => Window.Run();

    public void Exit() => Environment.Exit(0);
}

//TODO ADD CUSTOM FONT SUPPORT
//TODO ADD MORE EVENTS