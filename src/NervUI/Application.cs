using System.Drawing;
using ImGuiNET;
using Silk.NET.GLFW;
using Silk.NET.Input;
using Silk.NET.Input.Glfw;
using Silk.NET.Input.Sdl;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using Silk.NET.Windowing;
using Silk.NET.Windowing.Glfw;
using Silk.NET.Windowing.Sdl;

namespace NervUI;

public class Application
{

    private List<Layer> _layers = new List<Layer>();

    private static bool _initialized = false;
    
    public ApplicationOptions Options;
    
    public IWindow Window;

    public GL Gl;

    public IInputContext InputContext;

    public ImGuiController ImGuiController;

    //Register GLFW and SDL Platforms.
    private static void Init()
    {
        if (_initialized) return;
        SdlWindowing.RegisterPlatform();
        SdlInput.RegisterPlatform();
        GlfwWindowing.RegisterPlatform();
        GlfwInput.RegisterPlatform();
        _initialized = true;
    }


    public void CreateWindow()
    {
        var options = WindowOptions.Default;

        options.Size = new Vector2D<int>(Options.Width, Options.Height);
        options.Title = Options.Title;
        options.WindowBorder = Options.WindowBorder;
        options.WindowState = WindowState.Normal;

        options.API = new GraphicsAPI(ContextAPI.OpenGL, ContextProfile.Compatability, ContextFlags.Default,
            new APIVersion(4, 6));//TODO Maybe detect supported GAPI Render version from Graphics Device to add maximum compatibility

        Window = Silk.NET.Windowing.Window.Create(options);
        
        //Create Events
        Window.Load += WindowOnLoad;
        Window.FramebufferResize += WindowOnFramebufferResize;
        Window.Render += WindowOnRender;
    }

    private void WindowOnRender(double obj)
    {
        ImGuiController.Update((float)obj);
        Gl.ClearColor(Color.FromArgb(255, (int)(.45f * 255), (int)(.55f * 255), (int)(.60f * 255)));
        Gl.Clear((uint)ClearBufferMask.ColorBufferBit);

        foreach (var layer in _layers)
        {
            layer.OnUIRender();
        }

        ImGuiController.Render();
    }

    private void WindowOnFramebufferResize(Vector2D<int> obj) => Gl.Viewport(obj);

    private void WindowOnLoad()
    {
        ImGuiController = new ImGuiController(Gl = Window.CreateOpenGL(), Window, InputContext = Window.CreateInput());
        
        Window.Center();//Center window on start
        
#if DEBUG
        //Output render information if program running in debug mode
        unsafe
        {
            Console.WriteLine("--------------------Render Information--------------------");
            var api = Window.API.API.ToString();
            Console.WriteLine($"Render API              {api}");
            Console.WriteLine(
                $"Render API Version      {Window.API.Version.MajorVersion}.{Window.API.Version.MinorVersion}");
            Console.WriteLine($"Video Render Device     {new string((sbyte*)Gl.GetString(StringName.Renderer))}");
            Console.WriteLine($"Video Vendor            {new string((sbyte*)Gl.GetString(StringName.Vendor))}");
            Console.WriteLine($"Video Driver            {new string((sbyte*)Gl.GetString(StringName.Version))}");
            Console.WriteLine($"ImGui Version           {ImGui.GetVersion()}");
            Console.WriteLine("----------------------------------------------------------");
        }
#endif
        
        
    }

    public void Run()
    {
        Window.Run();
    }

    public static Application CreateApplication(ApplicationOptions options)
    {
        Init();
        
        Application application = new Application();
        
        application.Options = options;
        application.CreateWindow();
        
        return application;
    }
    
    public void PushLayer<T>()//TODO!
    {
        Type test = typeof(T).BaseType;
        Layer aa = (Layer)Activator.CreateInstance(test);
        _layers.Add(aa);
    }
}