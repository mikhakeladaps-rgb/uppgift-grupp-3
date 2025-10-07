using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
}