using PatientAPI.Models;

namespace PatientAPI.Services
{
    public interface IPatientService
    {
        public PatientDataModel GetPatientById(int patientId);
    }
}
