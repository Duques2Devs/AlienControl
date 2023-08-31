﻿using Microsoft.EntityFrameworkCore;
using Sistema_de_Controle_de_Alienígenas.Data;
using Sistema_de_Controle_de_Alienígenas.Models;
using Sistema_de_Controle_de_Alienígenas.Services.Interfaces;

namespace Sistema_de_Controle_de_Alienígenas.Services
{
    public class AlienService : IAlienService
    {
        private readonly Context _context;
        private IAlienService _alienServiceImplementation;

        public AlienService(Context context) { _context = context; }
        public Task<AlienModel> AssociarAlienAoPoder()
        {
            throw new NotImplementedException();
        }

        public Task<AlienModel> CadastraAlienComPlaneta()
        {
            throw new NotImplementedException();
        }

        public async Task<AlienModel> UpdateAlien(AlienModel alien)
        {
            _context.Entry(alien).State = EntityState.Modified;
            await _context.SaveChangesAsync(); return alien;
        }

        public Task<AlienModel> CreateAlien(PlanetaModel id, AlienModel model, List<PoderModel> poderes)
        {
            throw new NotImplementedException();
        }

        public Task<AlienModel> DeleteAlienById(int id)
        {
            throw new NotImplementedException();
        }

        // Recuperar o Alien com pelo ID 
        public async Task<AlienModel> GetAlienById(int id)
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
        public async Task<PlanetaModel> GetPlanetaByAlienId(int id)
        {
            var alien = await _context.Aliens.FindAsync(id);

            if (alien == null)
            {
                return null; // Ou você pode lançar uma exceção NotFound aqui.
            }

            var planeta = await _context.Planetas.FindAsync(alien.PlanetaID);
            return planeta;
        }


        
        
    }
}
