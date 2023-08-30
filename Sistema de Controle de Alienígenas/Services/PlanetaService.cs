using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Sistema_de_Controle_de_Alienígenas.Data;
using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;
using Sistema_de_Controle_de_Alienígenas.Services.Interfaces;
using System.Numerics;

namespace Sistema_de_Controle_de_Alienígenas.Services
{
    public class PlanetaService : IPlanetaService
    {
        private readonly Context _con;

        public PlanetaService(Context con)
        {
            _con = con;
        }
        public async Task CreatePlanetaSemHabitantes(DTOPlaneta model)
        {
            var Planeta = new PlanetaModel { Nome = model.Nome, Descricao = model.Descricao , Populacao = model.Populacao};
            _con.Planetas.Add(Planeta);
            await _con.SaveChangesAsync();
        }

        public async Task<List<AlienModel>> GetHabitantesPlanetas(int Id)
        {
            var planeta = await _con.Planetas
                .Include(p => p.Habitantes)
                .FirstOrDefaultAsync(p => p.Id == Id);

            return planeta != null ? planeta.Habitantes : null;
        }

        public async Task DeletePlaneta(int Id)
        {
            var planeta = await _con.Planetas.FindAsync(Id);
            if (planeta == null) return;

            _con.Planetas.Remove(planeta);
            await _con.SaveChangesAsync();
        }

        public async Task<IEnumerable<PlanetaModel>> GetPlanetas()
        {
            return await _con.Planetas.ToListAsync();
        }

        public async Task<PlanetaModel> GetPlanetaById(int Id)
        {
            return await _con.Planetas.FindAsync(Id);
        }

        public async Task UpdatePlaneta(int Id, DTOPlaneta model) //
        {
            if (Id != model.Id) throw new ArgumentException("IDs são diferentes!");
            var planeta = await _con.Planetas.FindAsync(Id);
            planeta.Nome = model.Nome;
            planeta.Descricao = model.Descricao;
            await _con.SaveChangesAsync();
        }

       
    }
}
