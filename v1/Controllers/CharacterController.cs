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
        public async Task<ActionResult<List<Character>>> GetCharacters()
        {
            return Ok(await _characterService.GetCharacters());
        }

        [HttpGet("character/{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            return Ok(await _characterService.GetCharacter(id));
        }

        [HttpPost("characters")]
        public async Task<ActionResult<List<Character>>> CreateCharacter (Character newCharacter) {
            characters.Add(newCharacter);

            return Ok(await _characterService.CreateCharacter(newCharacter));
        }
    }
}
