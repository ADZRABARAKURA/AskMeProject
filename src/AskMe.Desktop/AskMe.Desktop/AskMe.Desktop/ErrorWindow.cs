using System.Windows;

namespace AskMe.Desktop;

public static class ErrorWindow
{
    public static void ShowError(string error)
    {
        MessageBox.Show(error);
    }
}
