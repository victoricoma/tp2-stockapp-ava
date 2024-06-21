using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comtele.Sdk.Services;
using StockApp.Application.Interfaces;

namespace StockApp.Application.Services
{
    public class ComteleSmsService : ISmsService
    {
        private readonly string _apiKey;

        public ComteleSmsService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task SendSmsAsync(string phoneNumber, string message)
        {
            var textMessageService = new TextMessageService(_apiKey);

            var result = textMessageService.Send(
                "my_id",
                message,
                new string[] { phoneNumber }
            );

            if ( !result.Success )
            {
                throw new Exception("A mensagem não pode ser enviada. Detalhes: " + result.Message);
            }

            await Task.CompletedTask;
        }
    }
}
