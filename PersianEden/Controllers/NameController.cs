using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersianEden.Infrastructure.Managers;
using PersianEden.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersianEden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        private readonly INameManager _manager;
        public NameController(INameManager manager)
        {
            _manager = manager;
        }
        [HttpPost("addName")]
        public async Task<IActionResult> AddNameAsync(NameModel model)
        {
            await _manager.AddName(model);
            return Ok("Name Added");
        }
    }
}
