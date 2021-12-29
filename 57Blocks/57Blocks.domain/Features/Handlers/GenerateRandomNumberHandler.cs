using _57Blocks.domain.DataBase;
using _57Blocks.domain.Features.Commands;
using _57Blocks.domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _57Blocks.domain.Features.Handlers
{
    public class GenerateRandomNumberHandler : IRequestHandler<GenerateRandomNumberCommand, int>
    {
        public async Task<int> Handle(GenerateRandomNumberCommand request, CancellationToken cancellationToken)
        {
            var response = await GetRequest("http://www.randomnumberapi.com/api/v1.0/random?min=100&max=1000&count=1");
            return response.First();
        }

        private async Task<List<int>> GetRequest(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
            string response;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            var result = JsonConvert.DeserializeObject<List<int>>(response);
            return result;
        }
    }
}
