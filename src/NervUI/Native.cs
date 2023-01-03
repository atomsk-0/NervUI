using System.Runtime.InteropServices;

namespace NervUI;

//Native Imports (Windows Only)
public static class NativeWindows
{
    //These may be used in future..
    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();
}