using System.Linq;
using System.Threading.Tasks;
using System;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Owners.Any())
            {
                AddOwner("João", "Gomes", "123456789", "987654321", "Rua da Liberdade");
                AddOwner("Mariana", "Santos", "234567890", "876543210", "Rua das Flores");
                AddOwner("Pedro", "Oliveira", "345678901", "765432109", "Rua dos Girassóis");
                AddOwner("Carla", "Ferreira", "456789012", "654321098", "Rua dos Pinheiros");
                AddOwner("Ricardo", "Rodrigues", "567890123", "543210987", "Rua das Oliveiras");
                AddOwner("Sofia", "Lima", "678901234", "432109876", "Rua dos Cravos");
                AddOwner("André", "Pereira", "789012345", "321098765", "Rua das Violetas");
                AddOwner("Marta", "Sousa", "890123456", "210987654", "Rua das Azáleas");
                AddOwner("Hugo", "Mendes", "901234567", "109876543", "Rua dos Lírios");
                AddOwner("Inês", "Costa", "012345678", "098765432", "Rua das Tulipas");
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string firstname, string lastname, string fixo, string mobile, string address)
        {
            _context.Owners.Add(new Entities.Owners
            {
                Document = _random.Next(100000),
                FirstName = firstname,
                LastName = lastname,
                FixedPhone = fixo,
                CellPhone = mobile,
                Address = address
            });
        }
    }
}
