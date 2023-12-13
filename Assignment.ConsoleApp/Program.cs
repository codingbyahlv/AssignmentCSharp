using Assignment.ConsoleApp.Services;
using Assignment.Shared.Respository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


IHost builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<ContactRepository>();
    services.AddSingleton<MenuService>();
    services.AddSingleton<ContactMenuService>();

}).Build();

builder.Start();
Console.Clear();

MenuService mainMenuService = builder.Services.GetRequiredService<MenuService>();
mainMenuService.ShowMainMenu();

