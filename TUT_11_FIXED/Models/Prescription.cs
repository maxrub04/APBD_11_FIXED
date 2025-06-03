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
    
    [Timestamp] // ensures concurrency token [oai_citation:0‡learn.microsoft.com](https://learn.microsoft.com/en-us/ef/core/saving/concurrency#:~:text=%5BTimestamp%5D%20public%20byte%5B%5D%20Version%20,get%3B%20set%3B)
    public byte[] RowVersion { get; set; }
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}