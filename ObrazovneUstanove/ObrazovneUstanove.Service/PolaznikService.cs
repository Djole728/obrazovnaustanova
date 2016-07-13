using ObrazovneUstanove.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;

namespace ObrazovneUstanove.Service
{
    public interface IPolaznikService
    {
        IQueryable<Polaznik> GetAll();
        IQueryable<Polaznik> GetAll(int skip, int take, string sortBy);
        Polaznik Get(int id);
        bool Delete(int id);
        void Update(Polaznik t);
        int AddGetId(Polaznik t);
    }

    public class PolaznikService : IPolaznikService
    {
        private readonly ObrazovneUstanoveContext _context;

        public PolaznikService(ObrazovneUstanoveContext context)
        {
            _context = context;
        }

        public IQueryable<Polaznik> GetAll()
        {
            return _context.Polazniks;
        }

        public IQueryable<Polaznik> GetAll(int skip, int take, string sortBy)
        {
            return _context.Polazniks.OrderBy(sortBy).Skip(skip).Take(take);
        }

        public Polaznik Get(int id)
        {
            return _context.Polazniks.Find(id);
        }

        public bool Delete(int id)
        {
            var elem = Get(id);

            if (elem != null)
            {
                _context.Polazniks.Remove(elem);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Update(Polaznik t)
        {
            _context.Polazniks.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public int AddGetId(Polaznik t)
        {
            _context.Polazniks.Add(t);
            _context.SaveChanges();

            return t.PolaznikId;
        }
    }
}
