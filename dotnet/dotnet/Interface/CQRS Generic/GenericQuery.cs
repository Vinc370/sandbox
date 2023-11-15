namespace dotnet.Interface
{
    public interface GenericQuery<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> FindById(int id);
    }
}
