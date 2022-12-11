using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    public enum ClientState
    {
        Free,
        Waiting,
        Done
    }

    public class Client : IDisposable
    {
        private static readonly ObjectIDGenerator iDGenerator = new();
        private readonly Thread _clientsThread;

        public long Id { get; private set; }
        public ClientState state;
        public ClientService ClientService;
        public Requester requester = new();

        //post order response thread?


        public ClientService clientService { get; private set; }


        public Client()
        {
            Id = iDGenerator.GetId(this, out _);
            state = ClientState.Free;


            _clientsThread = new Thread(ClientWorkMethod)
            {
                IsBackground = true,
                Name = $"ClientThread_{Id}" //Thread.Name
            };

            _clientsThread.Start();
        }

        public void ClientWorkMethod()
        {
            try
            {
                while (true)
                {
                    if (state == ClientState.Free)
                    {
                        //generate order and send it
                        var ordersList = GenerateOrders();
                        var x = requester.PostOrderAsync(Id, ordersList);

                        //order.GenerateOrders();
                        LogsWriter.Log($"Client number {Id} generated the order");

                        //response?

                        state = ClientState.Waiting;
                    }

                    else if (state == ClientState.Waiting)
                    {
                       // string path = clientService.GetMenuPayload.Where(x => );
                        //GetOrderById getOrderById = requester.GetOrderByIDAsync(path, id);

                        //if isready, then delete the order and 

                    }

                    else if (state == ClientState.Done)
                    {
                        //receive prepared order from respective restaurant and enjoyyyy
                    }
                }
            }

            catch
            {
                Console.WriteLine("Something went wrong with the client. Too much food, maybe");
            }
        }

        public List<Order> GenerateOrders()
        {
            Random random = new Random();

            var quantity = random.Next(1, 3); //dish quantity

            List<Order> orders = new List<Order>();

            var randomRest = random.Next(1, 4); //restaurant id


            for (int i = 0; i < quantity; i++)
            {
                //var nMenu = clientService.GetMenuPayload.Find(x => x.RestaurantId == randomRest);
                //var dishId = random.Next(nMenu.MenuValues.Count);



                //todo: randomizer
            }

            return orders;
        }

        public void RemoveOrder(Client client)
        {
            clientService.Clients.Remove(client);
        }

        public void Dispose()
        {
            _clientsThread.Interrupt();
        }
    }
}
