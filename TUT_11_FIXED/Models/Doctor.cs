using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TUT_11_FIXED.Models;

[Table("Doctor")]
public class Doctor
{
    [Key]
    public int DoctorId { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }

    [Timestamp] 
    public byte[] RowVersion { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
}