using Sistema_de_Controle_de_Alienígenas.Models;

namespace Sistema_de_Controle_de_Alienígenas.Services.Interfaces
{
    public interface IAlienService
    {
        Task<AlienModel> CadastraAlienComPlaneta();
        Task<AlienModel> AssociarAlienAoPoder();
        Task<AlienModel> GetAlienById(int id);
        Task<PlanetaModel> GetPlanetaByAlienId(int id);
        Task<List<AlienModel>> GetAllAliens();
        Task<AlienModel> DeleteAlienById(int id);
        Task<AlienModel> UpdateAlien(AlienModel alien);
        Task<AlienModel> CreateAlien(PlanetaModel id, AlienModel model, List<PoderModel> poderes);
    }
}
