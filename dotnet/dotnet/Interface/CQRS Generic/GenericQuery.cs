using Microsoft.AspNetCore.Mvc;

namespace dotnet.Interface
{
    public interface GenericQuery<T>
    {
        Task<IEnumerable<T>> FindAll(int page);
        Task<IEnumerable<T>> FindAllNoPage();
        Task<T> FindById(int id);
    }
}
