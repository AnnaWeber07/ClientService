using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    public class Order
    {
        public int RestaurantId { get; set; }
        public List<long> Items { get; set; }
        public int Priority { get; set; }
        public float MaxWait { get; set; }
        public TimeSpan CreatedTime { get; set; } //UNIX timestamp

        public Order(int restaurantId, List<long> items, int priority, float maxWaitingTime, TimeSpan createdTime)
        {
            RestaurantId = restaurantId;
            Items = items;
            Priority = priority;
            MaxWait = maxWaitingTime;
            CreatedTime = createdTime;
        }

    }
}
