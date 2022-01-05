using ProEventos.Application.Services;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence geralPersistence;
        private readonly IEventoPersistence eventoPersistence;

        public EventoService(IGeralPersistence geralPersistence, IEventoPersistence eventoPersistence)
        {
            this.geralPersistence = geralPersistence;
            this.eventoPersistence = eventoPersistence;
        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                geralPersistence.Add<Evento>(model);
                if (await geralPersistence.SaveChangesAsync())
                {
                    return await eventoPersistence.GetEventosByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await eventoPersistence.GetEventosByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento para deletar não foi encontrado.");

                

                geralPersistence.Delete(evento);
                return await geralPersistence.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await eventoPersistence.GetEventosByIdAsync(eventoId, false);
                if(evento == null) return null;

                model.Id = evento.Id;

                geralPersistence.Update(model);
                if (await geralPersistence.SaveChangesAsync())
                {
                    return await eventoPersistence.GetEventosByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await eventoPersistence.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null; 
                
                return eventos;
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await eventoPersistence.GetAllEventosByTemaAsync(tema,includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await eventoPersistence.GetEventosByIdAsync(eventoId, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       
    }
}
