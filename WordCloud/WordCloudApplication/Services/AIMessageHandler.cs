namespace WordCloudApplication.Services
{
    public class AIMessageHandler
    {
        public async Task<string> GetInputForWordCloudAsync(string inputMessage)
        {
            Task.Delay(5000).Wait();
            return "AI words: " + inputMessage;
        }
    }
}
