using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost]
        public IActionResult CreateUser(Uzytkownik newUser)
        {
            _context.Uzytkownik.Add(newUser);
            _context.SaveChanges();

            return StatusCode(201, newUser);
        }
        [HttpPut]
        public IActionResult UpdateUser(Uzytkownik updatedUser)
        {
            if (_context.Uzytkownik.Count(e => e.IdUzytkownik == updatedUser.IdUzytkownik) == 0)
            {
                return NotFound();
            }

            _context.Uzytkownik.Attach(updatedUser);
            _context.Entry(updatedUser).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedUser);
        }
        [HttpDelete("{IdUser:int}")]
        public IActionResult DeleteUser(int IdUser)
        {
            var user = _context.Uzytkownik.FirstOrDefault(e => e.IdUzytkownik == IdUser);
            if (user == null)
            {
                return NotFound();
            }

            _context.Uzytkownik.Remove(user);
            _context.SaveChanges();

            return Ok(user);
        }
    }
}