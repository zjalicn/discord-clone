namespace DiscordApi.Models
{
    public class Room
    {
        [Key]
        public Guid RoomId { get; set; }

        [Required]
        public Guid ChatRoomId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ChatRoom? ChatRoom {get; set; }
        public List<Message>? Messages { get; set; }
    }
}