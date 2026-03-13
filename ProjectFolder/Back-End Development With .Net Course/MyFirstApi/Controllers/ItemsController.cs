using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Services;

namespace MyApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    // GET: api/items
    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetItems()
    {
        return Ok(ItemRepository.GetAll());
    }

    // GET: api/items/{id}
    [HttpGet("{id}")]
    public ActionResult<Item> GetItem(int id)
    {
        var item = ItemRepository.Get(id);
        if (item is null)
            return NotFound();
        return Ok(item);
    }

    // POST: api/items
    [HttpPost]
    public ActionResult<Item> PostItem(Item item)
    {
        ItemRepository.Add(item);
        // Returns 201 Created with location header pointing to the new resource
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }

    // PUT: api/items/{id}
    [HttpPut("{id}")]
    public IActionResult PutItem(int id, Item item)
    {
        if (id != item.Id)
            return BadRequest();

        var updated = ItemRepository.Update(id, item);
        if (!updated)
            return NotFound();

        return NoContent(); // 204 No Content (standard for successful PUT)
    }

    // DELETE: api/items/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteItem(int id)
    {
        var deleted = ItemRepository.Delete(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}