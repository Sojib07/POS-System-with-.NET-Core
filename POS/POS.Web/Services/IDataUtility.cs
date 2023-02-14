using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Services
{
    public interface IDataUtility
    {
        Task ExecuteCommandAsync(string command, Dictionary<string, object> parameters);
        Task<IList<SelectListItem>> GetItemsAsync(string command,
            Dictionary<string, object> parameters);
    }
}