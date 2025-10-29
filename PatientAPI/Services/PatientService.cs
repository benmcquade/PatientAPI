using PatientAPI.Models;
using PatientAPI.Repository;

namespace PatientAPI.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public PatientDataModel GetPatientById(int patientId)
        {
            var patientData = _patientRepository.GetPatientById(patientId);

            if (patientData == null)
                return new PatientDataModel
                {
                    Success = false,
                    Patient = null,
                    Message = "Patient not found"
                };
            else
                return new PatientDataModel
                {
                    Success = true,
                    Patient = patientData,
                    Message = "Patient found"
                };
        }
    }
}
