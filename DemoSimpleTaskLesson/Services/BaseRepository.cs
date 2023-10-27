using System.Data.SqlClient;

namespace DemoSimpleTaskLesson.Services;

public class BaseRepository
{
    protected readonly SqlConnection _connection;

    public BaseRepository()
    {
        this._connection = new SqlConnection("Server=LAPTOP-UVN5MKL6\\SQLEXPRESS;Database=DemoSimpleTaskLesson;Trusted_Connection=True;");
    }
}
