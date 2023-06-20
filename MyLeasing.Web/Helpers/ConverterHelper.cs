using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Models;

namespace MyLeasing.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Owners ToOwners(OwnerViewModel model, string path, bool isNew)
        {
            return new Owners
            {
                Id = isNew ? 0 : model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CellPhone = model.CellPhone,
                ImageUrl = path,
                Address = model.Address,
                Document = model.Document,
                FixedPhone = model.FixedPhone,
                User = model.User
            };
        }

        public OwnerViewModel ToOwnerViewModel(Owners owners)
        {
            return new OwnerViewModel
            {
                Id = owners.Id,
                FirstName = owners.FirstName,
                LastName = owners.LastName,
                CellPhone = owners.CellPhone,
                ImageUrl = owners.ImageUrl,
                Address = owners.Address,
                Document = owners.Document,
                FixedPhone = owners.FixedPhone,
                User = owners.User
            };
        }



        //----------------------------------LESSEES--------------------------------------------------

        public Lessee toLessee(LesseeViewModel model, string path, bool isNew)
        {
            return new LesseeViewModel
            {
                Id = isNew ? 0 : model.Id,
                Document = model.Document,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FixedPhone = model.FixedPhone,
                CellPhone = model.CellPhone,
                Address = model.Address,
                Photo = path,
            };
        }

        public LesseeViewModel ToLesseeViewModel(Lessee lessee)
        {
            return new LesseeViewModel
            {
                Id = lessee.Id,
                Document = lessee.Document,
                FirstName = lessee.FirstName,
                LastName = lessee.LastName,
                FixedPhone = lessee.FixedPhone,
                CellPhone = lessee.CellPhone,
                Address = lessee.Address,
                Photo = lessee.Photo,
            };
        }
    }
}
