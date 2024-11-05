using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dnet_rpg.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace dnet_rpg.v1.Controllers
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
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpGet("characters")]
        public ActionResult<List<Character>> GetCharacters()
        {
            return Ok(_characterService.GetCharacters());
        }

        [HttpGet("character/{id}")]
        public ActionResult<Character> GetCharacter(int id)
        {
            return Ok(_characterService.GetCharacter(id));
        }

        [HttpPost("characters")]
        public ActionResult<List<Character>> CreateCharacter (Character newCharacter) {
            characters.Add(newCharacter);

            return Ok(_characterService.CreateCharacter(newCharacter));
        }
    }
}
