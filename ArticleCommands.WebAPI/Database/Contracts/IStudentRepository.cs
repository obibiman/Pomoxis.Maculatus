using DomainUsage.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleCommands.WebAPI.Database.Contracts
{
    public interface IStudentRepository
    {
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Student</returns>
        Task<Student> CreateAsync(Student student);

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="student"></param>
        /// <returns>void</returns>
        Task DeleteAsync(Student student);

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns>student list</returns>
        Task<IEnumerable<Student>> GetAllAsync();

        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Student</returns>
        Task<Student> GetByIdAsync(int Id);

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Student</returns>
        Task<Student> UpdateAsync(Student student);
    }
}
