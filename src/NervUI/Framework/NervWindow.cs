using System.Numerics;
using Mochi.DearImGui;
using Mochi.DearImGui.Internal;
using Mochi.DearImGui.OpenTK;
using NervUI.Common;
using NervUI.Entities;
using NervUI.Framework.Modules;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace NervUI.Framework;

//TODO (ALL CLASSES) Clean and optimize code.

public unsafe class NervWindow : NativeWindow
{
    private static bool _firstTime = true;
    
    private PlatformBackend _platformBackend;
    private RendererBackend _rendererBackend;

    internal Action<uint> DockSpaceCallback;
    internal Action MenuBarCallback;
    internal Action StyleCallback;
    internal Application Instance;

    public NervWindow(NativeWindowSettings nativeWindowSettings, ApplicationOptions options, Application instance) : base(nativeWindowSettings)
    {
        Instance = instance;
        Context.MakeCurrent();
        VSync = options.VSync ? VSyncMode.On : VSyncMode.Off;
        WindowBorder = options.WindowBorder;
        WindowState = options.WindowState;
        GL.LoadBindings(new GLFWBindingsContext());
        CenterWindow();

        ImGui.CreateContext();
        var io = ImGui.GetIO();
        
        string glsl_version = "#version 130";
        
        if (options.Docking)
            io->ConfigFlags |= ImGuiConfigFlags.DockingEnable;
        
        io->ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
        io->ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;

        if (Instance.DefaultFont != null)
        {
            Instance.DefaultFont.FontData =
                io->Fonts->AddFontFromFileTTF(Instance.DefaultFont.Path, Instance.DefaultFont.Size);
            io->FontDefault = Instance.DefaultFont.FontData;
            Instance.DefaultFont.Loaded = true;
        }
        
        
        foreach (var font in Instance.Fonts.Where(c => c.Loaded == false))
        {
            Core.Log($"Loaded font {font.Name} from {font.Path}", LogType.DEBUG);
            font.FontData = io->Fonts->AddFontFromFileTTF(font.Path, font.Size);
            font.Loaded = true;
        }
        
        var style = ImGui.GetStyle();

        if (StyleCallback == null)
            Util.SetStyle();
        else
            StyleCallback();

        if (io->ConfigFlags.HasFlag(ImGuiConfigFlags.ViewportsEnable))
        {
            style->WindowRounding = 1f;
            style->Colors[(int)ImGuiCol.WindowBg].W = 1f;
        }

        _platformBackend = new(this, true);
        _rendererBackend = new(glsl_version);
        
        //Log render info
        {
            Core.Log("--------------------Render Information--------------------", LogType.INFO, ConsoleColor.Yellow);
            Core.Log($"Render API:           {API}", LogType.INFO, ConsoleColor.Yellow);
            Core.Log($"Render API Version:   {APIVersion.Major}.{APIVersion.Minor}", LogType.INFO, ConsoleColor.Yellow);
            Core.Log($"Video Render Device:  {GL.GetString(StringName.Renderer)}", LogType.INFO, ConsoleColor.Yellow);
            Core.Log($"Video Vendor:         {GL.GetString(StringName.Vendor)}", LogType.INFO, ConsoleColor.Yellow);
            Core.Log($"Video Driver:         {GL.GetString(StringName.Version)}", LogType.INFO, ConsoleColor.Yellow);
            Core.Log($"ImGui Version:         {ImGui.IMGUI_VERSION}", LogType.INFO, ConsoleColor.Yellow);
            Core.Log("----------------------------------------------------------", LogType.INFO, ConsoleColor.Yellow);
        }
        
        foreach (var layer in Instance.Layers)
            layer.OnWindowLoad();
    }
    
    internal void Run()
    {
        var io = ImGui.GetIO();
        Vector3 clearColor = new(0.45f, 0.55f, 0.6f);
        
        while (!GLFW.WindowShouldClose(WindowPtr))
        {
            ProcessEvents();
            
            _rendererBackend.NewFrame();
            _platformBackend.NewFrame();
            ImGui.NewFrame();
            FileDialog.RenderFileDialog();
            //Dockspace and MenuBar
            {
                var dockNodeFlags = ImGuiDockNodeFlags.None;
                var windowFlags = ImGuiWindowFlags.NoDocking;
                
                if (MenuBarCallback != null)
                    windowFlags |= ImGuiWindowFlags.MenuBar;
                
                var viewport = ImGui.GetMainViewport();
                
                ImGui.SetNextWindowPos(new Vector2(viewport->WorkPos.X, viewport->WorkPos.Y), ImGuiCond.None, new Vector2(0, 0));
                ImGui.SetNextWindowSize(viewport->WorkSize);
                ImGui.SetNextWindowViewport(viewport->ID);

                windowFlags |= ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize |
                               ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoBringToFrontOnFocus |
                               ImGuiWindowFlags.NoNavFocus;
                
                if (dockNodeFlags.HasFlag(ImGuiDockNodeFlags.PassthruCentralNode))
                    windowFlags |= ImGuiWindowFlags.NoBackground;
                
                ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(0, 0));
                ImGui.Begin("NervUI Dockspace", null, windowFlags);
                ImGui.PopStyleVar();
                
                if (io->ConfigFlags.HasFlag(ImGuiConfigFlags.DockingEnable))
                {
                    var dockspace_id = ImGui.GetID("OpenGLAppDockspace");
                    ImGui.DockSpace(dockspace_id, new Vector2(0, 0), dockNodeFlags);

                    if (_firstTime)
                    {
                        _firstTime = false;

                        ImGuiInternal.DockBuilderRemoveNode(dockspace_id);
                        ImGuiInternal.DockBuilderAddNode(dockspace_id, dockNodeFlags);
                        ImGuiInternal.DockBuilderSetNodeSize(dockspace_id, viewport->Size);

                        if (DockSpaceCallback != null)
                            DockSpaceCallback(dockspace_id);//dockNodeFlags
                    }
                }
                
                if (MenuBarCallback != null)
                    if (ImGui.BeginMenuBar())
                    {
                        MenuBarCallback();
                        ImGui.EndMenuBar();
                    }
                
                if (MessageBox.showMB)
                {
                    ImGui.OpenPopup("MessageBoxPopup");
                    MessageBox.RenderMessageBox();
                }
            }

            foreach (var layer in Instance.Layers)
                layer.OnUIRender();

            {
                ImGui.Render();
                GLFW.GetFramebufferSize(WindowPtr, out var displayW, out var displayH);
                GL.Viewport(0, 0, displayW, displayH);
                GL.ClearColor(clearColor.X, clearColor.Y, clearColor.Z, 1f);
                GL.Clear(ClearBufferMask.ColorBufferBit);
                _rendererBackend.RenderDrawData(ImGui.GetDrawData());

                if (io->ConfigFlags.HasFlag(ImGuiConfigFlags.ViewportsEnable))
                {
                    var backupCurrentContext = GLFW.GetCurrentContext();
                    ImGui.UpdatePlatformWindows();
                    ImGui.RenderPlatformWindowsDefault();
                    GLFW.MakeContextCurrent(backupCurrentContext);
                }

                GLFW.SwapBuffers(WindowPtr);
            }
        }
    }

    ~NervWindow()
    {
        //TODO Free memory.
    }
}