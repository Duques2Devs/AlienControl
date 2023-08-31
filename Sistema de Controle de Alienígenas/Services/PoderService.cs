﻿using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;
using Sistema_de_Controle_de_Alienígenas.Services.Interfaces;
using Sistema_de_Controle_de_Alienígenas.Data;
using Microsoft.EntityFrameworkCore;

namespace Sistema_de_Controle_de_Alienígenas.Services
{
    public class PoderService : IPoderService
    {
        private readonly Context _context;
        public PoderService(Context context)
        {
            _context = context;
        }
        public async Task<List<GetPoderDTO>> GetAllPoder()
        {
            var poderes = await _context.Poderes
                .Include(p => p.AlienPoderes)
                .Select(p => new GetPoderDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Aliens = p.AlienPoderes.Select(ap => ap.Alien).ToList()
                }).ToListAsync();

            return poderes;
        }
        public async Task<GetPoderDTO> GetPoderById(int id)
        {
            var poder = await _context.Poderes
                .Include(p => p.AlienPoderes)
                .Select(p => new GetPoderDTO
                {
                    Id= p.Id,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Aliens = p.AlienPoderes.Select(ap => ap.Alien).ToList()
                }).FirstOrDefaultAsync(p => p.Id == id);

            if (poder == null) return null;

            return poder;
        }
        public async Task<string> CreatePoder(PoderDTO poder)
        {
            var poderModel = new PoderModel { Nome = poder.Nome, Descricao = poder.Descricao };

            _context.Poderes.AddAsync(poderModel);
            await _context.SaveChangesAsync();

            return "Poder cadastrado com sucesso";
        }
        public async Task<string> CreatePoderByAlienId(PoderDTO poder, ICollection<int> aliensId)
        {
            var poderModel = new PoderModel { Nome = poder.Nome, Descricao = poder.Descricao };
            var aliens = await _context.Aliens.FindAsync(aliensId);
            poderModel.AlienPoderes =
                aliensId.Select(id => new AlienPoderModel
                {
                    AlienId = id,
                    PoderId = poderModel.Id
                }).ToList();
            await _context.Poderes.AddAsync(poderModel);
            await _context.SaveChangesAsync();

            return "Poder cadastrado com sucesso";
        }
        public async Task<string> UpdateAlienPoder(int id, ICollection<int> aliensId)
        {
            var poder = await _context.Poderes.FindAsync(id);
            if (poder == null) return "Poder não encontrado";

            var alien = await _context.Aliens.Where(a => aliensId.Contains(a.Id)).ToListAsync();
            if (alien == null) return "Alien não encontrado";

            var poderAliens = poder.AlienPoderes.ToList();
            poderAliens.RemoveAll(a => !aliensId.Contains(a.AlienId));

            poderAliens.AddRange(aliensId.Select(id => new AlienPoderModel
            {
                PoderId = poder.Id,
                AlienId = id
            }));

            poder.AlienPoderes = poderAliens;

            await _context.SaveChangesAsync();

            return "Poder associado com sucesso!";
        }

        public async Task<string> DeletePoder(int id)
        {
            var poder = await _context.Poderes.FindAsync(id);
            if (poder == null) return "Poder não encontrado!";

            _context.Poderes.Remove(poder);
            await _context.SaveChangesAsync();
            return "Poder excluído com sucesso!";
        }
    }
}
