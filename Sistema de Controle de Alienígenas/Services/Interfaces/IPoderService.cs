using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;

namespace Sistema_de_Controle_de_Alienígenas.Services.Interfaces
{
    public interface IPoderService
    {
        Task<List<GetPoderDTO>> GetAllPoder();//ok**
        Task<GetPoderDTO> GetPoderById(int id);//ok**
        Task<string> CreatePoder(PoderDTO poder);//ok**
        Task<string> CreatePoderByAlienId(PoderDTO poder, ICollection<int> aliensId);//ok**
        Task<string> UpdateAlienPoder(int id, ICollection<int> aliensId);//ok**
        Task<string> DeletePoder(int id);//ok**
        
    }
}
