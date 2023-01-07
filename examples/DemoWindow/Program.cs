using System.Drawing;
using System.Windows;
using DemoWindow.Layouts;
using Mochi.DearImGui;
using Mochi.DearImGui.Internal;
using NervUI;
using NervUI.Modules;

namespace DemoWindow;

internal static class Program
{
    private static Application _application;
    private static bool g_applicationRunning = true;

    public static string imageLocation = "";

    private static NotifyIcon _notifyIcon;

    private static unsafe void Main()
    {
        NotifyIconExample();
        //Create main loop for the application
        while (g_applicationRunning)
        {
            //Options for App
            var options = new ApplicationOptions
            {
                Title = "NervUI Demo Window",
                Size = new Point(1280, 720),
                DefaultFont = new NervFont("Roboto", "Fonts/Roboto-Medium.ttf", 16f) //Set this as new DefaultFont
            };

            //Create new instance of the application
            _application = Application.CreateApplication(options);

            //Add other custom font named as Roboto-BlackItalic
            _application.AddFont(new NervFont("Roboto-BlackItalic", "Fonts/Roboto-BlackItalic.ttf", 16f));

            //Push DemoLayer and DemoLayer2 for the renderer
            _application.PushLayer<DemoLayer>();
            _application.PushLayer<DemoLayer2>();
            _application.PushLayer<TextEditor>();

            //Create Menubar for app
            _application.SetMenuBarCallback(() =>
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGuiManaged.MenuItem("Open", ""))
                        FileDialog.ShowFileDialog("C:\\", FileDialogType.OpenFile, delegate(string s)
                        {
                            Console.WriteLine(s);
                            //Prints the selected path/file location
                        });
                    if (ImGuiManaged.MenuItem("MessageBox", "")) MessageBox.ShowMessageBox("Hello World", "Test");
                    if (ImGuiManaged.MenuItem("Exit", "")) _application.Exit();
                    ImGui.EndMenu();
                }
            });

            //Create dockspace config
            _application.SetDockspaceCallback((u, flags) =>
            {
                var dockspace_id = u;

                var dock_id_left =
                    ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Left, 0.2f, null, &dockspace_id);
                var dock_id_right =
                    ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Right, 0.25f, null, &dockspace_id);
                var dock_id_down =
                    ImGuiInternal.DockBuilderSplitNode(dockspace_id, ImGuiDir.Down, 0.25f, null, &dockspace_id);

                ImGuiInternal.DockBuilderDockWindow("Dear ImGui Demo", dock_id_right);
                ImGuiInternal.DockBuilderDockWindow("NervUI Demo", dock_id_left);
                ImGuiInternal.DockBuilderDockWindow("TextEditor Demo", dock_id_down);
                ImGuiInternal.DockBuilderFinish(dockspace_id);
            });

            //Run application
            _application.Run();

            g_applicationRunning = false;
        }

        _application.Exit();
    }

    private static void NotifyIconExample()
    {
        _notifyIcon = NotifyIcon.Create();
        //_notifyIcon.Icon = new Bitmap("path to icon");
        _notifyIcon.Text = "NervUI Example";
        var menuItem = new ContextMenuStrip.MenuItem();
        menuItem.Text = "Exit";
        menuItem.Visible = true;
        menuItem.Click += (sender, args) => _application.Exit();
        _notifyIcon.ContextMenuStrip.Items.Add(menuItem);
        _notifyIcon.Visible = true;
        _notifyIcon.ShowBalloonTip("Hello", "test", ToolTipIcon.Info);
    }
}