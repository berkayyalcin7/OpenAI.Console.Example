using OpenAI.API.Example;
using OpenAI.API.Example.Services;
using OpenAI.GPT3.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(
            settings =>
            settings.ApiKey = "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"
        );

        //services.AddHostedService<OpenAICompletionService>();
        services.AddHostedService<OpenAIImageService>();
        //services.AddHostedService<Worker>();

    })
    .Build();

await host.RunAsync();

// api key : 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