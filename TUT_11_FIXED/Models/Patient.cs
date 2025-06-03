using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TUT_11_FIXED.Models;

[Table("Patient")]
public class Patient
{
    [Key]
    public int PatientId { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    [Timestamp] // ensures concurrency token [oai_citation:0‡learn.microsoft.com](https://learn.microsoft.com/en-us/ef/core/saving/concurrency#:~:text=%5BTimestamp%5D%20public%20byte%5B%5D%20Version%20,get%3B%20set%3B)
    public byte[] RowVersion { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; }
}