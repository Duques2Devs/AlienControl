using Microsoft.Win32;
using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;

namespace Sistema_de_Controle_de_Alienígenas.Services.Interfaces
{
    public interface IRegistroService 
    {
        Task<IEnumerable<RegistroModel>> GetAllRegistros();
        Task<RegistroModel> GetRegistroById(int id);
        Task CreateRegistroInOut(RegistroDTO registro);
        Task UpdateRegistro(int id, UpdateRegistroDTO registro);
        Task DeleteRegistroInOut(int id);
    }
}
