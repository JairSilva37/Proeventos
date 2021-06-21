using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {

        private readonly ProEventosContext _context;
        public EventoPersist(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(e => e.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.EventoId);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(e => e.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.EventoId).Where(x => x.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(e => e.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.EventoId).Where(x => x.EventoId == eventoId);
            return await query.FirstOrDefaultAsync();
        }

    }
}