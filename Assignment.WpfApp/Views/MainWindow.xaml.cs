using Assignment.WpfApp.ViewModels;
using System.Windows;

namespace Assignment.WpfApp;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}