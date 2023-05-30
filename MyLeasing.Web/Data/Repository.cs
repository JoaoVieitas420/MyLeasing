using MyLeasing.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Owners> GetOwners()
        {
            return _context.Owners.OrderBy(o => o.Id);
        }

        public Owners GetOwner(int id)
        {
            return _context.Owners.Find(id);
        }

        public void AddOwner(Owners owner)
        {
            _context.Owners.Add(owner);
        }

        public void UpdateOwner(Owners owner)
        {
            _context.Owners.Update(owner);
        }

        public void DeleteOwner(Owners owner)
        {
            _context.Owners.Remove(owner);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool OwnerExists(int id)
        {
            return _context.Owners.Any(o => o.Id == id);
        }
    }
}
