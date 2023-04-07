using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
namespace TestLibrary
{
    class Program
    {
        static async Task Main()
        {
            var service = new OpenAIService(new OpenAiOptions
            {
                ApiKey = "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"
            });

            service.SetDefaultModelId(OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo);

            var messages = new List<ChatMessage>
            {
                ChatMessage.FromSystem("From now on, you behave like an extremely enthusiastic Youtube viewer"),
                ChatMessage.FromUser(Console.ReadLine())
            };

            var req = new ChatCompletionCreateRequest
            {
                Messages = messages,
                N = 1,
                MaxTokens = 2000,
                FrequencyPenalty = 2.0f,
                Temperature = 0.1f
            };

            var res = await service.ChatCompletion.CreateCompletion(req);
            if (res.Successful)
            {
                Console.WriteLine(res.Choices.First().Message.Content);
                Console.ReadLine();
            }
        }
    }
}