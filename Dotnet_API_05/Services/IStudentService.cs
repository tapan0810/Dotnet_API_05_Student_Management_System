using Dotnet_API_05.Entities.Dtos;

namespace Dotnet_API_05.Services
{
    public interface IStudentService
    {
        public Task<List<GetAllStudentDto>> GetAllStudents();
        public Task<GetStudentByIdDto?> getStudentById(int studentId);
        public Task<GetStudentByIdDto?> CreateStudent(CreateStudentDto student);
        public Task<bool> UpdateStudent(int id,UpdateStudentDto student);
        public Task<bool> DeleteStudent(int id);
    }
}
