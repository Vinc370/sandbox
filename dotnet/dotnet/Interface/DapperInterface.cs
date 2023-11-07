﻿using dotnet.Models;

namespace dotnet.Interface
{
    public interface DapperInterface : GenericInterface<Database>
    {
        Task Create(Database model);
        Task Update(Database model);
        Task Delete(Database model);
    }
}
