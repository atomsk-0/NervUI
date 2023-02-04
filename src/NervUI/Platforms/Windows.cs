using System.Runtime.InteropServices;

namespace NervUI.Platforms;

//Here comes stuff for Windows if needed.
public static class Windows
{
    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();
    
    public static string DefaultFilePath = $"C:\\Users\\{Environment.UserName}";
    
    public static void DragMove(IntPtr hWnd)
    {
        ReleaseCapture();
        SendMessage(hWnd, 0xA1, 0x2, 0);
    }
}