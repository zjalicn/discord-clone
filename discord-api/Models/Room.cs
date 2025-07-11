namespace DiscordApi.Models
{
    public class Room
    {
        [Key]
        public Guid RoomId { get; set; } = Guid.Empty;

        [Required]
        public Guid ChatRoomId { get; set; } = Guid.Empty;

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public ChatRoom ChatRoom {get; set; } = new();
        public List<Message> Messages { get; set; } = new();
    }
}