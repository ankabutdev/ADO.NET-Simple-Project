namespace DemoSimpleTaskLesson.Models;

public class Auditable
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime DeletedDate { get; set; }

    public DateTime ModifyDate { get; set; }
}
