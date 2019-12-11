using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria_v2.Models;

namespace PRO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private s17230Context _context;

        public UsersController(s17230Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_context.Uzytkownik.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Uzytkownik.FirstOrDefault(e => e.IdUzytkownik == id);
            if(user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
    }
}