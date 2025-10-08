using AddressBook.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class ContactViewModel : ObservableObject
{
    #region Fields
    private bool _isInitializing;       // för att undvika onPropertyChanged under initiering
    private readonly Contact _contact;  // originaldata
    #endregion

    #region Observable properties
    [ObservableProperty] private string? name;
    [ObservableProperty] private string? street;
    [ObservableProperty] private string? postalCode;
    [ObservableProperty] private string? city;
    [ObservableProperty] private string? phoneNumber;
    [ObservableProperty] private string? email;

    [ObservableProperty] private bool isChanged;  // Changed flagga - något är ändrat i en kontakt
    #endregion

    #region Constructor
    // Konstruktor som tar en Contact som parameter och initierar ViewModel-egenskaper från modellen.
    // Används när en befintlig kontakt ska redigeras.
    // Då Contact-klassen inte implementerar INotifyPropertyChanged så är detta en workaround
    // för att kunna upptäcka ändringar i ViewModel och sätta IsChanged flaggan.
    public ContactViewModel(Contact contact)
    {
        _contact = contact;
        _isInitializing = true;

        // Initiera ViewModel-egenskaper från modellen
        Name = contact.Name;
        Street = contact.Street;
        PostalCode = contact.PostalCode;
        City = contact.City;
        PhoneNumber = contact.PhoneNumber;
        Email = contact.Email;

        _isInitializing = false;
    }
    #endregion

    private void MarkChanged()
    {
        if (!_isInitializing) IsChanged = true;
    }

    #region Partial-metoder som triggar IsChanged
    partial void OnNameChanged(string? value) => MarkChanged();
    partial void OnStreetChanged(string? value) => MarkChanged();
    partial void OnPostalCodeChanged(string? value) => MarkChanged();
    partial void OnCityChanged(string? value) => MarkChanged();
    partial void OnPhoneNumberChanged(string? value) => MarkChanged();
    partial void OnEmailChanged(string? value) => MarkChanged();
    #endregion

    // Uppdatera den ursprungliga Contact-modellen
    public Contact ToModel()
    {
        _contact.Name = Name;
        _contact.Street = Street;
        _contact.PostalCode = PostalCode;
        _contact.City = City;
        _contact.PhoneNumber = PhoneNumber;
        _contact.Email = Email;
        return _contact;
    }
}