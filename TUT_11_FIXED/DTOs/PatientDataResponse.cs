using System.Collections.Generic;

namespace TUT_11_FIXED.DTOs;

public class PatientDataResponse
{
    public PatientDto Patient { get; set; }
    public List<PrescriptionDto> Prescriptions { get; set; }
}