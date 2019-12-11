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
    public class PromotionsController : ControllerBase
    {

        private s17230Context _context;

        public PromotionsController(s17230Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPromotions()
        {
            return Ok(_context.Promocja.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPromotion(int id)
        {
            var user = _context.Promocja.FirstOrDefault(e => e.IdPromocja == id);
            if (user == null)
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