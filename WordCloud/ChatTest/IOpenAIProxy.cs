using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatTest
{
    public interface IOpenAIProxy
    {
        Task<ChatCompletionMessage[]> SendChatMessage(string message);
    }
}
