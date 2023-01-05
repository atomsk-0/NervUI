using System.Numerics;
using Mochi.DearImGui;
using Mochi.DearImGui.OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace NervUI;

public unsafe class GLFWWindow : NativeWindow
{
    private readonly string? GlslVersion;

    private readonly PlatformBackend PlatformBackend;

    private readonly RendererBackend RendererBackend;

    public List<Layer> Layers = new();

    public GLFWWindow(NativeWindowSettings nativeWindowSettings, string? glslVersion, ApplicationOptions options)
        : base(nativeWindowSettings)
    {
        GlslVersion = glslVersion;
        Context.MakeCurrent();
        VSync = VSyncMode.On;

        ImGui.CHECKVERSION();
        ImGui.CreateContext();
        var io = ImGui.GetIO();
        
        if (!options.DisableDocking)
            io->ConfigFlags |= ImGuiConfigFlags.DockingEnable;
        
        io->ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
        io->ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;

        ImGui.StyleColorsDark();

        var style = ImGui.GetStyle();
        
        if (io->ConfigFlags.HasFlag(ImGuiConfigFlags.ViewportsEnable))
        {
            style->WindowRounding = 0f;
            style->Colors[(int)ImGuiCol.WindowBg].W = 1f;
        }

        PlatformBackend = new PlatformBackend(this, true);
        RendererBackend = new RendererBackend(GlslVersion);
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
        RendererBackend.Dispose();
        PlatformBackend.Dispose();
        ImGui.DestroyContext();

        base.Dispose(disposing);
    }
}