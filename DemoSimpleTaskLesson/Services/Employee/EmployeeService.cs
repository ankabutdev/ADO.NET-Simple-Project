using DemoSimpleTaskLesson.Enums;
using DemoSimpleTaskLesson.Interfaces.Employees;
using DemoSimpleTaskLesson.Models;
using System.Data.SqlClient;

namespace DemoSimpleTaskLesson.Services.Employee;

public class EmployeeService : BaseRepository, IEmployees<Employees>
{
    public async Task<bool> CreateAsync(Employees obj)
    {
        if (obj == null)
            return false;

        try
        {
            await _connection.OpenAsync();

            string query = $"INSERT INTO Employees (Name, " +
                $"Surname, Email, [Login], [Password], " +
                $"[Status], Role, CreatedDate) " +
                $"VALUES (@Name, @Surname, @Email, @Login," +
                $" @Password, @Status, @Role, @CreatedDate);";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Name", obj.Name.ToString());
                command.Parameters.AddWithValue("@Surname", obj.Surname.ToString());
                command.Parameters.AddWithValue("@Email", obj.Email.ToString());
                command.Parameters.AddWithValue("@Login", obj.Login.ToString());
                command.Parameters.AddWithValue("@Password", obj.Password.ToString());
                command.Parameters.AddWithValue("@Status", (int)obj.Status);
                command.Parameters.AddWithValue("@Role", (int)obj.Role);
                command.Parameters.AddWithValue("@CreatedDate", obj.CreatedDate.ToString());

                await command.ExecuteNonQueryAsync();
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<bool> DeepDeleteAsync(int id)
    {
        if (id <= 0)
            return false;
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM Employees " +
                "WHERE Id = @id";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);

            var result = await command.ExecuteNonQueryAsync();

            return result > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (id <= 0)
            return false;

        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE Employees " +
                "SET Status = 3," +
                "DeletedDate = @DeletedDate " +
                "WHERE Id = @id";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@DeletedDate", DateTime.Now);

            var result = await command.ExecuteNonQueryAsync();

            return result > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Employees>> GetAllAsync()
    {
        IList<Employees> employeesList = new List<Employees>();

        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM Employees WHERE Status != 3";

            SqlCommand command = new SqlCommand(query, _connection);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Employees employee = new Employees
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Surname = (string)reader["Surname"],
                        Login = (string)reader["Login"],
                        Email = (string)reader["Email"],
                        Password = (string)reader["Password"],
                        Status = (Status)reader["Status"],
                        Role = (Role)reader["Role"],
                    };
                    employeesList.Add(employee);
                }
            }
            return employeesList;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Employees> GetByIdAsync(int id)
    {
        if (id <= 0)
            return new Employees();

        Employees employee = null;

        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM Employees WHERE Id = @id AND Status != 3";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    employee = new Employees
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Surname = (string)reader["Surname"],
                        Email = (string)reader["Email"],
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        Status = (Status)reader["Status"],
                        Role = (Role)reader["Role"],
                        CreatedDate = (DateTime)reader["CreatedDate"]
                    };
                }
            }
            return employee;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Employees();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<bool> UpdateAsync(int id, Employees obj)
    {
        if (obj == null || id <= 0)
            return false;

        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE Employees SET Name = @Name, " +
                $"Surname = @Surname, Email = @Email, Login = @Login, Password = @Password, " +
                $"Status = @Status, Role = @Role, ModifyDate = @ModifyDate WHERE Id = @Id;";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", obj.Name.ToString());
                command.Parameters.AddWithValue("@Surname", obj.Surname.ToString());
                command.Parameters.AddWithValue("@Email", obj.Email.ToString());
                command.Parameters.AddWithValue("@Login", obj.Login.ToString());
                command.Parameters.AddWithValue("@Password", obj.Password.ToString());
                command.Parameters.AddWithValue("@Status", (int)obj.Status);
                command.Parameters.AddWithValue("@Role", (int)obj.Role);
                command.Parameters.AddWithValue("@ModifyDate", obj.ModifyDate.ToString());

                await command.ExecuteNonQueryAsync();
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
