namespace dotnet.Interface
{
    public interface PersonQuery<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> FindById(int id);
    }
}
