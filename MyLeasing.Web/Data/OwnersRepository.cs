using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Entities;


namespace MyLeasing.Web.Data
{
    public class OwnersRepository : GenericRepository<Owners> , IOwnersRepository
    {
        private readonly DataContext _context;

        public OwnersRepository(DataContext context) : base(context)
        {
            _context = context;
        }


        public IQueryable GetAllWithUsers()
        {
            return _context.Owners.Include(p => p.User);
        }
    }
}
