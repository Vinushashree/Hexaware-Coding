using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models; // ✅ This is the key fix

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<EventDetails> EventDetails { get; set; }
    public DbSet<SpeakersDetails> SpeakersDetails { get; set; }
    public DbSet<SessionInfo> SessionInfos { get; set; }
    public DbSet<ParticipantEventDetails> ParticipantEventDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventDetails>()
            .HasCheckConstraint("CK_Status", "[Status] IN ('Active', 'In-Active')");

        modelBuilder.Entity<ParticipantEventDetails>()
            .HasCheckConstraint("CK_IsAttended", "[IsAttended] IN ('Yes', 'No')");
    }
}


