using Sistema_de_Controle_de_Alienígenas.DTO;
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


            foreach(var alienId in aliensId)
            {
                var alien = await _context.Aliens.FindAsync(alienId);

                if (alien == null) return "AlienID não encontrado";

                var alienPoder = new AlienPoderModel { AlienId = alienId, PoderId = poderModel.Id , Alien = alien, Poder = poderModel};

                _context.AlienPoder.Add(alienPoder);

                alien.AlienPoderes.Add(alienPoder);

            }

            
            await _context.Poderes.AddAsync(poderModel);
            await _context.SaveChangesAsync();

            return "Poder cadastrado com sucesso";
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
