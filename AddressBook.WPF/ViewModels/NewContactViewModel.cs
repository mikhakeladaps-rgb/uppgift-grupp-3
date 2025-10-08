using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace AddressBook.WPF.ViewModels;

public partial class NewContactViewModel : ObservableObject
{
    public event Action? RequestClose;

    #region Observable properties
    [ObservableProperty] private Contact newContact = new Contact();
    #endregion

    #region Properties
    public bool WasSaved { get; private set; }
    #endregion

    #region Constructor
    public NewContactViewModel()
    {

    }
    #endregion

    #region Relay commands
    [RelayCommand]
    public void Save()
    {
        if (string.IsNullOrWhiteSpace(NewContact.Name) ||
        string.IsNullOrWhiteSpace(NewContact.Street) ||
        string.IsNullOrWhiteSpace(NewContact.PostalCode) ||
        string.IsNullOrWhiteSpace(NewContact.City) ||
        string.IsNullOrWhiteSpace(NewContact.PhoneNumber) ||
        string.IsNullOrWhiteSpace(NewContact.Email))
        {
            MessageBox.Show("Alla fält måste fyllas i innan du sparar.", "Fel", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        // Stäng fönstret
        WasSaved = true;
        if (RequestClose != null)
        {
            RequestClose?.Invoke();
        }
    }

    [RelayCommand]
    public void Cancel()
    {
        // Stäng fönstret
        WasSaved = false;
        if (RequestClose != null)
        {
            RequestClose?.Invoke();
        }
    }
    #endregion
}
