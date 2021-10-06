using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Product;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct_Service _Product_Service;

        public ProductController(IProduct_Service Product_Service)
        {
            _Product_Service = Product_Service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddProduct(string ProductName, decimal price, int qty)
        {
            var result = await _Product_Service.AddProduct(ProductName, price, qty);
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
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _Product_Service.GetAllProducts();
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
        public async Task<IActionResult> UpdateProduct(int id, string ProductName, decimal price, int qty)
        {
            var result = await _Product_Service.UpdateProduct(id, ProductName, price, qty);
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
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _Product_Service.DeleteProduct(id);
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
