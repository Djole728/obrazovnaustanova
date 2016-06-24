using System.Collections.Generic;
using System.Linq;
using ObrazovneUstanove.Domain;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace ObrazovneUstanove.Service
{
    public interface IOpstinaService
    {
        IQueryable<Opstina> GetAll();
        IQueryable<Opstina> GetAll(int skip, int take, string sortBy);
        Opstina Get(byte id);
        bool Delete(byte id);
        void Update(Opstina t);
        int AddGetId(Opstina t);
    }

    public class OpstinaService : IOpstinaService
    {
        private readonly ObrazovneUstanoveContext _context;

        public OpstinaService(ObrazovneUstanoveContext context)
        {
            _context = context;
        }

        public IQueryable<Opstina> GetAll()
        {
            return _context.Opstinas;
        }

        public IQueryable<Opstina> GetAll(int skip, int take, string sortBy)
        {
            return _context.Opstinas.OrderBy(sortBy).Skip(skip).Take(take);
        }

        public Opstina Get(byte id)
        {
            return _context.Opstinas.Find(id);
        }

        public bool Delete(byte id)
        {
            var elem = Get(id);

            if (elem != null)
            {
                _context.Opstinas.Remove(elem);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Update(Opstina t)
        {
            _context.Opstinas.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public int AddGetId(Opstina t)
        {
            _context.Opstinas.Add(t);
            _context.SaveChanges();

            return t.OpstinaId;
        }
    }
}
