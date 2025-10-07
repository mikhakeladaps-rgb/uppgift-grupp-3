using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Data;

namespace AddressBook.WPF.ViewModels;

public partial class MainViewModel : ObservableObject
{
    #region Observable properties
    [ObservableProperty] public string titel;
    #endregion

    #region Constructor
    public MainViewModel()
    {
        Titel = "AdressBok";
    }
    #endregion

    #region RelayCommands
    [RelayCommand]
    public void NewContact()
    {
        //  öppna nytt fönster för att lägga till kontakt
    }

    [RelayCommand]
    public void Quit()
    {
        Application.Current.Shutdown();
    }
    #endregion
}