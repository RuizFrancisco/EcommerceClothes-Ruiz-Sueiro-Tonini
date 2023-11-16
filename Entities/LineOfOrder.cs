using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceClothes.Entities
{
    public class LineOfOrder
    {
        public LineOfOrder()
        {
            CalculateTotalPrice();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float? TotalPrice { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("SaleId")]
        public Order Order { get; set; }
        public int OrderId { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>(); 

        public void CalculateTotalPrice()
        {
            TotalPrice = Quantity * (Product?.Price ?? 0);
        }

    }
}
