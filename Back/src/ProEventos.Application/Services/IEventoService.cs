using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Application.Services
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        
        Task<bool> DeleteEvento(int eventoId);

        Task<Evento> UpdateEvento(int eventoId, Evento model);

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);

        Task<Evento> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}
