using Dotnet_API_05.Entities.Dtos;
using Dotnet_API_05.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_API_05.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(
            IStudentService studentService,
            ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        // 🔹 GET: api/student
        [HttpGet]
        public async Task<ActionResult<List<GetAllStudentDto>>> GetAllStudents()
        {
            _logger.LogInformation("HTTP GET request received: GetAllStudents");

            var students = await _studentService.GetAllStudents();

            _logger.LogInformation(
                "HTTP GET completed: {StudentCount} students returned",
                students.Count
            );

            return Ok(students);
        }

        // 🔹 GET: api/student/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetStudentByIdDto>> GetStudentById(int id)
        {
            _logger.LogInformation(
                "HTTP GET request received: GetStudentById with Id {StudentId}",
                id
            );

            var student = await _studentService.getStudentById(id);

            if (student is null)
            {
                _logger.LogWarning(
                    "HTTP GET failed: Student with Id {StudentId} not found",
                    id
                );
                return NotFound($"Student with Id {id} not found");
            }

            _logger.LogInformation(
                "HTTP GET successful: Student with Id {StudentId} returned",
                id
            );

            return Ok(student);
        }

        // 🔹 POST: api/student
        [HttpPost]
        public async Task<ActionResult<GetStudentByIdDto>> CreateStudent(
            [FromBody] CreateStudentDto student)
        {
            _logger.LogInformation("HTTP POST request received: CreateStudent");

            if (student is null)
            {
                _logger.LogWarning("CreateStudent failed: request body is null");
                return BadRequest("Invalid student data");
            }

            var createdStudent = await _studentService.CreateStudent(student);

            if (createdStudent is null)
            {
                _logger.LogWarning("CreateStudent failed: service returned null");
                return BadRequest("Student creation failed");
            }

            _logger.LogInformation(
                "HTTP POST successful: Student created with Id {StudentId}",
                createdStudent.StudentId
            );

            return CreatedAtAction(
                nameof(GetStudentById),
                new { id = createdStudent.StudentId },
                createdStudent
            );
        }

        // 🔹 PUT: api/student/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateStudent(
            int id,
            [FromBody] UpdateStudentDto student)
        {
            _logger.LogInformation(
                "HTTP PUT request received: UpdateStudent with Id {StudentId}",
                id
            );

            var updated = await _studentService.UpdateStudent(id, student);

            if (!updated)
            {
                _logger.LogWarning(
                    "HTTP PUT failed: Student with Id {StudentId} not found",
                    id
                );
                return NotFound($"Student with Id {id} not found");
            }

            _logger.LogInformation(
                "HTTP PUT successful: Student with Id {StudentId} updated",
                id
            );

            return NoContent();
        }

        // 🔹 DELETE: api/student/{id}
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            _logger.LogInformation(
                "HTTP DELETE request received: DeleteStudent with Id {StudentId}",
                id
            );

            var deleted = await _studentService.DeleteStudent(id);

            if (!deleted)
            {
                _logger.LogWarning(
                    "HTTP DELETE failed: Student with Id {StudentId} not found",
                    id
                );
                return NotFound($"Student with Id {id} not found");
            }

            _logger.LogInformation(
                "HTTP DELETE successful: Student with Id {StudentId} deleted",
                id
            );

            return NoContent();
        }
    }
}
