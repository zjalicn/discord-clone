namespace DiscordApi.Models
{
    public class ChatRoom
    {
        public string ChatRoomId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<Room> Rooms { get; set; } = new();
        public List<User> Users { get; set; } = new();
    }
} 