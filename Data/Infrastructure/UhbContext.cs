using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UHB.Features.ApplicationManagement.Models;
using UHB.Features.AuthenticationManagement.Models;
using UHB.Features.HostelManagement.Models;
using UHB.Features.StudentManagement.Models;

namespace UHB.Data.Infrastructure;

public partial class UhbContext : IdentityDbContext<User>
{
    private readonly string _connectionString;
    public UhbContext()
    {
    }

    public UhbContext(DbContextOptions<UhbContext> options, IConfiguration configuration)
        : base(options)
    {
        //_connectionString = configuration.GetConnectionString("UHB");
        _connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__UHBRemote");
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Hostel> Hostels { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(iul => new { iul.LoginProvider, iul.ProviderKey });
        modelBuilder.Entity<IdentityUserRole<string>>().HasKey(iur => new { iur.UserId, iur.RoleId });
        modelBuilder.Entity<IdentityUserToken<string>>().HasKey(iut => new { iut.UserId, iut.LoginProvider, iut.Name });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationNo).HasName("PRIMARY");

            entity.ToTable("applications");

            entity.HasIndex(e => e.RegistrationNo, "RegistrationNo");

            entity.HasIndex(e => e.RoomNo, "RoomNo");

            entity.Property(e => e.AccommodatedBefore).HasMaxLength(4);
            entity.Property(e => e.AccommodationPeriod).HasMaxLength(30);
            entity.Property(e => e.ApplicationPeriod).HasMaxLength(30);
            entity.Property(e => e.BursaryAmount).HasMaxLength(15);
            entity.Property(e => e.Disability).HasMaxLength(30);
            entity.Property(e => e.DisabilityDetails).HasMaxLength(30);
            entity.Property(e => e.HelbAmount).HasMaxLength(15);
            entity.Property(e => e.IsSponsored).HasMaxLength(4);
            entity.Property(e => e.PreferredHostel).HasMaxLength(30);
            entity.Property(e => e.ReasonsForConsideration).HasMaxLength(50);
            entity.Property(e => e.ReceivedBursary).HasMaxLength(4);
            entity.Property(e => e.ReceivesHelb).HasMaxLength(4);
            entity.Property(e => e.RegistrationNo).HasMaxLength(30);
            entity.Property(e => e.RoomNo).HasMaxLength(30);
            entity.Property(e => e.SpecialExamPeriod).HasMaxLength(10);
            entity.Property(e => e.SpecialExamsOnFinancialGrounds).HasMaxLength(4);
            entity.Property(e => e.Sponsor).HasMaxLength(30);
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Pending'");
            entity.Property(e => e.WorkStudyBenefitsBefore).HasMaxLength(4);
            entity.Property(e => e.WorkStudyPeriod).HasMaxLength(10);

            entity.HasOne(d => d.RegistrationNoNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.RegistrationNo)
                .HasConstraintName("applications_ibfk_1");

            entity.HasOne(d => d.RoomNoNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.RoomNo)
                .HasConstraintName("applications_ibfk_2");
        });

        modelBuilder.Entity<Hostel>(entity =>
        {
            entity.HasKey(e => e.HostelNo).HasName("PRIMARY");

            entity.ToTable("hostels");

            entity.Property(e => e.HostelNo).HasMaxLength(30);
            entity.Property(e => e.Capacity).HasMaxLength(10);
            entity.Property(e => e.HostelName).HasMaxLength(30);
            entity.Property(e => e.Type).HasMaxLength(15);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomNo).HasName("PRIMARY");

            entity.ToTable("rooms");

            entity.HasIndex(e => e.HostelNo, "HostelNo");

            entity.Property(e => e.RoomNo).HasMaxLength(30);
            entity.Property(e => e.HostelNo).HasMaxLength(30);

            entity.HasOne(d => d.HostelNoNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HostelNo)
                .HasConstraintName("rooms_ibfk_1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.RegNo).HasName("PRIMARY");

            entity.ToTable("students");

            entity.Property(e => e.RegNo)
                .HasMaxLength(30)
                .HasColumnName("RegNO");
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.SecondName).HasMaxLength(30);
            entity.Property(e => e.Surname).HasMaxLength(30);
        });

        modelBuilder.Entity<User>()
            .Property(u => u.RegNo).HasColumnType("varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci");

        modelBuilder.Entity<User>()
                    .HasOne(u => u.RegNoNavigation)
                    .WithMany(s => s.Users)
                    .HasForeignKey(u => u.RegNo)
                    .HasPrincipalKey(s => s.RegNo);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
