using ItemAPI.Controllers.Data;
using ItemAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemDetailController(ItemDbContext context) : ControllerBase
    { 
        private readonly ItemDbContext _context = context;

        [HttpGet]   // Get all item details
        public async Task<ActionResult<ItemDetail>> getItemDetail()
        {
            var items = await _context.ItemDetails
                .Join(_context.Items,
                    i => i.ItemId,
                    o => o.Id,
                    (i, o) => new
                    {
                        o.Nome,
                        i.Amount,
                        i.ItemId
                    })
                .ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ItemDetail>> getItemDetailById(int id)
        {
            var item = await _context.ItemDetails.FindAsync(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

        [HttpGet]
        [Route("detail/{id}")]
        public async Task<ActionResult<ItemDetail>> getItemDetailByIds(int id)
        {
            // query to obtain name of a itemDetails detail
            var item = await _context.ItemDetails
                .Where(i => i.IdItem == id)
                .Join(_context.Items,
                    i => i.ItemId,
                    o => o.Id,
                    (i, o) => new
                    {
                        o.Nome,
                        i.Amount
                    })
                .ToListAsync();

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDetail>> addItemDetail(ItemDetail newItemDetail)
        {
            if (newItemDetail is null) return BadRequest();

            _context.ItemDetails.Add(newItemDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(getItemDetailById), new { id = newItemDetail.Id }, newItemDetail);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateItemDetail(int id, ItemDetail updateItemDetail)
        {
            var item = await _context.ItemDetails.FindAsync(id);
            if (item is null) return NotFound();

            item.Amount = updateItemDetail.Amount;
            item.IdItem = updateItemDetail.IdItem;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> deleteItemDetail(int id)
        {
            var item = await _context.ItemDetails.FindAsync(id);
            if (item is null) return NotFound();

            _context.ItemDetails.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
