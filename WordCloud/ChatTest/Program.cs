﻿using Standard.AI.OpenAI.Clients.OpenAIs;
using Standard.AI.OpenAI.Models.Configurations;
using Standard.AI.OpenAI.Models.Services.Foundations.AIFiles;
using Standard.AI.OpenAI.Models.Services.Foundations.FineTunes;
using System.Text;

namespace ChatTest
{
    internal class Program
    {
        //static async Task Main(string[] args)
        //{
        //    IOpenAIProxy chatOpenAI = new OpenAIProxy(
        //        apiKey: "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",
        //        organizationId: "org-FLhGnvaeHySTUD1aFQFWPnYt");

        //    var msg = Console.ReadLine();

        //    do
        //    {
        //        if(!string.IsNullOrEmpty(msg))
        //        {
        //            var results = await chatOpenAI.SendChatMessage(msg);

        //            foreach (var item in results)
        //            {
        //                Console.WriteLine($"{item.Role}: {item.Content}");
        //            }

        //            Console.WriteLine("Next Prompt:");
        //        }

        //        msg = Console.ReadLine();

        //    } while (msg != "bye");
        //}
        static async Task Main(string[] args)
        {
            //var openAIConfigurations = new OpenAIConfigurations
            //{
            //    ApiKey = "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",
            //    ApiUrl = "https://api.openai.com"
            //};

            //IOpenAIClient openAIClient =
            //    new OpenAIClient(openAIConfigurations);

            //MemoryStream memoryStream = CreateRandomStream();

            //var aiFile = new AIFile
            //{
            //    Request = new AIFileRequest
            //    {
            //        Name = "Test",
            //        Content = memoryStream,
            //        Purpose = "fine-tune"
            //    }
            //};

            //AIFile file = await openAIClient.AIFiles
            //    .UploadFileAsync(aiFile);

            //var fineTune = new FineTune();
            //fineTune.Request = new FineTuneRequest();

            //fineTune.Request.FileId =
            //    file.Response.Id;

            //FineTune fineTuneResult =
            //    await openAIClient.FineTuneClient
            //        .SubmitFineTuneAsync(fineTune);

            //Console.WriteLine(fineTuneResult);

            var chatGPT = new ChatGPT();
            Console.WriteLine("Waiting for response...");
            string response = await chatGPT.GenerateLoremIpsum();
            Console.WriteLine(response);
        }

        private static MemoryStream CreateRandomStream()
        {
            string content = "{\"prompt\": \"<prompt text>\", \"completion\": \"<ideal generated text>\"}";

            return new MemoryStream(Encoding.UTF8.GetBytes(content));
        }
    }
}