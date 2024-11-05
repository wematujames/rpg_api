using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace dnet_rpg.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class CharacterController : ControllerBase
    {
        private static Character knight = new Character();
        private static List<Character> characters = new List<Character>(){
            new Character(),
            new Character {Id = 1, Name = "Sam" },
            new Character {Id = 2, Name = "Doe"},
        };

        [HttpGet("characters")]
        public ActionResult<List<Character>> GetCharacters()
        {
            return Ok(characters);
        }

        [HttpGet("character/{id}")]
        public ActionResult<Character> GetCharacter(int id)
        {
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }
    }
}
