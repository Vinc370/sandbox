using dotnet.Interface;
using dotnet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [Route("api/database")]
    [ApiController]
    public class DatabaseControllerDapper : Controller
    {
        private readonly DapperInterface databaseInterface;

        public DatabaseControllerDapper(DapperInterface databaseInterface)
        {
            this.databaseInterface = databaseInterface;
        }

        [HttpGet]
        public async Task<IActionResult> IndexDapper()
        {
            IEnumerable<Database> indexD = await databaseInterface.GetAll();
            return View(indexD);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> View(int id)
        {
            Database viewD = await databaseInterface.GetById(id);
            return View(viewD);
        }
    }
}
