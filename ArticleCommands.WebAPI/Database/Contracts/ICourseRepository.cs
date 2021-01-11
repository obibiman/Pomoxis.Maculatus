using DomainUsage.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleCommands.WebAPI.Database.Contracts
{
    public interface ICourseRepository
    {
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="course"></param>
        /// <returns>Course</returns>
        Task<Course> CreateAsync(Course course);

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="course"></param>
        /// <returns>void</returns>
        Task DeleteAsync(Course course);

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns>course list</returns>
        Task<IEnumerable<Course>> GetAllAsync();

        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Course</returns>
        Task<Course> GetByIdAsync(int Id);

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="course"></param>
        /// <returns>Course</returns>
        Task<Course> UpdateAsync(Course course);
    }
}
