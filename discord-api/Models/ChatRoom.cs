using System.ComponentModel.DataAnnotations;

namespace DiscordApi.Models
{
    public class ChatRoom
    {
        [Key]
        public Guid ChatRoomId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public List<Room>? Rooms { get; set; }
        public List<User>? Users { get; set; }
    }
}