using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace UsersGroups.Web.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Attendee> Attendees { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<Prize> Prizes { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<Speaker> Speakers { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<Winner> Winners { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Detail>(entity =>
            {
                entity.HasOne(d => d.Question).WithMany(p => p.Details).HasForeignKey(d => d.QuestionId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.Response).WithMany(p => p.Details).HasForeignKey(d => d.ResponseId);
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.Property(e => e.Topic).IsRequired();
                entity.HasOne(d => d.Speaker).WithMany(p => p.Meetings).HasForeignKey(d => d.SpeakerId);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasOne(d => d.Survey).WithMany(p => p.Questions).HasForeignKey(d => d.SurveyId);
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.HasOne(d => d.Attendee).WithMany(p => p.Responses).HasForeignKey(d => d.AttendeeId);
                entity.HasOne(d => d.Survey).WithMany(p => p.Responses).HasForeignKey(d => d.SurveyId);
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.HasOne(d => d.Meeting).WithMany(p => p.Surveys).HasForeignKey(d => d.MeetingId);
            });

            modelBuilder.Entity<Winner>(entity =>
            {
                entity.HasOne(d => d.Attendee).WithMany(p => p.Winners).HasForeignKey(d => d.AttendeeId);
                entity.HasOne(d => d.Meeting).WithMany(p => p.Winners).HasForeignKey(d => d.MeetingId);
                entity.HasOne(d => d.Prize).WithMany(p => p.Winners).HasForeignKey(d => d.PrizeId);
            });
        }
    }
}
