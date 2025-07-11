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

        public string MessageText { get; set; } = string.Empty;

        public long Timestamp { get; set; }
    }
}