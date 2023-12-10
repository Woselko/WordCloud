using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatTest
{
    internal class ChatGPT
    {
        private static HttpClient Http = new HttpClient();
        public async Task<string> GenerateLoremIpsum()
        {
            // Replace [INSERT_YOUR_OWN_API_KEY] with a valid OpenAI API key
            var apiKey = "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";
            Http.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            // JSON content for the API call
            var jsonContent = new
            {
                prompt = "Give me some lorem ipsum text",
                model = "text-babbage-001",
                max_tokens = 1000
            };

            // Make the API call
            var responseContent = await Http.PostAsync("https://api.openai.com/v1/completions", new StringContent(JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json"));

            // Read the response as a string
            var resContext = await responseContent.Content.ReadAsStringAsync();

            // Deserialize the response into a dynamic object
            var data = JsonConvert.DeserializeObject<dynamic>(resContext);
            return data.choices[0].text;
        }
    }
}
