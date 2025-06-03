using TUT_11_FIXED.DTOs;

namespace TUT_11_FIXED.Services;

public interface IDbService
{
    Task AddPrescriptionAsync(AddPrescriptionRequest request);
    Task<PatientDataResponse?> GetPatientDetailsAsync(int patientId);
}