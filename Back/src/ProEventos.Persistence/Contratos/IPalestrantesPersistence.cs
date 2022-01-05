using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantesPersistence
    {
         
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);

        Task<Palestrante[]> GetAllPalestrantesAsync( bool includeEventos);

        Task<Palestrante> GetPalestrantesByIdAsync(int palestranteId, bool includeEventos);

    }
}
