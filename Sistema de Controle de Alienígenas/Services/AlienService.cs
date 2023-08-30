using Sistema_de_Controle_de_Alienígenas.Models;
using Sistema_de_Controle_de_Alienígenas.Services.Interfaces;

namespace Sistema_de_Controle_de_Alienígenas.Services
{
    public class AlienService : IAlienService
    {
        public Task<AlienModel> AssociarAlienAoPoder()
        {
            throw new NotImplementedException();
        }

        public Task<AlienModel> CadastraAlienComPlaneta()
        {
            throw new NotImplementedException();
        }

        public Task<AlienModel> CreateAlien(PlanetaModel id, AlienModel model, List<PoderModel> poderes)
        {
            throw new NotImplementedException();
        }

        public Task<AlienModel> DeleteAlienById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AlienModel> GetAlienById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AlienModel> GetAllAliens()
        {
            throw new NotImplementedException();
        }

        public Task<AlienModel> GetPlanetaByAlienId(int id, PlanetaModel planeta)
        {
            throw new NotImplementedException();
        }

        public Task<AlienModel> UpdateAlien()
        {
            throw new NotImplementedException();
        }
    }
}
