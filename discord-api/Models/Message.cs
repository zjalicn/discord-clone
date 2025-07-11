namespace DiscordApi.Models
{
    public class Message
    {
        [Key]
        public Guid MessageId { get; set; } = string.Empty;

        [Required]
        public Guid RoomId { get; set; } = string.Empty;

        [Required]
        public Guid UserId { get; set; } = string.Empty;

+       [Required]
+       [MaxLength(2000)]
        public string MessageText { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public User User { get; set; }
        public Room Room { get; set; }
    }
}