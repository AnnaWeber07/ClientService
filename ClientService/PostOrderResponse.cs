namespace ClientService
{
    public class PostOrderResponse
    {
        public int OrderId { get; set; }
        public List<RestaurantOrder> Orders { get; set; }

        public PostOrderResponse(int orderId, List<RestaurantOrder> orders)
        {
            OrderId = orderId;
            Orders = orders;
        }
    }
}