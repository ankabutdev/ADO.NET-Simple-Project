using DemoSimpleTaskLesson.Enums;

namespace DemoSimpleTaskLesson.Models;

public class Employees : Auditable
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool DeepDeleted { get; set; }

    public Status Status { get; set; }

    public Role Role { get; set; }

}
