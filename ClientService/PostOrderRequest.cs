using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    public class PostOrderRequest
    {
        public long ClientId { get; set; }

        public List<Order> Orders { get; set; }

        public PostOrderRequest(long id, List<Order> orders)
        {
            ClientId = id;
            Orders = orders;
        }

    }
}
