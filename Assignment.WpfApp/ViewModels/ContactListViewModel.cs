using Assignment.Shared.Interfaces;
using Assignment.WpfApp.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.WpfApp.ViewModels;

public partial class ContactListViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;

    //constructor
    public ContactListViewModel(IServiceProvider servideProvider, IContactService contactService)
    {
        _serviceProvider = servideProvider;
        _contactService = contactService;
        LoadContacts();
    }


    //prop: holds the list
    public IEnumerable<IContactModel> Contacts { get; private set; } = [];


    //method: get the list from the contactService
    private void LoadContacts()
    {
        Contacts = _contactService.ShowAllContacts();
    }


    //method: navigation to add new contactView
    [RelayCommand]
    public void NavigateToAdd()
    {
        MainViewModel mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactAddViewModel>();
    }


    //method: navigation to contact detailsView and "pass" the contact
    [RelayCommand]
    public void NavigateToContactDetails(IContactModel contact)
    {
        MainViewModel mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        ContactDetailsViewModel contactDetailsViewModel = _serviceProvider.GetRequiredService<ContactDetailsViewModel>();
        contactDetailsViewModel.Contact = contact;
        mainViewModel.CurrentViewModel = contactDetailsViewModel;
    }
}
