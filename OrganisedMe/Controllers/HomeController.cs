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
            return View();
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
            List<DateTime> dates = new List<DateTime>();
            //var matches = transactions.Where(t => t.Date == nameToExtract);
            foreach (Transaction transaction in transactions)
            {
                if (result.Count <1)
                {
                    MA mA = new MA(transaction.CostCode, transaction.Account, transaction.Type, transaction.Amount, new DateTime(transaction.Date.Year, transaction.Date.Month, DateTime.DaysInMonth(transaction.Date.Year, transaction.Date.Month)), (decimal)0.0);
                    result.Add(mA);
                }
                else
                {
                    MA mA = new MA(transaction.CostCode, transaction.Account, transaction.Type, transaction.Amount, new DateTime(transaction.Date.Year, transaction.Date.Month, DateTime.DaysInMonth(transaction.Date.Year, transaction.Date.Month)), (decimal)0.0);

                    var temp = result.Where(ma => ma.Date == mA.Date);
                    if (temp != null){

                        result.Where(ma => ma.Date == mA.Date).Amount
                    }
                }
            }

            return result;

        }
    }
}