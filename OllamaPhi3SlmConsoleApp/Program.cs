using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Text;

// create a new host application builder
var builder = Host.CreateEmptyApplicationBuilder(new HostApplicationBuilderSettings
{
    Args = args
});

// register OpenAI chat completion service
builder.Services.AddOpenAIChatCompletion(
    modelId: "phi3",
    apiKey: null,
    endpoint: new Uri("http://localhost:11434") // With local Ollama OpenAI API endpoint
);

var app = builder.Build();

// create a new chat
var chat = app.Services.GetRequiredService<IChatCompletionService>();

// define the chat system message
var chatSystemMessage = Prompt("What am I?");
if (string.IsNullOrWhiteSpace(chatSystemMessage))
{
    SayGoodbye();
    return;
}

// create a new chat history with the chat system message
var chatHistory = new ChatHistory(chatSystemMessage);

// create a string builder to store the AI response
var stringBuilder = new StringBuilder();

// keep the chat running until the user exits
while (true)
{
    // ask the user for input
    var userQuestion = Prompt();
    if (string.IsNullOrWhiteSpace(userQuestion))
    {
        SayGoodbye();
        break;
    }

    // add the user question to the chat history
    chatHistory.AddUserMessage(userQuestion);

    // get the AI response streamed back to the console
    await foreach (var message in chat.GetStreamingChatMessageContentsAsync(chatHistory))
    {
        Say(message);
        stringBuilder.Append(message.Content);
    }

    // add the AI response to the chat history
    chatHistory.AddAssistantMessage(stringBuilder.ToString());
    stringBuilder.Clear();
}

// prompt the user for a question and return the answer
string? Prompt(string question = "?")
{
    Console.WriteLine();
    Console.Write($"{question} ");

    var answer = Console.ReadLine();
    return answer?.Trim();
}

// write a messages to the console
void Say(StreamingChatMessageContent? message) => Console.Write(message);

// say goodbye to the user
void SayGoodbye() => Console.WriteLine("Goodbye!");