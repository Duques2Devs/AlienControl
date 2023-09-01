using Sistema_de_Controle_de_Alienígenas.Data;
using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;

namespace Sistema_de_Controle_de_Alienígenas.Services.Interfaces
{
    public interface IPlanetaService
    {
        Task<IEnumerable<PlanetaModel>> GetPlanetas();
        Task<PlanetaModel> GetPlanetaById(int Id);
        Task CreatePlanetaSemHabitantes(DTOPlaneta model);
        Task<List<AlienModel>> GetHabitantesPlanetas(int Id);

        Task DeletePlaneta(int Id);
        Task UpdatePlaneta(int Id, DTOPlaneta model);

    }
}
