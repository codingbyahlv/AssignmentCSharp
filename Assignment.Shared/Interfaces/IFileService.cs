namespace Assignment.Shared.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        ///     Get the contactlist from a json file
        /// </summary>
        /// <returns>The content (contactlist) as a string</returns>
        string GetContactListFromFile();

        /// <summary>
        ///     Save the contactlist to a json file
        /// </summary>
        /// <param name="content">The content as a string</param>
        /// <returns>True if correctly saved, false when there is any problem with the saving</returns>
        bool SaveContactListToFile(string content);
    }
}