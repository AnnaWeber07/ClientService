using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    public class RestaurantOrder
    {
        public long RestaurantId { get; set; }
        public string RestaurantAddress { get; set; }
        public long OrderId { get; set; }
        public TimeSpan EstimatedWaitingTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime RegisteredTime { get; set; }
    }
}
