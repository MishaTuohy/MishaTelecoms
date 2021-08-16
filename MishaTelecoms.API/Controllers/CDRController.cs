using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MishaTelecoms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CDRController : Controller
    {
        private readonly ILogger<CDRController> _logger;

        public CDRController(ILogger<CDRController> logger)
        {
            _logger = logger;
        }

        // api/CDRData/
        [Authorize]
        [HttpPost]
        public void Post([FromBody] CDRData data)
        {
            
        }

        // api/CDRData/
        [Authorize]
        [HttpGet]
        public IEnumerable<CDRData> GetAll()
        {
            return null;
        }

        // api/CDRData/id/{id}
        [Authorize]
        [HttpGet("id/{id}")]
        public CDRData GetById(Guid id)
        {
            return null;
        }

        // api/CDRData/delete/{id}
        [Authorize]
        [HttpDelete("delete/{id}")]
        public void Delete(Guid id)
        {

        }
    }
}
