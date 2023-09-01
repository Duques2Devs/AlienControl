using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Win32;
using Sistema_de_Controle_de_Alienígenas.Data;
using Sistema_de_Controle_de_Alienígenas.Models;
using Sistema_de_Controle_de_Alienígenas.Services.Interfaces;

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

        public async Task CreateRegistroInOut(int id, DateTime data, bool inOut)
        {
            var alien = await _dbContext.Aliens.FindAsync(id);

            if (alien != null)
            {
                var registroModel = new RegistroModel
                {
                    AlienId = id,
                    DataRegistro = data
                };

                if (inOut)
                {
                    alien.EstaNaTerra = true;
                    registroModel.TipoRegistro = TipoRegistro.Entrada; // Ou algum outro valor que represente entrada.
                }
                else
                {
                    alien.EstaNaTerra = false;
                    registroModel.TipoRegistro = TipoRegistro.Saida; // Ou algum outro valor que represente saída.
                }

                _dbContext.Registros.Add(registroModel);
                await _dbContext.SaveChangesAsync();
            }

            /*
            var alien = _dbContext.Aliens.FindAsync(id);

            if (alien != null)
            {
                if (inOut == true)
                {//ENTROU        

                    alien.EstaNaTerra = true;
                    var registroModel = new RegistroModel
                    {
                        AlienId = id,
                        DataEntrada = data
                    };

                }
                else
                {//SAIU
                    var registroModel = new RegistroModel
                    {
                        AlienId = id,
                        DataSaida = data
                    };
                    
                }
                _dbContext.Registros.Add(registroModel);
                await _dbContext.SaveChangesAsync();
            }*/

        }

        public async Task UpdateRegistro(int id, RegistroModel registro)
        {
            if (id != registro.Id)
            {
                throw new ArgumentException("IDs não correspondem.");
            }

            _dbContext.Entry(registro).State = EntityState.Modified;
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
