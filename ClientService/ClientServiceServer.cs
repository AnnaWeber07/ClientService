using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ClientService
{
    //отдельный хэндлер для каждого экшна / веб сервиса?


    public class ClientServiceServer
    {
        private static HttpListener listener;
        static readonly HttpClient httpClient = new();

        private static string receiveFOUrl = "http://localhost:8084/"; //food service url
        private static string sendFOUrl = "http://localhost:8085/"; //food service url

        private static string restaurant1receiveUrl = "http://localhost:8086/"; //first restaurant receiver
        private static string restaurant2receiveUrl = "http://localhost:8087/"; //second restaurant receiver
        private static string restaurant3receiveUrl = "http://localhost:8088/"; //third restaurant receiver

        //private static string restaurant1sendUrl = "http://localhost:8089/"; //first restaurant sender
        //private static string restaurant2sendUrl = "http://localhost:8090/"; //second restaurant sender
        //private static string restaurant3sendUrl = "http://localhost:8091/"; //third restaurant sender

        private ClientService clientService;

        public void SendOrder(Order clientOrder, Client foodClient)
        {
            //send the order to food service
            using var client = new HttpClient();

            var message = JsonSerializer.Serialize(clientOrder);

            var mediaType = "application/json";

            var response = client.PostAsync(sendFOUrl + "order", new StringContent(message,
            Encoding.UTF8, mediaType))
                                 .GetAwaiter()
                                 .GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                foodClient.state = ClientState.Waiting;
                LogsWriter.Log($"Order {clientOrder.Items} was sent.");
            }

        }

        static async Task<Order> GetOrderAsync(string path)
        {
            Order order = null;
            HttpResponseMessage response = await httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                order = await response.Content.ReadFromJsonAsync<Order>();
            }

            return order;
        }

        public async void Start(ClientService clientService)
        {
            this.clientService = clientService;

            listener = new HttpListener();
            listener.Prefixes.Add(receiveFOUrl);
            listener.Start();

            await HandeIncomingConnections();

            listener.Close();
        }
    }
}
