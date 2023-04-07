using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using OpenAI.GPT3;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;
using OpenAI.UI.Models;

namespace OpenAI.UI.Controllers
{
    public class OpenAIController : Controller
    {
        private readonly IOpenAIService _service;

        public OpenAIController(IOpenAIService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> OpenAISampleDeneme()
        {
            //var service = new OpenAIService(new OpenAiOptions
            //{
            //    ApiKey = "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"
            //});

            _service.SetDefaultModelId(OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo);

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

            var res = await _service.ChatCompletion.CreateCompletion(req);
            if (res.Successful)
            {
                Console.WriteLine(res.Choices.First().Message.Content);
                Console.ReadLine();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CompletionsSample(string prompt)
        {


            _service.SetDefaultModelId(OpenAI.GPT3.ObjectModels.Models.TextDavinciV3);

            var req = new CompletionCreateRequest
            {
                Prompt = "Trabzonsporun tarihi nedir?",  //Sorulan soru
                MaxTokens = 500, // Soruya verilen cevap max 500 karakter olsun
            };

            var res = await _service.Completions.CreateCompletion(req);

            if (res.Successful)
            {
                Console.WriteLine(res.Choices.FirstOrDefault());
                Console.WriteLine(res.Choices[0].Text);
            }
            else
            {
                if (res.Error == null)
                {
                    throw new Exception("Unkown Error");
                }
                Console.WriteLine($"{res.Error.Code}:{res.Error.Message}");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OpenAISample()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OpenAISamplex(string prompt, IFormCollection form)
        {

            var resSelec = form["Programming"].ToList();

            var item= resSelec.ElementAt(0);
            

            if (item== "Java")
            {
                CompletionCreateResponse result1 = await _service.Completions.CreateCompletion(new CompletionCreateRequest()
                {
                    Prompt = prompt + item + "programlama dili ile bana yazar mısın",
                    MaxTokens = 500
                }, OpenAI.GPT3.ObjectModels.Models.TextDavinciV3);

                ProgrammingModel programmingModel = new ProgrammingModel();
                programmingModel.Result = result1.Choices.FirstOrDefault().Text;


                return View(programmingModel);

                Console.WriteLine(result1.Choices.FirstOrDefault());
            }

            if (item == "C#")
            {
                CompletionCreateResponse result1 = await _service.Completions.CreateCompletion(new CompletionCreateRequest()
                {
                    Prompt = prompt + item + "ile bana yazar mısın",
                    MaxTokens = 500
                }, OpenAI.GPT3.ObjectModels.Models.TextDavinciV3);

                var sonuc = result1.Choices.FirstOrDefault();

                return View(sonuc);

                Console.WriteLine(result1.Choices.FirstOrDefault());
            }

            if (item == "Python")
            {
                CompletionCreateResponse result1 = await _service.Completions.CreateCompletion(new CompletionCreateRequest()
                {
                    Prompt = prompt + item + "ile bana yazar mısın",
                    MaxTokens = 500
                }, OpenAI.GPT3.ObjectModels.Models.TextDavinciV3);

                var sonuc = result1.Choices.FirstOrDefault();

                return View(sonuc);

                Console.WriteLine(result1.Choices.FirstOrDefault());
            }

            Console.WriteLine("::");
            CompletionCreateResponse result = await _service.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = "prompt",
                MaxTokens = 500
            }, OpenAI.GPT3.ObjectModels.Models.TextDavinciV3);

            Console.WriteLine(result.Choices.FirstOrDefault());

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OpenAIImageSample()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OpenAIImageSamplex(string prompt)
        {

            Console.WriteLine("::");
            ImageCreateResponse result = await _service.Image.CreateImage(new ImageCreateRequest()
            {
                Prompt = prompt,
                N = 2,
                Size = StaticValues.ImageStatics.Size.Size256,
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = "test"
            });
            var arr = result.Results.Select(r => r.Url);
            ImageModel image = new ImageModel();
            image.ImageUrl = arr.ElementAt(0);
            image.ImageUrl2 = arr.ElementAt(1);
            Console.WriteLine(string.Join("\n", result.Results.Select(r => r.Url)));

            return View(image);
        }
    }
}
