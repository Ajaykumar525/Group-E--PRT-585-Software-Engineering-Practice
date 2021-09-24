using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Customer;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomer_Service _Customer_Service;

        public CustomerController(ICustomer_Service Customer_Service)
        {
            _Customer_Service = Customer_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddCustomer(string name, string Customer_Lastname, string Contact_Number)
        {
            var result = await _Customer_Service.AddCustomer(name, Customer_Lastname, Contact_Number);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _Customer_Service.GetAllCustomers();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCustomer(Customer_Pass_Object customer)
        {
            var result = await _Customer_Service.UpdateCustomer(customer.id, customer.name, customer.Customer_Lastname, customer.Contact_Number);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteCustomer(Customer_Pass_Object customer)
        {
            var result = await _Customer_Service.DeleteCustomer(customer.id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

    }
}
