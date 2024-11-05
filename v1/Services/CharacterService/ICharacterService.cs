using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnet_rpg.v1.Services.CharacterService
{
    public interface ICharacterService
    {
       Task<ServiceResponse<List<Character>>> GetCharacters ();
       
       Task<ServiceResponse<Character>> GetCharacter (int id);

       Task<ServiceResponse<List<Character>>> CreateCharacter (Character newCharater); 
    }
}