using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.API.Example.Services
{
    public class OpenAICompletionService : BackgroundService
    {
        readonly IOpenAIService _openAIService;

        public OpenAICompletionService(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        // İşlemler abstract sınıfında 
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Konsol uygulaması her soru sorulduğunda
            // 1 sonraki soru sorulacak
            while(true)
            {
                Console.Write("Soru : ");
               var result = await _openAIService.Completions.CreateCompletion(
                    new CompletionCreateRequest()
                    {
                        Prompt=Console.ReadLine(),
                        // Soruya verilecek cevabın max karakteri
                        MaxTokens=500
                    },Models.TextDavinciV3);

                // gelicek Cevaplardan ilkini yazdır.
                Console.WriteLine(result.Choices[0].Text);
            }
        }
    }
}
