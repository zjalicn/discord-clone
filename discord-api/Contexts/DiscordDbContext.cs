using Microsoft.EntityFrameworkCore;
using DiscordApi.Models;

namespace DiscordApi.Contexts
{
    public class DiscordDbContext : DbContext
    {
        public DiscordDbContext(DbContextOptions<DiscordDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<ChatRoom>()
                .HasKey(c => c.ChatRoomId);

            modelBuilder.Entity<Room>()
                .HasKey(r => r.RoomId);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Message>()
                .HasKey(m => m.MessageId);

            // Chatroom <-> Users
            modelBuilder.Entity<ChatRoom>()
                .HasMany(c => c.Users)
                .WithMany(u => u.ChatRooms)

            // ChatRoom <-> Room
            modelBuilder.Entity<Room>()
                .HasOne<ChatRoom>()
                .WithMany(c => c.Rooms)
                .HasForeignKey(r => r.ChatRoomId);

            // Messages <-> Room
            modelBuilder.Entity<Message>()
                .HasOne<Room>()
                .WithMany(r => r.Messages)
                .HasForeignKey(m => m.RoomId);

            // Messages <-> Users
            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserId);
        }
    }
}