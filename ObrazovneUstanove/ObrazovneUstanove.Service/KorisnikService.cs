using ObrazovneUstanove.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;

namespace ObrazovneUstanove.Service
{
    public interface IKorisnikService
    {
        IQueryable<Korisnik> GetAll();
        IQueryable<Korisnik> GetAll(int skip, int take, string sortBy);
        Korisnik Get(int id);
        bool Delete(int id);
        void Update(Korisnik t);
        int AddGetId(Korisnik t);
        Korisnik GetByUserNameUndPassword(string userName, string password);
    }

    public class KorisnikService : IKorisnikService
    {
        private readonly ObrazovneUstanoveContext _context;

        public KorisnikService(ObrazovneUstanoveContext context)
        {
            _context = context;
        }

        public IQueryable<Korisnik> GetAll()
        {
            return _context.Korisniks;
        }

        public IQueryable<Korisnik> GetAll(int skip, int take, string sortBy)
        {
            return _context.Korisniks.OrderBy(sortBy).Skip(skip).Take(take);
        }

        public Korisnik Get(int id)
        {
            return _context.Korisniks.Find(id);
        }

        public bool Delete(int id)
        {
            var elem = Get(id);

            if (elem != null)
            {
                _context.Korisniks.Remove(elem);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Update(Korisnik t)
        {
            _context.Korisniks.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public int AddGetId(Korisnik t)
        {
            _context.Korisniks.Add(t);
            _context.SaveChanges();

            return t.KorisnikId;
        }

        public Korisnik GetByUserNameUndPassword(string userName, string password)
        {
            return _context.Korisniks.FirstOrDefault(o => o.Ime == userName && o.Prezime == password);
        }
    }
}
