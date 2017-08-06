using BlogCore.DAL;
using BlogCore.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogCore.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {

        private readonly CategoryContext _context;

        public CategoryController(CategoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        [HttpGet("{Id}", Name = "GetCategory")]
        public IActionResult GetById(int id)
        {
            var item = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        public IActionResult Create([FromBody] Category catObject)
        {
            if (catObject == null)
            {
                return BadRequest();
            }

            _context.Categories.Add(catObject);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }
    }
}
