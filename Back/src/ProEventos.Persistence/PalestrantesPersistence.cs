using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class PalestrantesPersistence : IPalestrantesPersistence
    {
        private readonly ProEventosContext proEventosContext;

        public PalestrantesPersistence(ProEventosContext proEventosContext)
        {
            this.proEventosContext = proEventosContext;
        }
       
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = proEventosContext.Palestrantes
            .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
                IQueryable<Palestrante> query = proEventosContext.Palestrantes
                 .Include(p => p.RedesSociais);

                if (includeEventos)
                {
                    query = query.Include(p => p.PalestrantesEventos)
                        .ThenInclude(pe => pe.Evento);
                }

                query = query.AsNoTracking().OrderBy(p => p.Id)
                    .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

                return await query.ToArrayAsync();
            }



        public async Task<Palestrante> GetPalestrantesByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = proEventosContext.Palestrantes
               .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p =>p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

    } 
}
