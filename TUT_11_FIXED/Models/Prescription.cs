using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TUT_11_FIXED.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    public int PrescriptionId { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }
    
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    
    [Timestamp] 
    public byte[] RowVersion { get; set; }
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}