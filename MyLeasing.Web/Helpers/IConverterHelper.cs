using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Models;

namespace MyLeasing.Web.Helpers
{
    public interface IConverterHelper
    {
        Owners ToOwners(OwnerViewModel model, string path, bool isNew);

        OwnerViewModel ToOwnerViewModel(Owners owners);


        Lessee toLessee(LesseeViewModel model, string path, bool isNew);

        LesseeViewModel ToLesseeViewModel(Lessee lessee);
    }
}

