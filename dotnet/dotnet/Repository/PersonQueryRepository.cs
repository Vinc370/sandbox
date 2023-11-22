﻿using Dapper;
using dotnet.Data;
using dotnet.Interface;
using dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Repository
{
    public class PersonQueryRepository : GenericQuery<Person>
    {
        private readonly DapperContext context;
        public PersonQueryRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Person>> FindAll(int page)
        {
            using var connection = context.CreateConnection();
            var findings = await connection.QueryAsync<Person>("SELECT * FROM person LIMIT 10 OFFSET @page", new { page });
            return findings.ToList();
        }

        public async Task<IEnumerable<Person>> FindAllNoPage()
        {
            using var connection = context.CreateConnection();
            var findings = await connection.QueryAsync<Person>("SELECT * FROM person");
            return findings.ToList();
        }

        public async Task<IEnumerable<Person>> Search(string search)
        {
            using var connection = context.CreateConnection();
            var searchData = await connection.QueryAsync<Person>("SELECT * FROM person WHERE name LIKE '%" + search + "%'");
            return searchData.ToList();
        }

        public async Task<Person> FindById(int id)
        {
            using var connection = context.CreateConnection();
            var findings = await connection.QueryAsync<Person>("SELECT * FROM person WHERE id = @id", new { id });
            return findings.FirstOrDefault();
        }
    }
}
