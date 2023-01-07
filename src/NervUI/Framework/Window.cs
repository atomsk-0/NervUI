using System.Numerics;
using Mochi.DearImGui;
using Mochi.DearImGui.Internal;
using Mochi.DearImGui.OpenTK;
using NervUI.Modules;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace NervUI;

public unsafe class GLFWWindow : NativeWindow
{
    private static bool firstTime = true;
    private readonly string? GlslVersion;

    private readonly PlatformBackend PlatformBackend;

    private readonly RendererBackend RendererBackend;

    private Application _applicationInstance;

    internal Action<uint, ImGuiDockNodeFlags> dockSpaceCallback;

    public List<Layer> Layers = new();

    internal Action menuBarCallback;

    public GLFWWindow(NativeWindowSettings nativeWindowSettings, string? glslVersion, ApplicationOptions options,
        Application application)
        : base(nativeWindowSettings)
    {
        _applicationInstance = application;
        GlslVersion = glslVersion;
        Context.MakeCurrent();
        VSync = VSyncMode.On;

        ImGui.CHECKVERSION();
        ImGui.CreateContext();
        var io = ImGui.GetIO();

        // Util.SetStyle();


        if (!options.DisableDocking)
            io->ConfigFlags |= ImGuiConfigFlags.DockingEnable;

        io->ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
        io->ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;


        if (options.DefaultFont != null)
        {
            options.DefaultFont.FontData =
                io->Fonts->AddFontFromFileTTF(options.DefaultFont.FontPath, options.DefaultFont.FontSize);
            options.DefaultFont.Loaded = true;
            io->FontDefault = options.DefaultFont.FontData;
        }

        io->Fonts->AddFontDefault();
        RefreshFonts();


        var style = ImGui.GetStyle();
        Util.SetStyle();

        if (io->ConfigFlags.HasFlag(ImGuiConfigFlags.ViewportsEnable))
        {
            style->WindowRounding = 1f;
            style->Colors[(int)ImGuiCol.WindowBg].W = 1f;
        }

        PlatformBackend = new PlatformBackend(this, true);
        RendererBackend = new RendererBackend(GlslVersion);


        foreach (var layer in Layers)
            layer.OnWindowLoad();
    }

    public void RefreshFonts()
    {
        var io = ImGui.GetIO();
        foreach (var font in Application.Fonts.Where(c => c.Loaded == false))
        {
            Console.WriteLine("Loaded font " + font.FontPath);
            font.FontData = io->Fonts->AddFontFromFileTTF(font.FontPath, font.FontSize);
            font.Loaded = true;
        }
    }

    public void Run()
    {
        var io = ImGui.GetIO();
        ;
        Vector3 clearColor = new(0.45f, 0.55f, 0.6f);

        var f = 0f;
        var counter = 0;

        while (!GLFW.WindowShouldClose(WindowPtr))
        {
            ProcessEvents();

            RendererBackend.NewFrame();
            PlatformBackend.NewFrame();
            ImGui.NewFrame();
            FileDialog.RenderFileDialog();
            {
                var dockNodeFlags = ImGuiDockNodeFlags.None;

                var windowFlags = ImGuiWindowFlags.NoDocking;

                if (menuBarCallback != null)
                    windowFlags |= ImGuiWindowFlags.MenuBar;

                var viewport = ImGui.GetMainViewport();
                ImGui.SetNextWindowPos(new Vector2(viewport->WorkPos.X, viewport->WorkPos.Y), ImGuiCond.None,
                    new Vector2(0, 0));
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


                var iox = ImGui.GetIO();
                if (io->ConfigFlags.HasFlag(ImGuiConfigFlags.DockingEnable))
                {
                    var dockspace_id = ImGui.GetID("OpenGLAppDockspace");
                    ImGui.DockSpace(dockspace_id, new Vector2(0, 0), dockNodeFlags);

                    if (firstTime)
                    {
                        firstTime = false;

                        ImGuiInternal.DockBuilderRemoveNode(dockspace_id);
                        ImGuiInternal.DockBuilderAddNode(dockspace_id, dockNodeFlags);
                        ImGuiInternal.DockBuilderSetNodeSize(dockspace_id, viewport->Size);

                        if (dockSpaceCallback != null)
                            dockSpaceCallback(dockspace_id, dockNodeFlags);
                    }
                }

                if (menuBarCallback != null)
                    if (ImGui.BeginMenuBar())
                    {
                        menuBarCallback();
                        ImGui.EndMenuBar();
                    }

                if (MessageBox.showMB)
                {
                    ImGui.OpenPopup("MessageBoxPopup");
                    MessageBox.RenderMessageBox();
                }
            }
            //RENDER IMGUI HERE


            foreach (var layer in Layers)
                layer.OnUIRender();
            {
                ImGui.Render();
                GLFW.GetFramebufferSize(WindowPtr, out var displayW, out var displayH);
                GL.Viewport(0, 0, displayW, displayH);
                GL.ClearColor(clearColor.X, clearColor.Y, clearColor.Z, 1f);
                GL.Clear(ClearBufferMask.ColorBufferBit);
                RendererBackend.RenderDrawData(ImGui.GetDrawData());

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

    protected override void Dispose(bool disposing)
    {
        Layers.Clear();
        RendererBackend.Dispose();
        PlatformBackend.Dispose();
        ImGui.DestroyContext();

        base.Dispose(disposing);
    }

    protected override void OnFileDrop(FileDropEventArgs e)
    {
        foreach (var layer in Layers)
            layer.OnFileDrop(e);
        base.OnFileDrop(e);
    }

    protected override void OnFocusedChanged(FocusedChangedEventArgs e)
    {
        foreach (var layer in Layers)
            layer.OnFocusedChanged(e);
        base.OnFocusedChanged(e);
    }
}