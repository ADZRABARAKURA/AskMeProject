//*-+ System;
using System.Windows;
using System.Windows.Media.Imaging;
using System;
using AskMe.Desktop.ViewModels;

namespace AskMe.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        var icon = new BitmapImage(new Uri("./Resources/logo.png", UriKind.Relative));
        this.Icon = icon;
        this.DataContext = new AuthViewModel();
        InitializeComponent();
    }
}
