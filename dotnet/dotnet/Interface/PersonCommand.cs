namespace dotnet.Interface
{
    public interface PersonCommand<T>
    {
        Task Create(T model);
        Task Update(T model);
        Task Delete(int id);
    }
}
