using Assignment.Shared.Interfaces;
using Assignment.Shared.Models;
using Assignment.Shared.Respository;
using Assignment.WpfApp.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.WpfApp.ViewModels;

public partial class ContactAddViewModel(IServiceProvider serviceProvider, IContactService contactService) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IContactService _contactService = contactService;

    //instantiate: holds the new contact
    [ObservableProperty]
    private IContactModel _newContact = new ContactModel();


    //method: add the contact to the list through contactService
    [RelayCommand]
    public void AddContact()
    {
        if(!string.IsNullOrWhiteSpace(NewContact.FirstName))
        {
            bool result = _contactService.AddNewContact(NewContact);
            if (result)
            {
                NewContact = new ContactModel();
                NavigateToList();
            }
        }
    }


    //method: navigation back to listView
    [RelayCommand]
    private void NavigateToList()
    {
        MainViewModel mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
    }

}
