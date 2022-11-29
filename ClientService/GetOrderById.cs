﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    public class GetOrderById
    {
        public long OrderId { get; set; }
        public bool IsReady { get; set; }
        public int Priority { get; set; }
        public float MaxWait { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime RegisteredTime { get; set; }
        public TimeSpan PreparedTime { get; set; }
        public List<CookingDetails> {get; set;}

}
}
