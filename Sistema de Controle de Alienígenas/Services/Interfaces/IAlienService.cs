using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;

namespace Sistema_de_Controle_de_Alienígenas.Services.Interfaces
{
    public interface IAlienService
    {
        Task<AlienModel> CadastraAlienComPlaneta(AlienDTO alien);
        Task<AlienModel?> AssociarAlienAoPoder(int alienId, int poderId);
        Task<AlienModel> GetAlienById(int id);
        Task<AlienModel> GetPlanetaByAlienId(int id, PlanetaModel planeta);
        Task<AlienModel> GetAllAliens();
        Task<AlienModel?> DeleteAlienById(int id);
        Task<AlienModel> UpdateAlien();
        //Task<AlienModel> CreateAlien(PlanetaModel id, AlienModel model, List<PoderModel> poderes);
    }
}
