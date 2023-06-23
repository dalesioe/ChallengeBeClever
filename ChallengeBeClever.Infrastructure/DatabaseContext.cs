using ChallengeBeClever.Domain.Entities.Auth;
using ChallengeBeClever.Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;

namespace ChallengeBeClever.Infrastructure
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users>? Users { get; set; }
        public virtual DbSet<Payments>? Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.ToTable("Users");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.DisplayName).HasMaxLength(60);
                entity.Property(e => e.UserName).HasMaxLength(30);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(20);
                entity.Property(e => e.CreatedDate);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Payments");
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeId").IsRequired();
                entity.Property(e => e.Date).HasColumnName("Date").IsRequired();
                entity.Property(e => e.RegisterType).HasColumnName("RegisterType").IsRequired();
                entity.Property(e => e.BusinessLocation).HasColumnName("BusinessLocation").IsRequired();
                entity.Property(e => e.Amount).HasColumnName("Amount").IsRequired();
                entity.Property(e => e.IVA).HasColumnName("IVA").IsRequired();
                entity.Property(e => e.Interes).HasColumnName("Interes");
                entity.Property(e => e.Mora).HasColumnName("Mora");

                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.EmployeeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
