using Assignment.Shared.Interfaces;
using Assignment.Shared.Services;

namespace Assignment.Tests;

public class FileService_Tests
{
    /// <summary>
    ///     test to see if content are saved to file
    /// </summary>
    [Fact]
    public void SaveToFile_ShouldSaveContentToFile_ThenReturnTrue()
    {
        //arrange
        string filepath = @"c:\Work\EC\3-c-sharp\Testfolder\adressBook.txt";
        string content = "Test content";

        IFileService fileservice = new FileService(filepath);

        //act
        bool result = fileservice.SaveContactListToFile(content);

        //assert
        Assert.True(result);
    }


    /// <summary>
    ///     test to see if it's possible to get content from file
    /// </summary>
    [Fact]
    public void GetFromFile_ShouldGetContentFromFile_ThenReturnContent()
    {
        //arrange
        string filepath = @"c:\Work\EC\3-c-sharp\Testfolder\adressBook.txt";
        IFileService fileservice = new FileService(filepath);

        //act
        string result = fileservice.GetContactListFromFile();

        //assert
        Assert.NotNull(result);
    }
}
