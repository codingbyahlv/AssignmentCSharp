namespace Assignment.ConsoleApp.Services;

public class MenuService(ContactMenuService contactMenuService) 
{
    private readonly ContactMenuService _contactMenuService = contactMenuService;

    //method: the main menu of the program - DONE!
    public void ShowMainMenu()
    {
        bool isMenu = true;

        do
        {
            Console.Clear();
            Console.WriteLine("\n************** MENY **************");
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine();
            Console.WriteLine($"{"[1]",-5}Dina kontakter");
            Console.WriteLine($"{"[2]",-5}Lägg till ny kontakt");
            Console.WriteLine($"{"[3]",-5}Avsluta");

            Console.Write("\nDitt menyval: ");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    _contactMenuService.ShowAllContacts();
                    break;
                case "2":
                    _contactMenuService.AddNewContact();
                    break;
                case "3":
                    ExitProgram();
                    break;
                default:
                    ShowErrorMessage("sifforna 1-3");
                    break;
            }

            Console.ReadKey();

        } while (isMenu);
    }

    //method: exit the program - DONE!
    private void ExitProgram()
    {
        Console.Clear();
        Console.WriteLine("Är du säker på att du vill avsluta programmet? (J/N) ");
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.J:
                Environment.Exit(0);
                break;
            case ConsoleKey.N:
                Console.Clear();
                ShowMainMenu();
                break;
            default:
                ShowErrorMessage("J eller N");
                break;
        }
    }

    //method: print a return message - DONE!
    public void ReturnToMainMenu()
    {
        Console.WriteLine("\nTryck ENTER för att återgå till huvudmenyn...");
    }

    //method: print a wrong choice message - DONE!
    public void ShowErrorMessage(string message)
    {
        Console.WriteLine($"\nEndast {message} är giltiga val");
        ReturnToMainMenu();
    }
}
