using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiscordApi.Models;
using DiscordApi.Contexts;


namespace DiscordApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ChatRoomsController : ControllerBase
    {
        private readonly DiscordDbContext _context;

        public ChatRoomsController(DiscordDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatRoom>>> GetAllChatRooms()
        {
            return await _context.ChatRooms
                .Include(c => c.Rooms)
                .Include(c => c.Users)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChatRoom>> GetChatRoomById(Guid id)
        {
            var chatRoom = await _context.ChatRooms
                .Include(c => c.Rooms)
                .Include(c => c.Users)
                .FirstOrDefaultAsync(c => c.ChatRoomId == id);

            return chatRoom;
        }

        [HttpPost]
        public async Task<ActionResult<ChatRoom>> CreateChatRoom(ChatRoom chatRoom)
        {
            chatRoom.ChatRoomId = Guid.NewGuid();
            _context.ChatRooms.Add(chatRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChatRoomById), new { id = chatRoom.ChatRoomId }, chatRoom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChatRoomById(Guid id, ChatRoom chatRoom)
        {
            if (id != chatRoom.ChatRoomId)
                return BadRequest();

            _context.Entry(chatRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatRoomById(Guid id)
        {
            var chatRoom = await _context.ChatRooms.FindAsync(id);
            if (chatRoom == null)
                return NotFound();

            _context.ChatRooms.Remove(chatRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}