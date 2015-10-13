
namespace FastFoodWebApplication.Models
{
    public class OrderModel
    {
        public int ProductId { get; set; }

        public int PersonId { get; set; }

        public decimal TotalPrice { get; set; }
    }
}