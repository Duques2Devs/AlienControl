﻿using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;

namespace Sistema_de_Controle_de_Alienígenas.Services.Interfaces
{
    public interface IAlienService
    {
        Task<AlienModel> CadastraAlienComPlaneta(AlienDTO alien);
        Task<AlienPoderModel?> AssociarAlienAoPoder(int alienId, int poderId);
        Task<AlienModel?> GetAlienById(int id);
        Task<PlanetaModel?> GetPlanetaByAlienId(int id);
        Task<List<AlienModel>> GetAllAliens();
        Task<AlienModel?> DeleteAlienById(int id);
        Task<AlienModel> UpdateAlien(AlienPutDTO alien, int Id);
        Task<List<PoderModel>?> GetPoderesByAlienId(int id);
        Task<AlienModel?> GetAlienTudo(int id);
        Task<List<RegistroModel>?> GetAlienRegistros(int id);
    }
}
