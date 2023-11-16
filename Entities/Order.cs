using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceClothes.Entities
{
    public class Order
    {
        public Order()
        {
            CalculateTotalPrice();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float? TotalPrice { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public ICollection<LineOfOrder> LinesOfOrder { get; set; } = new List<LineOfOrder>();

        public void CalculateTotalPrice()
        {
            TotalPrice = LinesOfOrder?.Sum(sl => sl.TotalPrice) ?? 0;
        }

    }
}
