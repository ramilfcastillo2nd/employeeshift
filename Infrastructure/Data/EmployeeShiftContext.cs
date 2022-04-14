using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class EmployeeShiftContext: DbContext
    {
        public EmployeeShiftContext(DbContextOptions<EmployeeShiftContext> options): base(options)
        {

        }
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeWorksShift> EmployeeWorksShifts { get; set; } = null!;
        public virtual DbSet<Shift> Shifts { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeWorksShift>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Employee_Works_Shift");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.ShiftId).HasColumnName("Shift_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Works_Shift_Employee");

                entity.HasOne(d => d.Shift)
                    .WithMany()
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Works_Shift_Shifts");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.Property(e => e.ShiftId).HasColumnName("Shift_ID");

                entity.Property(e => e.ShiftEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("Shift_End");

                entity.Property(e => e.ShiftName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Shift_Name");

                entity.Property(e => e.ShiftStart)
                    .HasColumnType("datetime")
                    .HasColumnName("Shift_Start");
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
