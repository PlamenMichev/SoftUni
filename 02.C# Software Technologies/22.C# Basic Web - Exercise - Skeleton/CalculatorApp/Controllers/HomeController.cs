using CalculatorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CalculatorApp.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index(Calculator calculator)
        {
            return View(calculator);
        }

        [HttpPost]
        public IActionResult Calculate(Calculator calculator)
        {
            calculator.calculate(calculator.Operator);
            if (calculator.RightOperand == 0 && calculator.Operator == "/")
            {
                TempData["Error"] = "Cannot Divide by Zero!";
            }
            else
            {
                Data.calculatorHistory.Add(calculator);
            }
            return RedirectToAction("Index", calculator);
        }

        [HttpGet]
        public IActionResult History()
        {
            var model = Data.calculatorHistory;
            return View(model);
        }

    }
}
