using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Win32;
using Sistema_de_Controle_de_Alienígenas.Data;
using Sistema_de_Controle_de_Alienígenas.DTO;
using Sistema_de_Controle_de_Alienígenas.Models;
using Sistema_de_Controle_de_Alienígenas.Services.Interfaces;
using System;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                {
                    if(registro.Data.CompareTo(DateTime.Now) < 0)
                    {
                        alien.EstaNaTerra = true;
                        _dbContext.Entry(alien).State = EntityState.Modified;

                        var registroModel = new RegistroModel
                        {
                            AlienId = registro.AlienId,
                            DataEntrada = registro.Data
                        };
                        _dbContext.Registros.Add(registroModel);
                        await _dbContext.SaveChangesAsync();
                    }else throw new Exception("Data Maior que Data Atual");
                }
                else
                {
                    if (alien.EstaNaTerra)
                    {
                        var lista = await _dbContext.Registros.Where(r => r.AlienId == registro.AlienId).ToListAsync();
                        var registroAlien = lista[lista.Count - 1];

                        if (registro.Data.CompareTo(DateTime.Now) < 0)
                        {
                            if (registro.Data.CompareTo(registroAlien.DataEntrada) > 0)
                            {
                                alien.EstaNaTerra = false;
                                _dbContext.Entry(alien).State = EntityState.Modified;


                                registroAlien.DataSaida = registro.Data;
                                await _dbContext.SaveChangesAsync();
                            }
                            else throw new Exception("Data de Saída inferior a Data de Entrada.");
                        }
                        else throw new Exception("Data Maior que Data Atual");                              
                    }
                    else throw new Exception("Alien não está na Terra.");                   
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
