using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiftsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LiftsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<LiftsController>
        [HttpGet]
        public IActionResult GetAllLifts()
        {
            try
            {
                List<Lift> allLifts = _context.Lifts.ToList();
                return StatusCode(200, allLifts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("myLifts"), Authorize]
        public IActionResult GetUserLifts()
        {
            try
            {
                string userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }
                var userLifts = _context.Lifts.Where(l => l.UserId.Equals(userId)).ToList();
                return StatusCode(200, userLifts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<LiftsController>/5
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
                Lift lift = _context.Lifts.FirstOrDefault(l => l.Id == id);

                if (lift == null)
                {
                    return NotFound();
                }

                return StatusCode(200, lift);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<LiftsController>
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Lift newLift)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }
                newLift.UserId = userId;
                _context.Lifts.Add(newLift);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                };
                _context.SaveChanges();
                return StatusCode(201, newLift);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<LiftsController>/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromBody] Lift newLift)
        {
            try
            {
                string userId = User.FindFirstValue("id");

                Lift lift = _context.Lifts.FirstOrDefault(l => l.Id == id);
                if (lift == null)
                {
                    return NotFound();
                }
                if (string.IsNullOrEmpty(userId) || lift.UserId != userId)
                {
                    return Unauthorized();
                }
                lift.LiftName = newLift.LiftName;
                lift.WeightInPounds = newLift.WeightInPounds;
                lift.DateRecorded = newLift.DateRecorded;
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();
                return StatusCode(200, lift);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<LiftsController>/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                Lift lift = _context.Lifts.FirstOrDefault(l => l.Id == id);
                if (lift == null)
                {
                    return NotFound();
                }
                if (string.IsNullOrEmpty(userId) || lift.UserId != userId)
                {
                    return Unauthorized();
                }
                _context.Lifts.Remove(lift);
                _context.SaveChanges();
                return StatusCode(204, lift);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
