namespace DemoSimpleTaskLesson.Interfaces.Employees;

public interface IEmployees<T>
{
    public Task<bool> CreateAsync(T obj);

    public Task<bool> UpdateAsync(int id, T obj);

    public Task<bool> DeleteAsync(int id);

    public Task<bool> DeepDeleteAsync(int id);

    public Task<IList<T>> GetAllAsync();

    public Task<T> GetByIdAsync(int id);

}
