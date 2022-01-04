using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Services
{
    public interface IPalestrantesService
    {
        Task<Palestrante> AddPalestrantes(Palestrante model);

        Task<Palestrante> UpdatePalestrante(int palestranteId, Palestrante model);

        Task<Palestrante> DeletePalestrante(int palestranteId);

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);

        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);

        Task<Palestrante> GetPalestrantesByIdAsync(int palestranteId, bool includeEventos);
    }
}
