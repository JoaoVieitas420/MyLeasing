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

    }
}