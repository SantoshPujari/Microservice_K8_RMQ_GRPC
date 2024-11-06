using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
  [ApiController, Route("api/c/[Controller]")]
  public class PlatformsController : ControllerBase
  {
    public PlatformsController()
    {
      
    }
    
    [HttpPost]
    public ActionResult TestInboundConnection()
    {
      System.Console.WriteLine("--> Ibound Post # Command Service");

      return Ok("Inbound test of from platforms controller");
    }
  
  }
}