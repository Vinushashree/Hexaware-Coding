using Microsoft.EntityFrameworkCore;
using EventManagement.DAL.Entities; // ✅ Add this line

namespace EventManagement.DAL
{
    public class EventDbContext : DbContext
    {
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<EventDetails> Events { get; set; }
        public DbSet<SpeakersDetails> Speakers { get; set; }
        public DbSet<SessionInfo> Sessions { get; set; }
        public DbSet<ParticipantEventDetails> ParticipantEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-D766RJU7;Database=EventDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
