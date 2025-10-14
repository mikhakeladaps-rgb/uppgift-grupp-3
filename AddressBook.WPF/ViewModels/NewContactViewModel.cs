using AddressBook.Core.Models;
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
    public void SaveNewContact()
    {
        // Enkel validering
        if (string.IsNullOrWhiteSpace(NewContact.Name) ||
        string.IsNullOrWhiteSpace(NewContact.Street) ||
        string.IsNullOrWhiteSpace(NewContact.PostalCode) ||
        string.IsNullOrWhiteSpace(NewContact.City) ||
        string.IsNullOrWhiteSpace(NewContact.PhoneNumber) ||
        string.IsNullOrWhiteSpace(NewContact.Email))
        {
            System.Windows.MessageBox.Show("Fyll i alla obligatoriska fält.");
            return;
        }

        WasSaved = true;
        RequestClose?.Invoke();
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
