using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LandonnAPI.Controllers
{
    [Route("/[controller]")]
    public class RoomsController : Controller
    {
        [HttpGet(Name =nameof(GetRooms))]
        public IActionResult GetRooms()
        {
            throw new Exception();
        }
    }
}