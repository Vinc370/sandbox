using dotnet.Data;
using dotnet.Interface;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Repository
{
    public class PersonRepository : PersonInterface
    {
        private readonly ApplicationContext context;

        public PersonRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public bool Create(Person model)
        {
            context.Add(model);
            return Save();
        }

        public bool Delete(Person model)
        {
            context.Remove(model);
            return Save();
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await context.person.ToListAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await context.person.FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<IEnumerable<Person>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            context.SaveChanges();
            return true;
        }

        public bool Update(Person model)
        {
            throw new NotImplementedException();
        }
    }
}
