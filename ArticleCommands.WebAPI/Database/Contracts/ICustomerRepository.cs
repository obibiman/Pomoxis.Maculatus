using DomainUsage.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleCommands.WebAPI.Database.Contracts
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Customer</returns>
        Task<Customer> CreateAsync(Customer customer);

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>void</returns>
        Task DeleteAsync(Customer customer);

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns>customer list</returns>
        Task<IEnumerable<Customer>> GetAllAsync();

        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Customer</returns>
        Task<Customer> GetByIdAsync(int Id);

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Customer</returns>
        Task<Customer> UpdateAsync(Customer customer);
    }
}