using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FlexesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FlexesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FlexesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlexesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
