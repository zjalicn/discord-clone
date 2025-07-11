namespace DiscordApi.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;
    }
}