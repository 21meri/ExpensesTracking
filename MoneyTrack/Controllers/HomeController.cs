using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MoneyTrack.Models;

namespace MoneyTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExpensesDB _context;

        public HomeController(ILogger<HomeController> logger, ExpensesDB context)
            
        {
            _logger = logger;
            _context= context;
        }

        public IActionResult Index()
        {
            return View();
        }
  
        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();

            var totalExpenses = allExpenses.Sum(x => x.Value);

            ViewBag.Expenses = totalExpenses;
          
            return View(allExpenses);
        }
        public IActionResult Creatediffexp(int? id)
        {
            if(id != null)
            {
                var expensesInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
                return View(expensesInDb);
            }

            return View();
        }

        public IActionResult Deletediffexp(int id)
        {
            var expensesInDb=_context.Expenses.SingleOrDefault(expense => expense.Id == id);
            _context.Expenses.Remove(expensesInDb);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }

        public IActionResult CreatediffexpForm(Expense model)
        {
            if(model.Id==0)
            {
                _context.Expenses.Add(model);
            }
            else
            {
                _context.Expenses.Update(model);
            }

                _context.SaveChanges();

            return RedirectToAction("Expenses");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
