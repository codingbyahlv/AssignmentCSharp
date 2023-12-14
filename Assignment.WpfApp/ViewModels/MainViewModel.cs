using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.WpfApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject? _currentViewModel;
    private readonly IServiceProvider _serviceProvider;

    //constructor
    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
    }
}
