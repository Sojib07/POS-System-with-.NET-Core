using Microsoft.AspNetCore.Mvc.Rendering;

namespace POS.Services
{
    public interface IDataUtility
    {
        Task ExecuteCommandAsync(string command, Dictionary<string, object> parameters);
        Task<IList<SelectListItem>> GetItemsAsync(string command,
            Dictionary<string, object> parameters);
    }
}