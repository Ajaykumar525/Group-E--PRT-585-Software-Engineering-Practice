using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Category;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategory_Service _Category_Service;

        public CategoryController(ICategory_Service Category_Service)
        {
            _Category_Service = Category_Service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddCategory(string name, string gender)
        {
            var result = await _Category_Service.AddCategory(name, gender);
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
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _Category_Service.GetAllCategories();
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
        public async Task<IActionResult> UpdateCategory(int id, string name, string gender)
        {
            var result = await _Category_Service.UpdateCategory(id, name, gender);
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
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var result = await _Category_Service.DeleteCategory(Id);
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
