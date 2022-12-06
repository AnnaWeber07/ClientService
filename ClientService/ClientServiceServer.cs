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
        ClientService clientService;

        public Requester requester = new();


        public async Task StartService()
        {
            await requester.StartRequester(clientService);
        }

        //TODO: include requester

    }
}
