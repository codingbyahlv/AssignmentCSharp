using System.Diagnostics;
using Assignment.Shared.Interfaces;

namespace Assignment.Shared.Services;

public class FileService(string filePath) : IFileService
{
    //method: save the list in a file
    public bool SaveContactListToFile(string content)
    {
        try
        {
            using StreamWriter sw = new(filePath);
            sw.WriteLine(content);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }


    //method: get the list from a file
    public string GetContactListFromFile()
    {
        try
        {
            if (File.Exists(filePath))
            {
                using StreamReader sr = new(filePath);
                return sr.ReadToEnd();
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;

    }
}
