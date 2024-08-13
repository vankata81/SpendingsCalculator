using Microsoft.AspNetCore.Mvc;
using SpendCalculator.Models;
using System.Diagnostics;

namespace SpendCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SpendCalculatorDbContext _context;

        public HomeController(ILogger<HomeController> logger, SpendCalculatorDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddExpense(int? id)
        {
            if (id != null)
            {
                var expenseInDb = _context.Expenses.FirstOrDefault(x => x.Id == id);
                return View(expenseInDb);
            }
            return View();
        }
        public IActionResult AddExpenseForm(Expense model)
        {
            if (model.Id == 0)
            {
                _context.Expenses.Add(model);

            }
            else
            {
                _context.Expenses.Update(model);
            }
            _context.SaveChanges();
            return RedirectToAction("AllExpense");
        }

        public IActionResult AllExpense()
        {
            var allExpenses = _context.Expenses.ToList();

            var totalExpenses = allExpenses.Sum(x=>x.Number);
            ViewBag.Expenses = totalExpenses;
            return View(allExpenses);
        }
        public IActionResult DeleteExpense(int id)
        {
            var expenseInDb = _context.Expenses.FirstOrDefault(x => x.Id == id);
            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges();
            return RedirectToAction("AllExpense");
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
