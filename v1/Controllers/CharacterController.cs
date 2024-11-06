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
        
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpGet("characters")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> GetCharacters()
        {
            return Ok(await _characterService.GetCharacters());
        }

        [HttpGet("character/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetCharacter(int id)
        {
            return Ok(await _characterService.GetCharacter(id));
        }

        [HttpPost("characters")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> CreateCharacter (CreateCharacterDTO newCharacter) {
            return Ok(await _characterService.CreateCharacter(newCharacter));
        }

        [HttpPut("characters")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> UpdateCharacter (UpdateCharacterDTO updatedCharacter) {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            
            if (response.Data is null) return NotFound();

            return Ok(response);
        }
    }
}
