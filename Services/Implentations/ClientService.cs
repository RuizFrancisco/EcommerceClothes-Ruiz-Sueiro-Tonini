using EcommerceClothes.Entities;
using EcommerceClothes.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceClothes.Services.Implentations
{
    public class ClientService : IClientService
    {
        private readonly DBContext.DBContext _context;

        public ClientService(DBContext.DBContext context)
        {
            _context = context;
        }

        public List<User> GetClients()
        {
            return _context.Users.Where(p => p.UserType == "Client").ToList();
        }

        public Client? GetClientById(int id)
        {
            return _context.Clients
            .Include(c => c.Orders)
            .SingleOrDefault(c => c.Id == id);
        }

        public Client UpdateClient(Client client)
        {
            _context.Update(client);
            _context.SaveChanges();
            return client;
        }
    }
}
