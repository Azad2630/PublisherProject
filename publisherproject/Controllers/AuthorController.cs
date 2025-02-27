using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace publisherproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [HttpGet]
        public string get()
        {
            return "yeah";
        }
    }
}
