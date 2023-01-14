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
    internal class OpenAIImageService : BackgroundService
    {
        readonly IOpenAIService _openAiService;

        public OpenAIImageService(IOpenAIService openAiService)
        {
            _openAiService = openAiService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Console.Write("Resim Açıklama : ");

                var result = await _openAiService.Image.CreateImage(
                    new ImageCreateRequest()
                    {
                        Prompt = Console.ReadLine(),
                        // Image Genetare Number
                        N=2,
                        // Image Size 1024
                        Size=StaticValues.ImageStatics.Size.Size1024,
                        // Gives a URL
                        ResponseFormat=StaticValues.ImageStatics.ResponseFormat.Url,
                        User="Test"
                    });
                Console.WriteLine(String.Join("\n", result.Results.Select(x => x.Url)));
            }
        }




    }
}
