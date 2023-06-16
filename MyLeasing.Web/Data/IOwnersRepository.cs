using MyLeasing.Web.Data.Entities;
using System.Linq;

namespace MyLeasing.Web.Data
{
    public interface IOwnersRepository : IGenericRepository<Owners>
    {
        public IQueryable GetAllWithUsers();
    }
}
