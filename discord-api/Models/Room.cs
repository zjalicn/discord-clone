namespace DiscordApi.Models
{
    public class Room
    {
        [Key]
        public Guid RoomId { get; set; } = string.Empty;

        [Required]
        public Guid ChatRoomId { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public List<User> Users { get; set; } = new();

        public List<Message> Messages { get; set; } = new();
    }
}