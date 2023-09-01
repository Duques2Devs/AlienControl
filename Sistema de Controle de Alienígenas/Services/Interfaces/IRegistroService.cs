using Microsoft.Win32;
using Sistema_de_Controle_de_Alienígenas.Models;

namespace Sistema_de_Controle_de_Alienígenas.Services.Interfaces
{
    public interface IRegistroService 
    {
        Task<IEnumerable<RegistroModel>> GetAllRegistros();
        Task<RegistroModel> GetRegistroById(int id);
        Task CreateRegistroInOut(int id, DateTime data, bool inOut);
        Task UpdateRegistro(int id, RegistroModel registro);
        Task DeleteRegistroInOut(int id);
    }
}
