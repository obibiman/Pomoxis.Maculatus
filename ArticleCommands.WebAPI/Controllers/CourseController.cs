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
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _repo;
        private readonly ILogger<CourseController> _logger;
        private readonly Serilog.ILogger _logr;
        public CourseController(ICourseRepository repo, ILogger<CourseController> logger, Serilog.ILogger logr)
        {
            _repo = repo;
            _logger = logger;
            _logr = logr;
        }

        [HttpGet]
        [Route("{id}"), ActionName("GetCourseById")]
        public async Task<IActionResult> GetCourseById(int Id)
        {
            var theCourse = await _repo.GetByIdAsync(Id);
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            _logr.Information("The course under review is {@Course}", theCourse);

            return Ok(theCourse);
        }

        [HttpGet]
        [Route("GetAllCourses"), ActionName("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            var theCourse = await _repo.GetAllAsync();

            _logr.Information("The course under review is {@Course}", theCourse);
            return Ok(theCourse);
        }

        [HttpPost]
        [Route("CreateCourse"), ActionName("CreateCourse")]
        [Produces("application/json", Type = typeof(Course))]
        [ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("You requested a method {MethodName} for {course}", System.Reflection.MethodBase.GetCurrentMethod().Name, course);
                _logr.Error("The following course has been added {@Course}", course);
                return BadRequest(ModelState);
            }
            else
            {
                _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);

                _logr.Information("The following course has been added {@Course}", course);
            }
            var theCourse = await _repo.CreateAsync(course);
            return Ok(theCourse);
        }

        [HttpPut]
        [Route("UpdateCourse"), ActionName("UpdateCourse")]
        [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCourse(Course course)
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            await _repo.UpdateAsync(course);
            _logr.Information("The following course has been updated {@Course}", course);
            return Ok(course);
        }

        [HttpDelete]
        [Route("DeleteCourse"), ActionName("DeleteCourse")]
        public async Task<OkResult> DeleteCourse(Course course)
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            await _repo.DeleteAsync(course);
            _logr.Information("The following course has been deleted {@Course}", course);
            return Ok();
        }
    }
}