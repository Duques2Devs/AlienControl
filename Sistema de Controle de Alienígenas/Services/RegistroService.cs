using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Win32;
using Sistema_de_Controle_de_Alienígenas.Data;
using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;
using Sistema_de_Controle_de_Alienígenas.Services.Interfaces;
using System.Linq;

namespace Sistema_de_Controle_de_Alienígenas.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly Context _dbContext;

        public RegistroService(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RegistroModel>> GetAllRegistros()
        {
            return await _dbContext.Registros.Include(a => a.Alien).ToListAsync();
        }

        public async Task<RegistroModel> GetRegistroById(int id)
        {
            return await _dbContext.Registros.Include(a => a.Alien)
            .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task CreateRegistroInOut(RegistroDTO registro)
        {

            var alien = await _dbContext.Aliens.FindAsync(registro.AlienId);

            if (alien != null)
            {
                if (registro.Entrando == true)
                {//ENTROU
                 //
                    alien.EstaNaTerra = true;
                    _dbContext.Entry(alien).State = EntityState.Modified;

                    var registroModel = new RegistroModel
                    {
                        AlienId = registro.AlienId,
                        DataEntrada = registro.Data
                    };
                    _dbContext.Registros.Add(registroModel);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {//SAIU
                    alien.EstaNaTerra = false;
                    _dbContext.Entry(alien).State = EntityState.Modified;

                    var lista = await _dbContext.Registros.Where(r => r.AlienId == registro.AlienId).ToListAsync();
                    var registroAlien = lista[lista.Count - 1];

                    registroAlien.DataSaida = registro.Data;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateRegistro(int id, UpdateRegistroDTO registro)
        {
            if (id != registro.Id)
            {
                throw new ArgumentException("IDs não correspondem.");
            }

            var registroAlien = await GetRegistroById(id);

            registroAlien.AlienId = registro.AlienId;
            registroAlien.DataEntrada = registro.DataEntrada;
            registroAlien.DataSaida = registro.DataSaida;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRegistroInOut(int id)
        {
            var registro = await _dbContext.Registros.FindAsync(id);
            if (registro == null) return;

            _dbContext.Registros.Remove(registro);
            await _dbContext.SaveChangesAsync();
        }
    }
}
