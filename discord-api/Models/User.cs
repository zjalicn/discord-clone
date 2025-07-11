using System.ComponentModel.DataAnnotations;

namespace DiscordApi.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public List<ChatRoom>? ChatRooms { get; set; }
        public List<Message>? Messages { get; set; }
    }
}