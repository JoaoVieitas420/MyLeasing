using MyLeasing.Web.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public interface IRepository
    {
        void AddOwner(Owners owner);
        void DeleteOwner(Owners owner);
        Owners GetOwner(int id);
        IEnumerable<Owners> GetOwners();
        bool OwnerExists(int id);
        Task<bool> SaveAllAsync();
        void UpdateOwner(Owners owner);

        void AddLessee(Lessee lessee);
        void DeleteLessee(Lessee lessee);
        Lessee GetLessee(int id);
        IEnumerable<Lessee> GetLessee();
        bool LesseeExists(int id);
        void UpdateLessee(Lessee lessee);
    }
}