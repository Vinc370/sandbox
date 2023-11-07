using Dapper;
using dotnet.Data;
using dotnet.Interface;
using dotnet.Models;
using Microsoft.Data.SqlClient;

namespace dotnet.Repository
{
    public class DatabaseRepositoryDapper : DapperInterface
    {
        private readonly DapperContext context;

        public DatabaseRepositoryDapper(DapperContext context)
        {
            this.context = context;
        }

        public async Task Create(Database model)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Id", model.Id);
            parameter.Add("Email", model.Email);
            parameter.Add("Password", model.Password);
            parameter.Add("DataID", model.DataID);

            using var connection = context.CreateConnection();
            var user = await connection.ExecuteAsync(
                "INSERT INTO" +
                    "users(`Id`, `Email`, `Password`, `DataID`)" +
                    "VALUES('@Id', '@Email', '@Password', '@DataId');",
                parameter);
        }

        public async Task Delete(Database model)
        {
            using var connection = context.CreateConnection();
            await connection.ExecuteAsync(
                "DELETE FROM" +
                    "users WHERE(`Id` = '@Id');",
                new { model.Id });
        }

        public async Task<IEnumerable<Database>> GetAll()
        {
            using var connection = context.CreateConnection();
            var indexD = await connection.QueryAsync<Database>("SELECT * FROM users");
            return indexD.ToList();
        }

        public async Task<Database> GetById(int id)
        {
            using var connection = context.CreateConnection();
            var indexD = await connection.QuerySingleOrDefaultAsync<Database>("SELECT users.Id, users.Email, users.Password, datas.Name  FROM users INNER JOIN datas ON users.DataID = datas.Id WHERE users.Id = @Id", new { id });
            return indexD;
        }

        public async Task<IEnumerable<Database>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Database model)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Id", model.Id);
            parameter.Add("Email", model.Email);
            parameter.Add("Password", model.Password);
            parameter.Add("DataID", model.DataID);

            using var connection = context.CreateConnection();
            await connection.ExecuteAsync(
                "INSERT INTO" +
                    "users(`Id`, `Email`, `Password`, `DataID`)" +
                    "VALUES('@Id', '@Email', '@Password', '@DataId')" +
                "WHERE Id = @Id;",
                parameter);
        }

        bool GenericInterface<Database>.Create(Database model)
        {
            throw new NotImplementedException();
        }

        bool GenericInterface<Database>.Delete(Database model)
        {
            throw new NotImplementedException();
        }

        bool GenericInterface<Database>.Update(Database model)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
