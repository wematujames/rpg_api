
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnet_rpg.v1.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static Character knight = new Character();
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        
        public CharacterService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        private static readonly List<Character> characters = new List<Character>(){
            new Character(),
            new Character {Id = 1, Name = "Sam" },
            new Character {Id = 2, Name = "Doe"},
        };

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetCharacters ()
        {
            
            var serviceRes = new ServiceResponse<List<GetCharacterDTO>>();

            var characters = await _context.Characters.ToListAsync();

            serviceRes.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();

            return serviceRes; 
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacter(int id)
        {
            var serviceRes = new ServiceResponse<GetCharacterDTO>();

            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            
            serviceRes.Data = _mapper.Map<GetCharacterDTO>(character);

            if (character != null) {
                return serviceRes;
            }

            serviceRes.Message = "No character found!";
            serviceRes.Success = false;

            return serviceRes;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> CreateCharacter(CreateCharacterDTO newCharacter)
        {
            var serviceRes =  new ServiceResponse<List<GetCharacterDTO>>();
            var character = _mapper.Map<Character>(newCharacter);

            _context.Characters.Add(character);

            await _context.SaveChangesAsync();

            serviceRes.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();

            return serviceRes;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharater)
        {
            var serviceRes = new ServiceResponse<GetCharacterDTO>();

            try
            {
                var character = _context.Characters.FirstOrDefault(c => c.Id == updatedCharater.Id) ?? throw new Exception("Character not found");
                character.Name = updatedCharater.Name;
                character.HitPoints = updatedCharater.HitPoints;
                character.Strength = updatedCharater.Strength;
                character.Defense = updatedCharater.Defense;
                character.Intelligence = updatedCharater.Intelligence;
                character.Class = updatedCharater.Class;
    
                serviceRes.Data = _mapper.Map<GetCharacterDTO>(character);
                
                await _context.SaveChangesAsync();

                return serviceRes;
            }
            catch (Exception ex)
            {
                serviceRes.Success = false;
                serviceRes.Message = ex.Message ?? "An error occured";
                return serviceRes;
            }
        }

        public async Task<ServiceResponse<GetCharacterDTO>> DeleteCharacter(int id)
        {
            var serviceRes = new ServiceResponse<GetCharacterDTO>();

            try
            {
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
                
                if (character is null) throw new Exception($"Character with id: {id} not found");

                _context.Characters.Remove(character);

                await _context.SaveChangesAsync();
                
                serviceRes.Data = _mapper.Map<GetCharacterDTO>(character);
    
                return serviceRes;
            }
            catch (Exception ex)
            {
                serviceRes.Success = false;
                serviceRes.Message = ex.Message ?? "An error occured";
                return serviceRes;
            }
        }
    }
}