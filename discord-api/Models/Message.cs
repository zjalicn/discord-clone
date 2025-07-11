using System.ComponentModel.DataAnnotations;

namespace DiscordApi.Models
{
    public class Message
    {
        [Key]
        public Guid MessageId { get; set; }

        [Required]
        public Guid RoomId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(2000)]
        public string MessageText { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public User? User { get; set; }
        public Room? Room { get; set; }
    }
}