namespace EcommerceClothes.Entities
{
    public class Client : User
    {
        public Client() {
            UserType = (EcommerceClothes.Enums.UserType.Client);
        }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
