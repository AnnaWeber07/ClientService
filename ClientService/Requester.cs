using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientService
{
    public class Requester
    {

        public Menu GetMenu()
        {

        }

        public async PostOrderResponse PostOrder(long clientId, List<Order> orders)
        {
            var orderRequest = new PostOrderRequest(clientId, orders);

            using HttpClient httpClient = new HttpClient();

            var content = JsonSerializer.Serialize(orderRequest);
            string mediaType = "application/json";

            var postResponse = httpClient.PostAsync("http://localhost:8084/" + "ready",
                new StringContent(content, Encoding.UTF8, mediaType))
                .GetAwaiter().GetResult();
            //по этому порту 8084 принимаю ответ от доставки

            //todo: get response

            if (postResponse.IsSuccessStatusCode)
            {
                LogsWriter.Log($"Order is sent to Food Ordering");
            }
            else
            {
                LogsWriter.Log("The client is fed up");
            }

            //food ordering sends back post order response
        }


    }
}
