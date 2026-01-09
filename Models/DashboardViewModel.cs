namespace CoffeeShop.Models
{
    public class DashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int NewOrders { get; set; }
        public decimal GrowthRate { get; set; } // e.g., 0.05 for 5%
    }
}
