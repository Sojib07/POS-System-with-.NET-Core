using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Services;
using POS.Web.Models;
using System.Diagnostics;

namespace POS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataUtility _dataUtility;

        public HomeController(ILogger<HomeController> logger, IDataUtility dataUtility)
        {
            _logger = logger;
            _dataUtility = dataUtility;
        }

        public async Task<IActionResult> Index()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            string query = "SELECT ItemName, UnitPrice FROM Items ORDER BY ItemName DESC";

            items = await _dataUtility.GetItemsAsync(query,null);
            ViewBag.Items = items;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertBillData(string dateTime, string subTotal, string discount, string grandTotal)
        {
            var Id= Guid.NewGuid(); ;
            var timeDate= DateTime.Parse(dateTime);
            var subTot=double.Parse(subTotal);
            var discnt = double.Parse(discount);
            var grandTtl=double.Parse(grandTotal);

            string sqlQuery = "INSERT INTO Bills (Id, DateTime, SubTotal, Discount, GrandTotal) VALUES (@xId, @xDateTime, @xSubTotal, @xDiscount, @xGrandTotal)";
            Dictionary<string,object> parameters = new Dictionary<string,object>();
            parameters.Add("xId", Id);
            parameters.Add("xDateTime", timeDate);
            parameters.Add("xSubTotal", subTot);
            parameters.Add("xDiscount", discnt);
            parameters.Add("xGrandTotal", grandTtl);

            await _dataUtility.ExecuteCommandAsync(sqlQuery,parameters);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}