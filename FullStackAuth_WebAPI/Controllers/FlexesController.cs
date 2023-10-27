using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlexesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FlexesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<FlexesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Flex> allFlexes = _context.Flexes.ToList();
                return StatusCode(200, allFlexes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<FlexesController>/5
        [HttpGet("{id}"), Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }
                Flex flex = _context.Flexes.FirstOrDefault(f => f.Id == id);
                if (flex == null)
                {
                    return NotFound();
                }
                return StatusCode(200, flex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<FlexesController>
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Flex flex)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty (userId))
                {
                    return Unauthorized();
                }
                _context.Flexes.Add(flex);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();
                return StatusCode(201, flex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<FlexesController>/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromBody] Flex newFlex)
        {
            try
            {
                string userId = User.FindFirstValue("id");

                Flex flex = _context.Flexes.Include(f => f.Lift).FirstOrDefault (f => f.Id == id);
                if (flex == null)
                {
                    return NotFound();
                }
                if (string.IsNullOrEmpty(userId) || flex.Lift.UserId != userId)
                {
                    return Unauthorized();
                }
                flex.ComparisonId = newFlex.ComparisonId;
                flex.Quantity = newFlex.Quantity;
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();
                return StatusCode(200, flex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPatch("{id}/favorite"), Authorize]
        public IActionResult ToggleFavorite(int id)
        {
            try
            {
                string userId = User.FindFirstValue("id");

                Flex flex = _context.Flexes.Include(f => f.Lift).FirstOrDefault(f => f.Id == id);
                if (flex == null)
                {
                    return NotFound();
                }
                if (string.IsNullOrEmpty(userId) || flex.Lift.UserId != userId)
                {
                    return Unauthorized();
                }
                flex.IsFavorite = !flex.IsFavorite;
                _context.SaveChanges();
                return StatusCode(200, flex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<FlexesController>/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                Flex flex = _context.Flexes.Include(f => f.Lift).FirstOrDefault(f => f.Id == id);
                if (string.IsNullOrEmpty(userId) || flex.Lift.UserId != userId)
                {
                    return Unauthorized();
                }
                _context.Flexes.Remove(flex);
                _context.SaveChanges();
                return StatusCode(204, flex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
