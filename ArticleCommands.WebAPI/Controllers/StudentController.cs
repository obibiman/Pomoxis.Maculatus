using ArticleCommands.WebAPI.Database.Contracts;
using DomainUsage.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCommands.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repo;
        private readonly ILogger<StudentController> _logger;
        private readonly Serilog.ILogger _logr;
        public StudentController(IStudentRepository repo, ILogger<StudentController> logger, Serilog.ILogger logr)
        {
            _repo = repo;
            _logger = logger;
            _logr = logr;
        }

        [HttpGet]
        [Route("{id}"), ActionName("GetStudentById")]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            var theStudent = await _repo.GetByIdAsync(Id);
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            _logr.Information("The student under review is {@Student}", theStudent);

            return Ok(theStudent);
        }

        [HttpGet]
        [Route("GetAllStudents"), ActionName("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            var theStudent = await _repo.GetAllAsync();

            _logr.Information("The student under review is {@Student}", theStudent);
            return Ok(theStudent);
        }

        [HttpPost]
        [Route("CreateStudent"), ActionName("CreateStudent")]
        [Produces("application/json", Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("You requested a method {MethodName} for {student}", System.Reflection.MethodBase.GetCurrentMethod().Name, student);
                _logr.Error("The following student has been added {@Student}", student);
                return BadRequest(ModelState);
            }
            else
            {
                _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);

                _logr.Information("The following student has been added {@Student}", student);
            }
            var theStudent = await _repo.CreateAsync(student);
            return Ok(theStudent);
        }

        [HttpPut]
        [Route("UpdateStudent"), ActionName("UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            await _repo.UpdateAsync(student);
            _logr.Information("The following student has been updated {@Student}", student);
            return Ok(student);
        }

        [HttpDelete]
        [Route("DeleteStudent"), ActionName("DeleteStudent")]
        public async Task<OkResult> DeleteStudent(Student student)
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            await _repo.DeleteAsync(student);
            _logr.Information("The following student has been deleted {@Student}", student);
            return Ok();
        }
    }
}