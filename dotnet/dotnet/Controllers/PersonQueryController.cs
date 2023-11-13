using dotnet.Interface;
using dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class PersonQueryController : Controller
    {
        private readonly PersonQuery<Person> query;

        public PersonQueryController (PersonQuery<Person> query)
        {
            this.query = query;
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> update(int id)
        {
            Person model = await query.FindById(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Person> index = await query.FindAll();
            return View(index);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            Person index = await query.FindById(id);
            return Ok(index);
        }
    }
}
