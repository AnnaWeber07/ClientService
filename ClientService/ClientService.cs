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

        Requester requester;

        private readonly List<Client> _clients = new();
        private readonly List<Order> _clientOrders = new();

        public List<GetMenu> GetMenuPayload;

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

        public void GenerateMenus()
        {
            GetMenu jsonMenu = new();
            requester.GetMenuAsync().GetAwaiter();
            GetMenuPayload.Add(jsonMenu);
        }


        private void GenerateClients(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Clients.Add(new Client());
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            GenerateMenus();
            GenerateClients(5);
            return Task.CompletedTask;
        }

        internal void RequestOrder()
        {
            //request an order from food service
        }
    }
}
