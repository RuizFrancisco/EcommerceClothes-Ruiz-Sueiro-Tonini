namespace EcommerceClothes.Entities
{
    public class Admin : User
    {
        public Admin() {
            UserType = (EcommerceClothes.Enums.UserType.Admin);
        }
    }
}
