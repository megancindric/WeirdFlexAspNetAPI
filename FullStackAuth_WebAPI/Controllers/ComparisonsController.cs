﻿using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComparisonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ComparisonsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ComparisonsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Comparison> comparisons = _context.Comparisons.ToList();
                return StatusCode(200, comparisons);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ComparisonsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var comparison = _context.Comparisons.FirstOrDefault(c => c.Id == id);
                if (comparison == null)
                {
                    return NotFound();
                }
                return StatusCode(200, comparison);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ComparisonsController>
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] ComparisonForPostDto comparison)
        {
            try
            {
                if (Enum.TryParse(comparison.Category, out ComparisonCategory newCategory))
                {
                    Comparison newComparison = new Comparison()
                    {
                        Name = comparison.Name,
                        WeightInPounds = comparison.WeightInPounds,
                        Category = newCategory
                    };
                _context.Comparisons.Add(newComparison);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();
                return StatusCode(201, comparison);
                }
               else
                {
                    return BadRequest("Invalid Category");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ComparisonsController>/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromBody] Comparison newComparison)
        {
            try
            {
                Comparison comparison = _context.Comparisons.FirstOrDefault(c =>c.Id == id);
                if (comparison == null)
                {
                    return NotFound();
                }
                comparison.WeightInPounds = newComparison.WeightInPounds;
                comparison.Name = newComparison.Name;
                comparison.Category = newComparison.Category;
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();
                return StatusCode(200, comparison);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<ComparisonsController>/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                Comparison comparison = _context.Comparisons.FirstOrDefault(c =>c.Id == id);
                if (comparison == null)
                {
                    return NotFound();
                }
                _context.Comparisons.Remove(comparison);
                _context.SaveChanges();
                return StatusCode(204, comparison);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
