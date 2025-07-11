namespace DiscordApi.Models
{
    public class ChatRoom
    {
        [Key]
        public Guid ChatRoomId { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public List<Room> Rooms { get; set; } = new();
        public List<User> Users { get; set; } = new();
    }
}