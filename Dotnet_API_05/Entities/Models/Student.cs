namespace Dotnet_API_05.Entities.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public required string StudentName { get; set; }
        public required string StudentEmail { get; set; } 
        public string StudentPhone { get; set;} = string.Empty;
        public string StudentDescription { get; set; } = string.Empty;
    }
}
