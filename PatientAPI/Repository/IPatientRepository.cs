using PatientAPI.Models;

namespace PatientAPI.Repository
{
    public interface IPatientRepository
    {
        public Patient GetPatientById(int patientId);
    }
}