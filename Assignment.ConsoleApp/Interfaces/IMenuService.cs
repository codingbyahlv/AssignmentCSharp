namespace Assignment.ConsoleApp.Interfaces;

public interface IMenuService
{
    void ShowMainMenu();
    void ReturnToMainMenu();
    void ShowErrorMessage(string message);
}
