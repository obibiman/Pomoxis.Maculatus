﻿using ArticleCommands.WebAPI.Database.Contracts;
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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repo;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerRepository repo, ILogger<CustomerController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}"), ActionName("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(int Id)
        {
            var theCustomer = await _repo.GetByIdAsync(Id);
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(theCustomer);
        }

        [HttpGet]
        [Route("GetAllCustomers"), ActionName("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            var theCustomer = await _repo.GetAllAsync();
            return Ok(theCustomer);
        }

        [HttpPost]
        [Route("CreateCustomer"), ActionName("CreateCustomer")]
        [Produces("application/json", Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status201Created), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            string author = "To restore the dignity of man";

            byte[] bytes = Encoding.ASCII.GetBytes(author);
            //customer.Photo = bytes;
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("You requested a method {MethodName} for {customer}", System.Reflection.MethodBase.GetCurrentMethod().Name, customer);
                return BadRequest(ModelState);
            }
            else
            {
                _logger.LogError("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            var theCustomer = await _repo.CreateAsync(customer);
            return Ok(theCustomer);
        }

        [HttpPut]
        [Route("UpdateCustomer"), ActionName("UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            await _repo.UpdateAsync(customer);
            return Ok(customer);
        }

        [HttpDelete]
        [Route("DeleteCustomer"), ActionName("DeleteCustomer")]
        public async Task<OkResult> DeleteCustomer(Customer customer)
        {
            _logger.LogInformation("You requested a method {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            await _repo.DeleteAsync(customer);
            return Ok();
        }
    }
}