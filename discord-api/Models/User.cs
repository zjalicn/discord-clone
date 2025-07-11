namespace DiscordApi.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; } = Guid.Empty;

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        public List<ChatRoom> ChatRooms { get; set; } = new();
    }
}