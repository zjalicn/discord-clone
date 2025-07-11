using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiscordApi.Models;
using DiscordApi.Contexts;

namespace DiscordApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly DiscordDbContext _context;

        public RoomsController(DiscordDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRooms()
        {
            return await _context.Rooms
                .Include(r => r.ChatRoom)
                .Include(r => r.Messages)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById(Guid id)
        {
            var room = await _context.Rooms
                .Include(r => r.ChatRoom)
                .Include(r => r.Messages)
                .FirstOrDefaultAsync(r => r.RoomId == id);

            return room;
        }

        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom(Room room)
        {
            room.RoomId = Guid.NewGuid();
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRoomById), new { id = room.RoomId }, room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoomById(Guid id, Room room)
        {
            if (id != room.RoomId)
                return BadRequest();

            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomById(Guid id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return NotFound();

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}