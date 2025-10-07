using CommunityToolkit.Mvvm.ComponentModel;

public partial class ContactViewModel : ObservableObject
{
    #region Fields
    private bool _isInitializing;       // för att undvika onPropertyChanged under initiering
    private readonly Contact _contact;  // originaldata
    #endregion

    #region Observable properties
    [ObservableProperty] private string? name;
    [ObservableProperty] private string? streetName;
    [ObservableProperty] private string? zipCode;
    [ObservableProperty] private string? city;
    [ObservableProperty] private string? phone;
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

        // TODO: uppdatera med rätt namn på Contact-egenskaper
        // Initiera ViewModel-egenskaper från modellen
        //Name = contact.Name;
        //StreetName = contact.StreetName;
        //ZipCode = contact.ZipCode;
        //City = contact.City;
        //Phone = contact.Phone;
        //Email = contact.Email;

        _isInitializing = false;
    }
    #endregion

    #region Partial-metoder som triggar IsChanged
    partial void OnNameChanged(string? value)
    {
        if (!_isInitializing) IsChanged = true;
    }
    partial void OnStreetNameChanged(string? value)
    {
        if (!_isInitializing) IsChanged = true;
    }
    partial void OnZipCodeChanged(string? value)
    {
        if (!_isInitializing) IsChanged = true;
    }
    partial void OnCityChanged(string? value)
    {
        if (!_isInitializing) IsChanged = true;
    }
    partial void OnPhoneChanged(string? value)
    {
        if (!_isInitializing) IsChanged = true;
    }
    partial void OnEmailChanged(string? value)
    {
        if (!_isInitializing) IsChanged = true;
    }
    #endregion

    // Uppdatera den ursprungliga Contact-modellen
    public Contact ToModel()
    {
        // TODO: uppdatera med rätt namn på Contact-egenskaper
        //_contact.Name = Name;
        //_contact.StreetName = StreetName;
        //_contact.ZipCode = ZipCode;
        //_contact.City = City;
        //_contact.Phone = Phone;
        //_contact.Email = Email;
        return _contact;
    }
}