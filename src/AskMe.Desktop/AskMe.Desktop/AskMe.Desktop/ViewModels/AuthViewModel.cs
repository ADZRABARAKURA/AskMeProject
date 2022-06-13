using AskMe.Desktop.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.ComponentModel;
using RestSharp;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AskMe.Desktop.ViewModels;

public class AuthViewModel : INotifyPropertyChanged
{
    public RelayCommand AuthenticateCommand { get; } 

    public string UserIdentifier { get; set; }

    public string Password { get; set; }


    public event PropertyChangedEventHandler? PropertyChanged;

    public AuthViewModel()
    {
        PropertyChanged += AuthViewModel_PropertyChanged;
        AuthenticateCommand = new RelayCommand(AuthenticateCommandExecute);
    }

    public async void AuthenticateCommandExecute()
    {
        try
        {
            var apiService = new ApiService(new AuthService());
            await apiService.AuthenticateUser(UserIdentifier, Password);
        }
        catch(ArgumentException ex)
        {
            ErrorWindow.ShowError(ex.Message);
        }
    }

    private void AuthViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
    }
}
