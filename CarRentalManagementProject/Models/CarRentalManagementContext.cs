using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementProject.Models;

public partial class CarRentalManagementContext : DbContext
{
    public CarRentalManagementContext()
    {
    }

    public CarRentalManagementContext(DbContextOptions<CarRentalManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Cars19118070> Cars19118070s { get; set; }

    public virtual DbSet<Customers19118070> Customers19118070s { get; set; }

    public virtual DbSet<Log19118070> Log19118070s { get; set; }

    public virtual DbSet<RentedCars19118070> RentedCars19118070s { get; set; }

    public virtual DbSet<Staff19118070> Staff19118070s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= (localdb)\\MSSQLLocalDB; Database=CarRentalManagement;Encrypt=false;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Cars19118070>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Cars_191__68A0342E63845FA2");

            entity.ToTable("Cars_19118070", "19118070", tb =>
                {
                    tb.HasTrigger("TR_Cars_19118070_LastModified_19118070");
                    tb.HasTrigger("insert_cars_trigger");
                    tb.HasTrigger("update_cars_trigger");
                });

            entity.Property(e => e.CarColor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CarMake)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CarModel)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastModified19118070)
                .HasColumnType("datetime")
                .HasColumnName("LastModified_19118070");
        });

        modelBuilder.Entity<Customers19118070>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D82E7EC300");

            entity.ToTable("Customers_19118070", "19118070", tb =>
                {
                    tb.HasTrigger("TR_Customers_19118070_LastModified_19118070");
                    tb.HasTrigger("insert_customers_trigger");
                    tb.HasTrigger("update_customers_trigger");
                });

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastModified19118070)
                .HasColumnType("datetime")
                .HasColumnName("LastModified_19118070");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.RentedCar).WithMany(p => p.Customers19118070s)
                .HasForeignKey(d => d.RentedCarId)
                .HasConstraintName("FK__Customers__Rente__3E52440B");
        });

        modelBuilder.Entity<Log19118070>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__log_1911__3213E83FD79D90D5");

            entity.ToTable("log_19118070", "19118070");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("date_time");
            entity.Property(e => e.OperationType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("operation_type");
            entity.Property(e => e.TableName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("table_name");
        });

        modelBuilder.Entity<RentedCars19118070>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__RentedCa__97005943C6D71AC9");

            entity.ToTable("RentedCars_19118070", "19118070", tb =>
                {
                    tb.HasTrigger("TR_RentedCars_19118070_LastModified_19118070");
                    tb.HasTrigger("insert_rented_cars_trigger");
                    tb.HasTrigger("update_rented_cars_trigger");
                });

            entity.Property(e => e.LastModified19118070)
                .HasColumnType("datetime")
                .HasColumnName("LastModified_19118070");
            entity.Property(e => e.RentalDate).HasColumnType("date");
            entity.Property(e => e.ReturnDate).HasColumnType("date");

            entity.HasOne(d => d.Car).WithMany(p => p.RentedCars19118070s)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__RentedCar__CarId__3F466844");

            entity.HasOne(d => d.Customer).WithMany(p => p.RentedCars19118070s)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__RentedCar__Custo__403A8C7D");
        });

        modelBuilder.Entity<Staff19118070>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff_19__96D4AB17F91B72CE");

            entity.ToTable("Staff_19118070", "19118070", tb =>
                {
                    tb.HasTrigger("TR_Staff_19118070_LastModified_19118070");
                    tb.HasTrigger("insert_staff_trigger");
                    tb.HasTrigger("update_staff_trigger");
                });

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastModified19118070)
                .HasColumnType("datetime")
                .HasColumnName("LastModified_19118070");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MaintainingVehicle).WithMany(p => p.Staff19118070s)
                .HasForeignKey(d => d.MaintainingVehicleId)
                .HasConstraintName("FK__Staff_191__Maint__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
