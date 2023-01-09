using System.Numerics;
using System.Text;

namespace Arqan;

public class Window
{
    public IntPtr Handle;

    public Vector2 Size;

    public string Title = "";
    
    public Window(string title, Vector2 size)
    {
        Size = size;
        Title = title;
        Handle = GLFW.glfwCreateWindow((int)Size.X, (int)Size.Y, Encoding.ASCII.GetBytes(Title), IntPtr.Zero, IntPtr.Zero);
    }
}