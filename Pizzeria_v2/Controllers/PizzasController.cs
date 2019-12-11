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
    public class PizzasController : ControllerBase
    {
        private readonly s17230Context _context;

        public PizzasController(s17230Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            var user = _context.Pizza.FirstOrDefault(e => e.IdPizza == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
        [HttpPost]
        public IActionResult CreatePizza(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();

            return StatusCode(201, newPizza);
        }
        [HttpPut]
        public IActionResult UpdatePizza(Pizza updatedPizza)
        {
            if (_context.Pizza.Count(e => e.IdPizza == updatedPizza.IdPizza) == 0)
            {
                return NotFound();
            }
           
            _context.Pizza.Attach(updatedPizza);
            _context.Entry(updatedPizza).State = EntityState.Modified; 
            _context.SaveChanges();

            return Ok(updatedPizza);
        }
        [HttpDelete("{IdPizza:int}")]
        public IActionResult DeletePizza(int IdPizza)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == IdPizza);
            if(pizza == null)
            {
                return NotFound();
            }

            _context.Pizza.Remove(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }
    }
}