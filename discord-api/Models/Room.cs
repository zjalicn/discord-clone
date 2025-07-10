namespace DiscordApi.Models
{
    public class Room
    {
        public string RoomId { get; set; } = string.Empty;
        public string ChatRoomId {get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new();
        public List<Message> Messages { get; set; } = new();
    }
} 