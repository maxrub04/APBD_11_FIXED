using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TUT_11_FIXED.Models;

[Table("Medicament")]
public class Medicament
{
    [Key]
    public int MedicamentId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Description { get; set; }
    [MaxLength(100)]
    public string Type { get; set; }
    [Timestamp] 
    public byte[] RowVersion { get; set; }

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}