namespace Assignment.ConsoleApp.Interfaces;

public interface IMenuService
{
    /// <summary>
    ///     Shows the main menu
    /// </summary>
    void ShowMainMenu();

    /// <summary>
    ///     Shows a return to main menu line
    /// </summary>
    void ReturnToMainMenu();

    /// <summary>
    ///     Shows an error message
    /// </summary>
    /// <param name="message">The message to be displayed</param>
    void ShowErrorMessage(string message);
}
