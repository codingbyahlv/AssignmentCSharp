namespace Assignment.Shared.Interfaces
{
    internal interface IFileService
    {
        string GetContactListFromFile();
        bool SaveContactListToFile(string content);
    }
}