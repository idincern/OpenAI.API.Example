using OpenAI.API.Example;
using OpenAI.API.Example.Services;
using OpenAI.GPT3.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        //services.AddHostedService<OpenAICompletionService>();
        services.AddHostedService<OpenAIImageService>();
    })
    .Build();

host.Run();
