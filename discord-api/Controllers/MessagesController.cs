using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiscordApi.Models;
using DiscordApi.Contexts;

namespace DiscordApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly DiscordDbContext _context;

        public MessagesController(DiscordDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetAllMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessageById(string id)
        {
            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.MessageId == id);

            return message;
        }

        [HttpPost]
        public async Task<ActionResult<Message>> CreateMessage(Message message)
        {
            message.MessageId = Guid.NewGuid().ToString();
            message.Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMessageById), new { id = message.MessageId }, message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessageById(string id, Message message)
        {
            if (id != message.MessageId)
                return BadRequest();

            _context.Entry(message).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageById(string id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
                return NotFound();

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}