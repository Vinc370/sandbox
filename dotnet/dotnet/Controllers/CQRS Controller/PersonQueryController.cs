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

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<Person> index = await query.FindAllNoPage();
            return Ok(index);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> IndexAPI(int id)
        {
            IEnumerable<Person> index = await query.FindAll(id);
            return Ok(index);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ViewAPI(int id)
        {
            Person index = await query.FindById(id);
            return Ok(index);
        }

        [HttpGet("{search}/{page}")]
        public async Task<IActionResult> SearchAPI(String search, int page)
        {
            IEnumerable<Person> index = await query.Search(search, page);
            return Ok(index);
        }

        [HttpGet("{asc}/{page}")]
        public async Task<IActionResult> Sort(bool asc, int page)
        {
            IEnumerable<Person> index = await query.SortByAge(asc, page);
            return Ok(index);
        }

        [HttpGet("{asc}/{page}")]
        public async Task<IActionResult> SortName(bool asc, int page)
        {
            IEnumerable<Person> index = await query.SortByName(asc, page);
            return Ok(index);
        }
    }
}
