using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace dnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static Character knight = new Character();

        [HttpGet(Name = "character")]
        public ActionResult<Character> Get () {
            return Ok(knight);
        }
    }
}