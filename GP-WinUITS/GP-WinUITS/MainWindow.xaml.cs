using GP_WinUITS.Helpers;

namespace GP_WinUITS;

public sealed partial class MainWindow : WindowEx
{
    public MainWindow()
    {
        InitializeComponent();
        AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "/Assets/GPico64.ico"));
        Content = null;
        Title = "AppDisplayName".GetLocalized();
    }
}
