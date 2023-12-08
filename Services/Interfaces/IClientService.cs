using EcommerceClothes.Entities;

namespace EcommerceClothes.Services.Interfaces
{
    public interface IClientService
    {
        List<User> GetClients();
        Client GetClientById(int id);
        Client UpdateClient(Client client);
    }
}
