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

    [Timestamp] // ensures concurrency token [oai_citation:0‡learn.microsoft.com](https://learn.microsoft.com/en-us/ef/core/saving/concurrency#:~:text=%5BTimestamp%5D%20public%20byte%5B%5D%20Version%20,get%3B%20set%3B)
    public byte[] RowVersion { get; set; }

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}