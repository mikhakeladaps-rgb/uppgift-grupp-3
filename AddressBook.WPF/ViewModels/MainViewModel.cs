using AddressBook.WPF.Controls;
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

    #region Properties
    private string _searchText;
    public string SearchText
    {
        get { return _searchText; }
        set
        {
            _searchText = value;
            OnPropertyChanged();
            // Refresh filtering here
        }
    }
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
        var vm = new NewContactViewModel();
        //  öppna nytt fönster för att lägga till kontakt
        NewContactWnd wnd = new NewContactWnd()
        {
            DataContext = vm
        };
        wnd.ShowDialog();

        if (vm.WasSaved)
        {
            // TODO: Spara kontakten
            // vm.NewContact
        }
    }

    [RelayCommand]
    public void Quit()
    {
        Application.Current.Shutdown();
    }
    #endregion
}