using System.Drawing;
using OpenTK.Windowing.Common;

namespace NervUI;

public struct ApplicationOptions
{
    public string Title { get; set; }
    public Point Size { get; set; }
    public bool DisableDocking { get; set; }
    public WindowBorder WindowBorder { get; set; }
    public WindowState WindowState { get; set; }

    public NervFont DefaultFont { get; set; }

    public ApplicationOptions()
    {
        Title = "NervUI Application";
        Size = new Point(1280, 72);
        WindowState = WindowState.Normal;
        WindowBorder = WindowBorder.Resizable;
        DisableDocking = false;
        DefaultFont = null;
    }
}