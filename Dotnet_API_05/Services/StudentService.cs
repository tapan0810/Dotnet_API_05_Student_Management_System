using Dotnet_API_05.Data;
using Dotnet_API_05.Entities.Dtos;
using Dotnet_API_05.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_05.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _context;
        private readonly ILogger<StudentService> _logger;
        public StudentService(StudentDbContext context, ILogger<StudentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<GetAllStudentDto>> GetAllStudents()
        {
            _logger.LogInformation("Fetching all Students from Database");

            var student = await _context.Students.
                Select(s => new GetAllStudentDto
                {
                    StudentId = s.StudentId,
                    StudentName = s.StudentName
                }).ToListAsync();

            _logger.LogInformation($"Fetched StudentCount students from database, No: {student.Count}");

            return student;
        }

        public async Task<GetStudentByIdDto?> getStudentById(int studentId)
        {
            _logger.LogInformation("Querying database for student Id {studentId}", studentId);

            var stud = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == studentId);

            if (stud is null)
            {
                _logger.LogInformation("Student with ID:{studentId} not available", studentId);
            }

            return new GetStudentByIdDto
            {
                StudentId = stud.StudentId,
                StudentName = stud.StudentName,
                StudentEmail = stud.StudentEmail,
                StudentPhone = stud.StudentPhone,
                StudentDescription = stud.StudentDescription
            };
        }

        public async Task<GetStudentByIdDto?> CreateStudent(CreateStudentDto student)
        {
            if (student is null)
            {
                _logger.LogInformation("{Student} object is null", student);
                return null;
            }

            _logger.LogInformation("Creating new student with Name:{StudentName}", student.StudentName);


            var stud = new Student
            {
                StudentName = student.StudentName,
                StudentEmail = student.StudentEmail,
                StudentPhone = student.StudentPhone,
                StudentDescription = student.StudentDescription
            };

            _context.Students.Add(stud);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Student created successfully with Id {studentId}", stud.StudentId);

            return new GetStudentByIdDto
            {
                StudentId = stud.StudentId,
                StudentName = stud.StudentName,
                StudentEmail = stud.StudentEmail,
                StudentPhone = stud.StudentPhone,
                StudentDescription = stud.StudentDescription
            };
        }

        public async Task<bool> UpdateStudent(int id, UpdateStudentDto student)
        {
            var stud = await _context.Students.FindAsync(id);

            if (stud is null)
            {
                _logger.LogInformation("Student with {StudentId} not present", id);
                return false;
            }

            stud.StudentName = student.StudentName;
            stud.StudentEmail = student.StudentEmail;
            stud.StudentPhone = student.StudentPhone;
            stud.StudentDescription = student.StudentDescription;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Student with {studentId} updated successfully", id);
            return true;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            _logger.LogInformation(
                "Attempting to delete student with Id {StudentId}",id);
            var stud = await _context.Students.FindAsync(id);

            if(stud is null)
            {
                _logger.LogInformation("Attempting to delete student with Id {StudentId}",
        id);
                return false;
            }

            _context.Students.Remove(stud);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
     "Student with Id {StudentId} deleted successfully",
     id
 );
            return true;
        }
    }
}
