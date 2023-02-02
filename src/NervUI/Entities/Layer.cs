using OpenTK.Windowing.Common;

namespace NervUI.Entities;

public class Layer
{
    public virtual void OnUIRender()
    {
    }

    public virtual void OnWindowLoad()
    {
    }

    public virtual void OnFileDrop(FileDropEventArgs e)
    {
    }

    public virtual void OnFocusedChanged(FocusedChangedEventArgs e)
    {
    }

    public virtual void OnMouseDown(MouseButtonEventArgs e)
    {
    }
    
    public virtual void OnKeyUp(KeyboardKeyEventArgs obj)
    {
    }

    public virtual void OnKeyDown(KeyboardKeyEventArgs obj)
    {
    }
}