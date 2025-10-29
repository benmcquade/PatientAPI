using Microsoft.AspNetCore.Mvc;
using Moq;
using PatientAPI.Controllers;
using PatientAPI.Models;
using PatientAPI.Repository;
using PatientAPI.Services;

namespace PatientAPITests.Controllers
{
    public class PatientControllerTests
    {
        private readonly Mock<IPatientRepository> _patientRepository;
        private readonly PatientService _patientService;
        private readonly PatientController controller;

        public PatientControllerTests()
        {
            _patientRepository = new Mock<IPatientRepository>();
            _patientService = new PatientService(_patientRepository.Object);
            controller = new PatientController(_patientService);
        }


        [Fact]
        public void Get_ReturnsPatient()
        {
            // Arrange
            SetupRepositoryMock();

            //Act
            var patient = controller.Patient(1) as OkObjectResult;

            //Assert
            Assert.NotNull(patient.Value);
        }

        [Fact]
        public void Get_ReturnsNotFound_WhenPatientDoesNotExist()
        {
            // Arrange
            _patientRepository.Setup(pr => pr.GetPatientById(It.IsAny<int>())).Returns((Patient)null);

            //Act
            var result = controller.Patient(999);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void Get_ReturnsHelpfulMessage_WhenPatientDoesNotExist()
        {
            // Arrange
            _patientRepository.Setup(pr => pr.GetPatientById(It.IsAny<int>())).Returns((Patient)null);

            //Act
            var result = controller.Patient(999) as NotFoundObjectResult;

            //Assert
            Assert.Equal("Patient not found", result.Value);
        }

        [Fact]
        public void Get_ReturnsBadRequest_WhenIdIsInvalid()
        {
            // Act
            var result = controller.Patient(-1);
            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        private void SetupRepositoryMock(List<Patient>? jets = null)
        {
            _patientRepository.Setup(pr => pr.GetPatientById(It.IsAny<int>())).Returns(
                new Patient
                {
                    Id = 1,
                    NHSNumber = "1234567890",
                    Name = "John Doe",
                    DateOfBirth = new DateTime(1980, 1, 1),
                    GPPractice = "Practice A"
                });
        }
    }
}
