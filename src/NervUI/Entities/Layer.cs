using OpenTK.Windowing.Common;

namespace NervUI;

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
}