using System.Linq;
using ObrazovneUstanove.Domain;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace ObrazovneUstanove.Service
{
    public interface IStrucnaSpremaService
    {
        IQueryable<StrucnaSprema> GetAll();
        IQueryable<StrucnaSprema> GetAll(int skip, int take, string sortBy);
        StrucnaSprema Get(byte id);
        bool Delete(byte id);
        void Update(StrucnaSprema t);
        int AddGetId(StrucnaSprema t);
    }

    public class StrucnaSpremaService : IStrucnaSpremaService
    {
        private readonly ObrazovneUstanoveContext _context;

        public StrucnaSpremaService(ObrazovneUstanoveContext context)
        {
            this._context = context;
        }

        public IQueryable<StrucnaSprema> GetAll()
        {
            return _context.StrucnaSpremas;
        }

        public IQueryable<StrucnaSprema> GetAll(int skip, int take, string sortBy)
        {
            return _context.StrucnaSpremas.OrderBy(sortBy).Skip(skip).Take(take);
        }

        public StrucnaSprema Get(byte id)
        {
            return _context.StrucnaSpremas.Find(id);
        }

        public bool Delete(byte id)
        {
            var elem = Get(id);

            if (elem != null)
            {
                _context.StrucnaSpremas.Remove(elem);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Update(StrucnaSprema t)
        {
            _context.StrucnaSpremas.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public int AddGetId(StrucnaSprema t)
        {
            _context.StrucnaSpremas.Add(t);
            _context.SaveChanges();

            return t.StrucnaSpremaId;
        }
    }
}
