using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonnAPI.Controllers
{
    //[ApiVersion("1.0")]
    [Route("/")]
    public class HomeController: Controller
    {
        [HttpGet(Name =nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null),
                da="inside jjbj anonymous",
                rooms = new { href = Url.Link(nameof(RoomsController.GetRooms),null)}
            };

            return Ok(response);

        }
      
    }
}
