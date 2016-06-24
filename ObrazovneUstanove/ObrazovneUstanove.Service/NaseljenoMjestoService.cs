using System.Collections.Generic;
using System.Linq;
using ObrazovneUstanove.Domain;
using System.Data.Entity;
using System.Linq.Dynamic;

namespace ObrazovneUstanove.Service
{
    public interface INaseljenoMjestoService
    {
        IQueryable<NaseljnoMjesto> GetAll();
        IQueryable<NaseljnoMjesto> GetAll(int skip, int take, string sortBy);
        NaseljnoMjesto Get(byte id);
        bool Delete(byte id);
        void Update(NaseljnoMjesto t);
        int AddGetId(NaseljnoMjesto t);
    }

    public class NaseljenoMjestoService : INaseljenoMjestoService
    {
        private readonly ObrazovneUstanoveContext _context;

        public NaseljenoMjestoService(ObrazovneUstanoveContext context)
        {
            _context = context;
        }

        public IQueryable<NaseljnoMjesto> GetAll()
        {
            return _context.NaseljnoMjestoes;
        }

        public IQueryable<NaseljnoMjesto> GetAll(int skip, int take, string sortBy)
        {
            return _context.NaseljnoMjestoes.OrderBy(sortBy).Skip(skip).Take(take);
        }

        public NaseljnoMjesto Get(byte id)
        {
            return _context.NaseljnoMjestoes.Find(id);
        }

        public bool Delete(byte id)
        {
            var elem = Get(id);

            if (elem != null)
            {
                _context.NaseljnoMjestoes.Remove(elem);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Update(NaseljnoMjesto t)
        {
            _context.NaseljnoMjestoes.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public int AddGetId(NaseljnoMjesto t)
        {
            _context.NaseljnoMjestoes.Add(t);
            _context.SaveChanges();

            return t.NaseljenoMjestoId;
        }
    }
}
