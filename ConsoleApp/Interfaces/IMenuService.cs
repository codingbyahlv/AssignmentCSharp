

namespace ConsoleApp.Interfaces;

public interface IMenuService
{
    void ShowMainMenu();
    void ExitProgram();
    void ReturnToMainMenu();
    void ShowErrorMessage(string message);
}
