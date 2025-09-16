using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindResult;

namespace WebAPI.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected IActionResult CreateResponse<T>(Result<T> result)
        {
            return StatusCode(result.StatusCode, result);
        }

        protected IActionResult CreateResponse(Result result)
        {
            return StatusCode(result.StatusCode, result);
        }
        protected IActionResult CreateFileResponse<T>(Result<T> result, string contentType)
        {
            if (!result.IsSuccess)
                return BadRequest(result);

            if (result.Data is not byte[] data)
                return BadRequest(result);

            return File(data, contentType, result.Message);
        }
    }
}
