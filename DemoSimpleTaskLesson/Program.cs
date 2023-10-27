using DemoSimpleTaskLesson.Services.Employee;

namespace DemoSimpleTaskLesson;

public class Program
{
    public static async Task Main(string[] args)
    {
        EmployeeService Service = new EmployeeService();

        // Create
        //await Service.CreateAsync(new Employees
        //{
        //    Name = "Test",
        //    Surname = "Test",
        //    Email = "Test",
        //    Login = "Test",
        //    Password = "Test",
        //    Status = Status.Created,
        //    Role = Role.Admin,
        //    CreatedDate = DateTime.Now,
        //});

        //Console.ReadKey();

        // Update
        //var user = new Employees
        //{
        //    Name = "U",
        //    Surname = "u",
        //    Email = "u",
        //    Login = "u",
        //    Password = "u",
        //    Status = Status.Deleted,
        //    Role = Role.Other,
        //    ModifyDate = DateTime.Now
        //};
        //await Service.UpdateAsync(1, user);

        // GetById
        //var resultGetById = await Service.GetByIdAsync(2);
        //Console.WriteLine(resultGetById);

        // GetAll
        //var resultGetAll = await Service.GetAllAsync();

        //foreach (var item in resultGetAll)
        //{
        //    Console.WriteLine(item.Id);
        //    Console.WriteLine(item.Name);
        //    Console.WriteLine(item.Surname);
        //    Console.WriteLine(item.Login);
        //    Console.WriteLine(item.Password);
        //    Console.WriteLine(item.Email);
        //    Console.WriteLine(item.Status);
        //    Console.WriteLine(item.Role);

        //    Console.WriteLine();
        //}

        // DeepDelete
        //var resultDeepDelete = await Service.DeepDeleteAsync(2);
        //Console.WriteLine(resultDeepDelete);

        // Delete
        var resultDelete = await Service.DeleteAsync(3);
        Console.WriteLine(resultDelete);
    }
}