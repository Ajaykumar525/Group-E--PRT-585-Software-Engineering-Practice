using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Publisher;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private IPublisher_Service _Publisher_Service;

        public PublisherController(IPublisher_Service Publisher_Service)
        {
            _Publisher_Service = Publisher_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddPublisher(string name)
        {
            var result = await _Publisher_Service.AddPublisher(name);
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
        public async Task<IActionResult> GetAllPublishers()
        {
            var result = await _Publisher_Service.GetAllPublisher();
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
        public async Task<IActionResult> UpdatePublisher(Publisher_Pass_Object Publisher)
        {
            var result = await _Publisher_Service.UpdatePublisher(Publisher.id, Publisher.name);
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
        public async Task<IActionResult> DeletePublisher(Publisher_Pass_Object Publisher)
        {
            var result = await _Publisher_Service.DeletePublisher(Publisher.id);
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
