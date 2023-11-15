using dotnet.Interface;
using dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class PersonQueryController : Controller
    {
        private readonly GenericQuery<Person> query;

        public PersonQueryController (GenericQuery<Person> query)
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
        public async Task<IActionResult> ViewAPI(int id)
        {
            Person index = await query.FindById(id);
            return Ok(index);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> View(int id)
        {
            Person index = await query.FindById(id);
            return View(index);
        }
    }
}
