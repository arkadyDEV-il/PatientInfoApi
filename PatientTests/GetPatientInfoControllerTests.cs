using Microsoft.AspNetCore.Mvc;
using PatientInfoApi;
using PatientInfoApi.Controllers;

namespace PatientTests
{
    [TestFixture]
    public class GetPatientInfoControllerTests
    {
        [Test]
        public void GetPatientById_PatientFound_ReturnsOk()
        {
            var controller = new GetPatientInfoController();
            var parameters = new MyApiRequestParameters { PatientId = 1 };

            var result = controller.GetPatientById(parameters);

            //Assert.IsInstanceOf<ActionResult<ServiceResponse>>(result);

            Assert.IsTrue(result.Result is OkObjectResult);
        }

        [Test]
        public void GetPatientById_PatientNotFound_ReturnsNotFound()
        {
            var controller = new GetPatientInfoController();
            var parameters = new MyApiRequestParameters { PatientId = 999 };

            var result = controller.GetPatientById(parameters);

            Assert.IsTrue(result.Result is NotFoundObjectResult);

            //Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }
    }
}