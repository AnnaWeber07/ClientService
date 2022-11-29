using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    public class ClientService : BackgroundService
    {
        //background client service

        private readonly List<Client> _clients = new();
        private readonly List<Order> _clientOrders = new();

        public List<Menu> ComposedMenus;

        private object _clientLocker = new object();

        public List<Client> Clients
        {
            get
            {
                lock (_clientLocker)
                {
                    return _clients;
                }
            }
        }

        public void GenerateMenus(Menu menu)
        {
            if (!ComposedMenus.Contains(menu))
                ComposedMenus.Add(menu);
        }

        //TODO: generate order
        //TODO: 

        private void GenerateClients(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Clients.Add(new Client());
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //GenerateMenus();
            GenerateClients(5);
            return Task.CompletedTask;
        }

        public void ServeOrder(Order order)
        {
            
            if (order.IsReady == true)
            {
                
                LogsWriter.Log($"The order is ready and transported to the client");
            }
        }




        internal void RequestOrder()
        {
            //request an order from food service
        }
    }
}
