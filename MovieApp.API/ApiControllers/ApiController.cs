using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.API.ApiControllers
{
    //[Route(template:"api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
    }
}
