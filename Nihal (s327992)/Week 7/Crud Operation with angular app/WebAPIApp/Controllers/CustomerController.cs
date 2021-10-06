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

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddCustomer(string Customer_Name, string Customer_Surname, string Contact_Email, string Contact_Number)
        {
            var result = await _Customer_Service.AddCustomer(Customer_Name, Customer_Surname,Contact_Email, Contact_Number);
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

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCustomer(int CustomerID, string Customer_Name, string Customer_Surname, string Contact_Email, string Contact_Number)
        {
            var result = await _Customer_Service.UpdateCustomer(CustomerID, Customer_Name, Customer_Surname, Contact_Email, Contact_Number);
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
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _Customer_Service.DeleteCustomer(id);
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
