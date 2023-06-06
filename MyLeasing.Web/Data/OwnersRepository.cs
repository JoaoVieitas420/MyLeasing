using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Data
{
    public class OwnersRepository : GenericRepository<Owners> , IOwnersRepository
    {
        public OwnersRepository(DataContext context) : base(context)
        {
        }
    }
}
