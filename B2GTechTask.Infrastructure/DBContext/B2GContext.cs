using Microsoft.EntityFrameworkCore;

namespace B2GTechTask.Infrastructure.DBContext
{
    public partial class B2GContext : DbContext
    {
        public B2GContext()
        {
        }

        public B2GContext(DbContextOptions<B2GContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeAddress> EmployeeAddresses { get; set; } = null!;
        public virtual DbSet<EmployeePhone> EmployeePhones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Employee");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EmployeeAddress");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeAddressId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EmployeeAddressID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeePhone>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EmployeePhone");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeePhoneId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EmployeePhoneID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneArea)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneExt)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
