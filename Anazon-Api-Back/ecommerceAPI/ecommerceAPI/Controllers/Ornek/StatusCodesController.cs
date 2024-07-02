using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPI.Controllers.Ornek
{
    [ApiController]
    [Route("[controller]")]

    public class StatusCodesController : ControllerBase
    {
        [Route("[action]")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [Route("backend/ok")]
        [HttpGet]
        public IActionResult GetOkFromBackend()
        {
            return StatusCode(StatusCodes.Status200OK); //aynı return Ok(); gibi
        }

        [Route("backend/notFound")]
        [HttpGet]
        public IActionResult GetNotFoundFromBackend()
        {
            return NotFound(); //sayfa veya veri bulunamadı
        }

        [Route("backend/serverError")]
        [HttpGet]
        public IActionResult GetServerErrorFromBackend()
        {
            return StatusCode(StatusCodes.Status500InternalServerError); //sunucuya erişim hatası
        }

        [Route("backend/continue")]
        [HttpGet]
        public IActionResult GetContinueFromBackend()
        {
            return StatusCode(StatusCodes.Status100Continue); //başka adrese yönlendirir
        }
    }
}
