using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Helpers;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("joao.vieitas2@gmail.com");
            if(user == null)
            {
                user = new User
                {
                    Document = "8321312",
                    FirstName = "Joao",
                    LastName = "Vieitas",
                    Email = "joao.vieitas2@gmail.com",
                    UserName = "joaovieitas",
                    PhoneNumber = "234823543"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!_context.Owners.Any())
            {
                AddOwner("João", "Gomes", "123456789", "987654321", "Rua da Liberdade", user);
                AddOwner("Mariana", "Santos", "234567890", "876543210", "Rua das Flores", user);
                AddOwner("Pedro", "Oliveira", "345678901", "765432109", "Rua dos Girassóis", user);
                AddOwner("Carla", "Ferreira", "456789012", "654321098", "Rua dos Pinheiros", user);
                AddOwner("Ricardo", "Rodrigues", "567890123", "543210987", "Rua das Oliveiras", user);
                AddOwner("Sofia", "Lima", "678901234", "432109876", "Rua dos Cravos", user);
                AddOwner("André", "Pereira", "789012345", "321098765", "Rua das Violetas", user);
                AddOwner("Marta", "Sousa", "890123456", "210987654", "Rua das Azáleas", user);
                AddOwner("Hugo", "Mendes", "901234567", "109876543", "Rua dos Lírios", user);
                AddOwner("Inês", "Costa", "012345678", "098765432", "Rua das Tulipas", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string firstname, string lastname, string fixo, string mobile, string address, User user)
        {
            _context.Owners.Add(new Entities.Owners
            {
                Document = _random.Next(100000),
                FirstName = firstname,
                LastName = lastname,
                FixedPhone = fixo,
                CellPhone = mobile,
                Address = address,
                User = user
            });
        }
    }
}
