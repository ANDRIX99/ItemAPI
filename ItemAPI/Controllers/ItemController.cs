using ItemAPI.Controllers.Data;
using ItemAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(ItemDbContext context) : ControllerBase
    {
        private readonly ItemDbContext _context = context;

        [HttpGet]   // Get all items
        public async Task<ActionResult<Item>> getItem()
        {
            return Ok( await _context.Items
                .ToListAsync());
        }

        [HttpGet]
        [Route("{id}")] // Get item by id
        public async Task<ActionResult<Item>> getItemById(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> addItem(Item newItem)
        {
            if (newItem is null) return BadRequest();

            _context.Items.Add(newItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(getItemById), new { id = newItem.Id }, newItem);
        }

        [HttpPut] // Update item
        [Route("{id}")]
        public async Task<IActionResult> updateItem(int id, Item updateItem)
        {
            var item = await _context.Items.FindAsync(id);
            if (item is null) return NotFound();

            item.Nome = updateItem.Nome;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete] // Delete item
        [Route("{id}")]
        public async Task<IActionResult> deleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item is null) return NotFound();

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
