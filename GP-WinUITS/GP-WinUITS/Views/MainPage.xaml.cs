using GP_WinUITS.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace GP_WinUITS.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
