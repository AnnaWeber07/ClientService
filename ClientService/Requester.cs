using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientService
{
    public class Requester
    {
        public async Task<GetMenu> GetMenuAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    GetMenu getMenu = null;
                    getMenu = await client.GetFromJsonAsync<GetMenu>($"http://localhost:8084/");

                    return getMenu;
                }
            }

            catch (Exception e)
            {
                LogsWriter.Log("Smth went wrong with menu" + e);
                return null;
            }

            return null;
        }

        public async Task<PostOrderResponse> PostOrderAsync(long clientId, List<Order> orders)
        {
            var orderRequest = new PostOrderRequest(clientId, orders);

            using HttpClient httpClient = new HttpClient();

            var content = JsonSerializer.Serialize(orderRequest);
            string mediaType = "application/json";

            var postResponse = await httpClient.PostAsJsonAsync("http://localhost:8084/" + "ready",
                new StringContent(content, Encoding.UTF8, mediaType));
            //по этому порту 8084 принимаю ответ от доставки

            var textresponse = await postResponse.Content.ReadFromJsonAsync<PostOrderResponse>();


            if (postResponse.IsSuccessStatusCode)
            {
                LogsWriter.Log($"Order is sent to Food Ordering");
                return textresponse;
            }
            else
            {
                LogsWriter.Log("The client is fed up");
                return null;
            }

            //food ordering sends back post order response
            return null;
        }

        public async Task<GetOrderById> GetOrderByIDAsync(string path, long id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    GetOrderById getOrderById = null;
                    //var order = await client.GetFromJsonAsync<GetOrderById>(client.BaseAddress); //todo: restaurant order id
                    HttpResponseMessage response = await client.GetAsync(path + "/" + $"{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        LogsWriter.Log($"The order was successfully requested by ID {id}");
                        var textResponse = await response.Content.ReadFromJsonAsync<GetOrderById>();
                        return textResponse;
                    }

                    else
                    {
                        LogsWriter.Log($"The order wasn't successfully requested by ID {id}");
                        return null;
                    }
                }
            }

            catch (Exception e)
            {
                LogsWriter.Log("Smth went wrong with getting the order by its id" + e);
                return null;
            }

            return null;
        }


        public async Task StartRequester(ClientService clientService)
        {
            GetMenuAsync();
        }
    }
}
