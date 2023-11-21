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
    }
}
