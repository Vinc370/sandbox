using dotnet.Interface;
using dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonInterface personInterface;

        public PersonController(PersonInterface personInterface)
        {
            this.personInterface = personInterface;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Person> person = await personInterface.GetAll();
            return View(person);
        }
    }
}
