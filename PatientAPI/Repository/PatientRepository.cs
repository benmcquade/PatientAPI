using Newtonsoft.Json;
using PatientAPI.Models;

namespace PatientAPI.Repository
{
    public class PatientRepository : IPatientRepository
    {
        public Patient GetPatientById(int patientId)
        {
            // Normally I would use EF in this scenerio which would allow me to use link to query the database directly.
            // this is much more efficient than getting all patients than narrowing down but as I was told to keep it simple
            // this is what I've gone with.
            var allPatients = GetAllPatients();

            return allPatients.FirstOrDefault(x => x.Id == patientId);
        }

        private List<Patient> GetAllPatients()
        {
            using (StreamReader r = new StreamReader("Data/Patients.json"))
            {
                string json = r.ReadToEnd();

                if (string.IsNullOrEmpty(json))
                {
                    throw new Exception("JSON data is empty or null.");
                }
                else
                {
                    var jets = JsonConvert.DeserializeObject<List<Patient>>(json);

                    if (jets == null)
                    {
                        throw new Exception("Deserialization resulted in null.");
                    }
                    else
                    {
                        return jets;
                    }
                }
            }
        }
    }
}
