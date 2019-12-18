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
        [HttpPost]
        public IActionResult CreatePromotions(Promocja newPromotion)
        {
            _context.Promocja.Add(newPromotion);
            _context.SaveChanges();

            return StatusCode(201, newPromotion);
        }
        [HttpPut]
        public IActionResult UpdatePromocja(Promocja updatedPromotion)
        {
            if (_context.Promocja.Count(e => e.IdPromocja == updatedPromotion.IdPromocja) == 0)
            {
                return NotFound();
            }

            _context.Promocja.Attach(updatedPromotion);
            _context.Entry(updatedPromotion).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPromotion);
        }
        [HttpDelete("{IdPromocja:int}")]
        public IActionResult DeletePromocja(int IdPromotion)
        {
            var promo = _context.Promocja.FirstOrDefault(e => e.IdPromocja == IdPromotion);
            if (promo == null)
            {
                return NotFound();
            }

            _context.Promocja.Remove(promo);
            _context.SaveChanges();

            return Ok(promo);
        }
    }
}