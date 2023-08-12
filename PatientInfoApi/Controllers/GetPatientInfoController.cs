using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace PatientInfoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetPatientInfoController : ControllerBase
    {
        private readonly XElement _xmlData;

        public GetPatientInfoController()
        {
            var dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "patients.xml");
            _xmlData = XElement.Load(dataPath);
        }

        [HttpPost("GetPatientById")]
        public ActionResult<ServiceResponse> GetPatientById(MyApiRequestParameters parameters)
        {

            var patientId = parameters.PatientId;
            var patient = _xmlData.Elements("Patient")
                                 .FirstOrDefault(p => (long)p.Element("PatientId") == patientId);

            if (patient == null)
            {
                return NotFound(new ServiceResponse
                {
                    StatusCode = 404,
                    StatusDescription = "Patient not found"
                });
            }

            return Ok(new ServiceResponse
            {
                StatusCode = 200,
                StatusDescription = "Success",
                Patient = new Patient
                {
                    PatientId = (long)patient.Element("PatientId"),
                    FirstName = (string)patient.Element("FirstName"),
                    LastName = (string)patient.Element("LastName")
                }
            });
        }
    }
}
