using Dapper;
using dotnet.Data;
using dotnet.Interface;
using dotnet.Models;

namespace dotnet.Repository
{
    public class PersonQueryRepository : PersonQuery<Person>
    {
        private readonly DapperContext context;
        public PersonQueryRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Person>> FindAll()
        {
            using var connection = context.CreateConnection();
            var findings = await connection.QueryAsync<Person>("SELECT * FROM person");
            return findings.ToList();
        }

        public async Task<Person> FindById(int id)
        {
            using var connection = context.CreateConnection();
            var findings = await connection.QueryAsync<Person>("SELECT * FROM person WHERE id = @id", new { id });
            return findings.FirstOrDefault();
        }
    }
}
