
using SQLitePCL;
using System.Linq;

namespace finalTest.Models
{
    public class EFEntertainmentRepository : IEntertainmentRepository
    {
        private EntertainmentAgencyExampleContext _context;

        public EFEntertainmentRepository(EntertainmentAgencyExampleContext temp)
        { 
            _context = temp;
        }

        public List<Entertainer> Entertainers => _context.Entertainers.ToList();

        public void AddEntertainer(Entertainer entertainer)
        {
            _context.Add(entertainer);
            _context.SaveChanges();
        }

        public Entertainer GetEntertainer(int id)
        {
            return _context.Entertainers.FirstOrDefault(e => e.EntertainerId == id);
        }

        public void UpdateEntertainer(Entertainer entertainer)
        {
            var entity = _context.Entertainers.Attach(entertainer);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteEntertainer(Entertainer entertainer)
        {
            if (entertainer != null)
            {
                _context.Entertainers.Remove(entertainer);
                _context.SaveChanges();
            }
        }
    }
}
