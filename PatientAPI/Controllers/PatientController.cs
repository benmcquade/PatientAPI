using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientAPI.Repository;
using PatientAPI.Services;
using System.Diagnostics.CodeAnalysis;

namespace PatientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult Patient([FromQuery] int patientId)
        {
            if (!IsValidPatientId(patientId))
                return BadRequest("Invalid patient ID.");

            var patient = _patientService.GetPatientById(patientId);

            if (!patient.Success)
                return NotFound(patient.Message);
            else
                return Ok(patient.Patient);
        }

        private bool IsValidPatientId(int patientId)
        {
            return patientId > 0;
        }
    }
}
