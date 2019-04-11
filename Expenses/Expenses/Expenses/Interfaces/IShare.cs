using System.Threading.Tasks;

namespace Expenses.Interfaces
{
    /// <summary>
    /// Definiton for implementation into the different Platforms
    /// Extracts the money values to each platform
    /// </summary>
    public interface IShare
    {
        Task Show(string theTitle, string theMessage, string theFilePath);
    }
}
