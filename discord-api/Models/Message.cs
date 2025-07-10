namespace DiscordApi.Models
{
    public class Message
    {
        public string RoomId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string MessageText { get; set; } = string.Empty;
        public long Timestamp { get; set; }
    }
} 