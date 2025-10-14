using AddressBook.Core.Services;
using AddressBook.WPF.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace AddressBook.WPF.ViewModels;

public partial class MainViewModel : ObservableObject
{
    #region Observable properties
    [ObservableProperty] public string titel;
    [ObservableProperty] private ICollectionView contactsView;
    [ObservableProperty] private ContactViewModel? selectedContact;
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
            ContactsView.Refresh();
        }
    }
    #endregion

    private readonly ContactManager contactManager = new ContactManager();
    public ObservableCollection<ContactViewModel> Contacts { get; } = new();

    #region Constructor
    public MainViewModel()
    {
        Titel = "AdressBok";

        contactManager.LoadContacts();

        foreach (var contact in contactManager.Contacts)
        {
            Contacts.Add(new ContactViewModel(contact));
        }

        ContactsView = CollectionViewSource.GetDefaultView(Contacts);
        ContactsView.Filter = FilterContacts; ;
    }
    #endregion

    private bool FilterContacts(object obj)
    {
        if (obj is not ContactViewModel vm) return false;
        if (string.IsNullOrWhiteSpace(SearchText)) return true;

        var text = SearchText.ToLower();
        return (vm.Name?.ToLower().Contains(text) == true)
            || (vm.City?.ToLower().Contains(text) == true);
    }

    // Spara automatiskt när användaren byter kontakt om något ändrats
    partial void OnSelectedContactChanged(ContactViewModel? oldValue, ContactViewModel? newValue)
    {
        if (oldValue != null && oldValue.IsChanged)
        {
            SaveContact(oldValue);
        }
    }

    private void SaveContact(ContactViewModel contact)
    {
        if (contact is null) return;
        if (!contact.IsChanged) return;

        contact.IsChanged = false;
        contact.ToModel();
        contactManager.SaveContacts();
    }

    #region RelayCommands
    [RelayCommand]
    public void NewContact()
    {
        //var wnd = new NewContactWnd();
        //var vm = (NewContactViewModel)wnd.DataContext;

        var vm = new NewContactViewModel();
        var wnd = new NewContactWnd { DataContext = vm };

        bool? result = wnd.ShowDialog();

        if (result == true)
        {
            // Användaren klickade på Spara
            int nextId = Enumerable.Range(1, int.MaxValue)
            .Except(contactManager.Contacts.Select(c => c.Id))
            .First();
            vm.NewContact.Id = nextId;

            contactManager.Contacts.Add(vm.NewContact);
            contactManager.SaveContacts();
            var newVm = new ContactViewModel(vm.NewContact);
            Contacts.Add(newVm);
            ContactsView.Refresh();
            SelectedContact = newVm;
        }
    }

    [RelayCommand]
    private void DeleteContact()
    {
        if (SelectedContact != null)
        {
            if (MessageBox.Show($"Vill du verkligen radera {SelectedContact.Name}?",
                                "Bekräfta", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Ta bort från contactManager
                contactManager.Contacts.Remove(SelectedContact.ToModel()); // om SelectedContact är ViewModel med Model-property
                contactManager.SaveContacts(); // eller motsvarande metod för att spara

                // Uppdatera ObservableCollection i VM
                Contacts.Remove(SelectedContact);

                SelectedContact = null;
            }
        }
    }

    [RelayCommand]
    public void Quit()
    {
        Application.Current.Shutdown();
    }
    #endregion
}