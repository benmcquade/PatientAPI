namespace PatientAPI.Models
{
    public class PatientDataModel
    {
        public bool Success { get; set; }

        public Patient? Patient { get; set; }

        public string? Message { get; set; }
    }
}
