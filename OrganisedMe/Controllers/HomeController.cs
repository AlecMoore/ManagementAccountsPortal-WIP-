using Microsoft.AspNetCore.Mvc;
using OrganisedMe.Models;
using OrganisedMe.StoredProcedures;
using System.Diagnostics;

namespace OrganisedMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            List<MA> ma = GetMA();
            return View(ma);
        }

        public IActionResult Budget()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTransaction(Transaction transaction)
        {
            bool result = StoredProcedures.StoredProcedures.AddTransaction(transaction);


            return Redirect("/Home/Budget");
        }

        [HttpPost]
        public ActionResult RemoveTransaction(int Id)
        {
            bool result = StoredProcedures.StoredProcedures.DeleteTransaction(Id);


            return Redirect("/Home/Budget");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<MA> GetMA()
        {
            List<MA> result = new List<MA>();
            List<Transaction> transactions = StoredProcedures.StoredProcedures.GetTransactions();

            foreach (Transaction transaction in transactions)
            {
                DateTime tEndDate = new DateTime(transaction.Date.Year, transaction.Date.Month, DateTime.DaysInMonth(transaction.Date.Year, transaction.Date.Month));

                int i = result.FindIndex(item => item.CostCode == transaction.CostCode);
                if (i >= 0)
                {
                    int j = result[i].Details.FindIndex(item => item.Date == tEndDate);
                    if (j >= 0)
                    {
                        result[i].Details[j].Amount += transaction.Amount;
                    } else
                    {
                        MADetails details = new MADetails(transaction.Amount, tEndDate, (decimal)0.0);
                        result[i].Details.Add(details);
                    }
                } else
                {
                    MA mA = new MA(transaction.CostCode, transaction.Account, transaction.Type);
                    MADetails details = new MADetails(transaction.Amount, tEndDate, (decimal)0.0);
                    mA.Details.Add(details);
                    result.Add(mA);
                }
                
            }

            return (List<MA>)result.GroupBy(g => g.CostCode);

        }
    }
}