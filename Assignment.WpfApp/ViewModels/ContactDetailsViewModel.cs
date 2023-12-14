using Assignment.Shared.Interfaces;
using Assignment.WpfApp.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.WpfApp.ViewModels;

public partial class ContactDetailsViewModel(IServiceProvider serviceProvider, IContactService contactService) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IContactService _contactService = contactService;
    private IContactModel _contact = null!;


    // prop: holds the current contact information
    public IContactModel Contact
    {
        get { return _contact; }
        set
        {
            if (_contact != value)
            {
                _contact = value;
            }
        }
    }


    //method: navigation back to listView
    [RelayCommand]
    public void NavigateToList()
    {
        MainViewModel mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
    }


    //method: navigate to updateView and "pass" the contact
    [RelayCommand]
    public void NavigateToUpdate(IContactModel contact)
    {
        MainViewModel mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        ContactUpdateViewModel contactUpdateViewModel = _serviceProvider.GetRequiredService<ContactUpdateViewModel>();
        contactUpdateViewModel.Contact = contact;
        mainViewModel.CurrentViewModel = contactUpdateViewModel;
    }


    //method: delete contact from list through contactService
    [RelayCommand]
    public void DeleteContact()
    {
        bool result = _contactService.DeleteContact(Contact.Id);
        if (result)
        {
            NavigateToList();
        }
    }
}
