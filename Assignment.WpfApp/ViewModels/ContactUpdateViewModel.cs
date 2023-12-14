using Assignment.Shared.Interfaces;
using Assignment.WpfApp.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.WpfApp.ViewModels;

public partial class ContactUpdateViewModel(IServiceProvider serviceProvider, IContactService contactService) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IContactService _contactService = contactService;
    private IContactModel _contact = null!;


    // prop: hold the current contact information
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


    //method: update contact through contact service
    [RelayCommand]
    public void UpdateContact()
    {
        if (!string.IsNullOrWhiteSpace(Contact.FirstName))
        {
            bool result = _contactService.UpdateContact(Contact);
            if (result)
            {
                NavigateToList();
            }
        }
    }


    //methods: navigation back to listView
    [RelayCommand]
    public void NavigateToList()
    {
        MainViewModel mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
    }

}
