using Basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index1()
        {
            string message=$"hello World. {DateTime.Now.ToString()}";
            return View("Index1",message);
        }

        public ViewResult Index2()
        {
            var names = new String[]{
                "alperen",
                "mustafa",
                "mehmnet"
            };
            return View(names);

        }

        public IActionResult Index3()
        {
            var list= new List<Employee>()
            {
                new Employee(){Id=1, FirstName="Alperen", LastName="Güneş", Age=24},
                new Employee(){Id=2, FirstName="Mustafa", LastName="Güneş", Age=53},
                new Employee(){Id=2, FirstName="Mehmmet", LastName="Güneş", Age=85}
            };
            return View("Index3",list);
        }

    }
}