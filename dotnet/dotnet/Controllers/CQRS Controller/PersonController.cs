using ClosedXML.Excel;
using dotnet.Interface;
using dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace dotnet.Controllers
{
    public class PersonController : Controller
    {
        private readonly GenericQuery<Person> query;

        public PersonController(GenericQuery<Person> query)
        {
            this.query = query;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult create()
        {
            return View();
        }

        public IActionResult View(int id)
        {
            return View();
        }

        public IActionResult update(int id)
        {
            return View();
        }

        public async Task<FileResult> Download()
        {
            IEnumerable<Person> index = await query.FindAllNoPage();
            return Export(index);
        }

        private FileResult Export(IEnumerable<Person> data)
        {
            DataTable table = new DataTable("Personal Data");

            table.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID"),
                new DataColumn("Fullname"),
                new DataColumn("Date of birth")
            });

            foreach (Person person in data)
            {
                table.Rows.Add(person.Id, person.name, person.dob);
            }

            using XLWorkbook excel = new XLWorkbook();
            excel.Worksheets.Add(table);

            using MemoryStream stream = new MemoryStream();
            excel.SaveAs(stream);

            return File(stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "export.xlsx");
        }
    }
}
