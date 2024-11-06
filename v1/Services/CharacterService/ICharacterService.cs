using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dnet_rpg.v1.DTOs.Character;

namespace dnet_rpg.v1.Services.CharacterService
{
    public interface ICharacterService
    {
       Task<ServiceResponse<List<GetCharacterDTO>>> GetCharacters ();
       Task<ServiceResponse<GetCharacterDTO>> GetCharacter (int id);
       Task<ServiceResponse<List<GetCharacterDTO>>> CreateCharacter (CreateCharacterDTO newCharater); 
       Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter (UpdateCharacterDTO updatedCharater); 
       Task<ServiceResponse<GetCharacterDTO>> DeleteCharacter (int id); 
    }
}