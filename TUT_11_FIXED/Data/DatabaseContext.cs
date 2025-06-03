using System;
using Microsoft.EntityFrameworkCore;
using TUT_11_FIXED.Models;

namespace TUT_11_FIXED.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite key for PrescriptionMedicament
            modelBuilder.Entity<PrescriptionMedicament>()
                .HasKey(pm => new { pm.PrescriptionId, pm.MedicamentId });
            
            modelBuilder.Entity<PrescriptionMedicament>()
                .HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.PrescriptionId);
            
            modelBuilder.Entity<PrescriptionMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(m => m.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.MedicamentId);
            
            // Seed Doctors
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", RowVersion = new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 } },
                new Doctor { DoctorId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", RowVersion = new byte[] { 2, 0, 0, 0, 0, 0, 0, 0 } }
            );
            
            // Seed Patients
            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId = 1, FirstName = "Alice", LastName = "Jones", DateOfBirth = new DateTime(1985, 6, 15), RowVersion = new byte[] { 3, 0, 0, 0, 0, 0, 0, 0 } }
            );
            
            // Seed Medicaments
            modelBuilder.Entity<Medicament>().HasData(
                new Medicament
                {
                    MedicamentId = 1,
                    Name = "Aspirin",
                    Description = "Pain reliever",
                    Type = "Analgesic",
                    RowVersion = new byte[] { 4, 0, 0, 0, 0, 0, 0, 0 }
                },
                new Medicament
                {
                    MedicamentId = 2,
                    Name = "Ibuprofen",
                    Description = "Anti-inflammatory",
                    Type = "Nonsteroidal anti-inflammatory drug (NSAID)",
                    RowVersion = new byte[] { 5, 0, 0, 0, 0, 0, 0, 0 }
                },
                new Medicament
                {
                    MedicamentId = 3,
                    Name = "Paracetamol",
                    Description = "Fever reducer",
                    Type = "Analgesic and antipyretic",
                    RowVersion = new byte[] { 6, 0, 0, 0, 0, 0, 0, 0 }
                }
            );

            // Seed Prescriptions
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { PrescriptionId = 1, Date = new DateTime(2025, 1, 1), DueDate = new DateTime(2025, 1, 10), PatientId = 1, DoctorId = 1, RowVersion = new byte[] { 7, 0, 0, 0, 0, 0, 0, 0 } },
                new Prescription { PrescriptionId = 2, Date = new DateTime(2025, 2, 1), DueDate = new DateTime(2025, 2, 5), PatientId = 1, DoctorId = 2, RowVersion = new byte[] { 8, 0, 0, 0, 0, 0, 0, 0 } }
            );
            
            // Seed PrescriptionMedicaments 
            modelBuilder.Entity<PrescriptionMedicament>().HasData(
                new { PrescriptionId = 1, MedicamentId = 1, Dose = 2, Details = "Take after meals" },
                new { PrescriptionId = 1, MedicamentId = 2, Dose = 1, Details = "Take with water" },
                new { PrescriptionId = 2, MedicamentId = 3, Dose = 5, Details = "Take before sleep" }
            );
        }
    }
}
