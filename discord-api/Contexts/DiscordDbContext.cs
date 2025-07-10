public class DiscordDbContext: DbContext
{
    public DiscordDbContext(DbContextOptions<DiscordDbContext> options) : base(options) {}

    public DbSet<User> Users {get; set;}
    public DbSet<Message> Messages { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<ChatRoom> ChatRooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>()
            .HasOne<Room>()
            .WithMany(r => r.Messages)
            .HasForeignKey(m => m.RoomId);

        modelBuilder.Entity<Room>()
            .HasOne<ChatRoom>()
            .WithMany(c => c.Rooms)
            .HasForeignKey(r => r.ChatRoomId);
    }
}