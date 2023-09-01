using Microsoft.EntityFrameworkCore;
using Sistema_de_Controle_de_Alienígenas.Data;
using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;
using Sistema_de_Controle_de_Alienígenas.Services.Interfaces;

namespace Sistema_de_Controle_de_Alienígenas.Services
{
    public class AlienService : IAlienService
    {
        private readonly Context _context;

        public AlienService(Context context)
        {
            _context = context;
        }

        public async Task<AlienModel> UpdateAlien(AlienModel alien)
        {
            _context.Entry(alien).State = EntityState.Modified;
            await _context.SaveChangesAsync(); return alien;
        }

        // Recuperar o Alien com pelo ID 
        public async Task<AlienModel?> GetAlienById(int id)
        {
            var alien = await _context.Aliens.FindAsync(id);
            return alien;
        }

        // Recuperar todos os Aliens
        public async Task<List<AlienModel>> GetAllAliens()
        {
            var aliens = await _context.Aliens.ToListAsync();
            return aliens;
        }

        // Recuperar os planetas associados ao Alien
        public async Task<PlanetaModel?> GetPlanetaByAlienId(int id)
        {
            var alien = await _context.Aliens.FindAsync(id);

            if (alien == null)
            {
                return null; // Ou você pode lançar uma exceção NotFound aqui.
            }

            var planeta = await _context.Planetas.FindAsync(alien.PlanetaID);
            return planeta;
        }

        public async Task<AlienPoderModel?> AssociarAlienAoPoder(int alienId, int poderId)
        {
            var poder = await _context.Poderes.FirstOrDefaultAsync(p => p.Id == poderId);
            if (poder == null)
            {
                return null;
            }

            var alien = await _context.Aliens.FirstOrDefaultAsync(a => a.Id == alienId);
            if (alien == null)
            {
                return null;
            }

            var alienPoder = new AlienPoderModel
            {
                AlienId = alienId,
                PoderId = poderId
            };

            _context.AlienPoder.Add(alienPoder);
            await _context.SaveChangesAsync();

            return alienPoder;
        }

        public async Task<AlienModel> CadastraAlienComPlaneta(AlienDTO alien)
        {
            var alienModel = new AlienModel
            {
                Nome = alien.Nome,
                Altura = alien.Altura,
                Idade = alien.Idade,
                Corpo = alien.Corpo,
                PlanetaID = alien.PlanetaID
            };

            _context.Aliens.Add(alienModel);
            await _context.SaveChangesAsync();
            return alienModel;
        }

        public async Task<AlienModel?> DeleteAlienById(int id)
        {
            var alien = await _context.Aliens.FirstOrDefaultAsync(a => a.Id == id);
            if (alien == null)
            {
                return null;
            }

            _context.Aliens.Remove(alien);
            await _context.SaveChangesAsync();
            return alien;
        }
    }
}
