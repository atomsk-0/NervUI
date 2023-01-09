using System.Drawing;
using System.Numerics;
using System.Text;
using Silk.NET.Core.Contexts;
using Silk.NET.OpenGL;
using static Arqan.GLFW;

namespace Arqan;

internal static class Program
{
    private static GL _gl;
    private static void glfw_error_callback(int errorcode, string s)
    {
        Console.WriteLine($"Glfw Error {errorcode}: {s}");
    }
        
    private static int Main()
    {
        glfwSetErrorCallback(glfw_error_callback);
        if (glfwInit() == 0)
            return 1;
        
        glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
        glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 0);

        Window win = new Window("Test", new Vector2(1280, 720));
        var window = win.Handle;
        
        _gl = GL.GetApi(new DefaultNativeContext(@"opengl32.dll"));
        
        glfwMakeContextCurrent(window);
        glfwSwapInterval(1);

        while (glfwWindowShouldClose(window) == 0)
        {
            glfwPollEvents();
            
            uint display_w = 0;
            uint display_h = 0;
            _gl.Viewport(0, 0, display_w, display_h);
            _gl.ClearColor(0.4f, 0.4f, 0.6f, 1f);
            _gl.Clear(ClearBufferMask.ColorBufferBit);
            glfwSwapBuffers(window);
        }
        return 0;
    }
    
}