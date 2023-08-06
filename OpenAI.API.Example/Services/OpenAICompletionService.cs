using OpenAI.Interfaces;
using OpenAI.Managers;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels.ResponseModels;

namespace OpenAI.API.Example.Services
{
    public class OpenAICompletionService : BackgroundService
    {
        readonly IOpenAIService _openAIService;

        public OpenAICompletionService(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                var completionResult = _openAIService.Completions.CreateCompletionAsStream(new CompletionCreateRequest()
                {
                    Prompt = "Bu programın çalışıp çalışmadığının testi için C# kodu yazar mısın?",
                    MaxTokens = 50
                }, Models.Davinci);

                await foreach (var completion in completionResult)
                {
                    if (completion.Successful)
                    {
                        Console.Write(completion.Choices.FirstOrDefault()?.Text);
                    }
                    else
                    {
                        if (completion.Error == null)
                        {
                            throw new Exception("Unknown Error");
                        }

                        Console.WriteLine($"{completion.Error.Code}: {completion.Error.Message}");
                    }
                }
                Console.WriteLine("Complete");
            }
        }
    }
}
