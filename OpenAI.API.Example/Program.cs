using OpenAI.API.Example;
using OpenAI.API.Example.Services;
using OpenAI.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        services.AddHostedService<OpenAICompletionService>();
        //services.AddHostedService<OpenAIImageService>();
    })
    .Build();

host.Run();
