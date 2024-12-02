using Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using null_tgbot;
using null_tgbot.Callbacks;
using null_tgbot.Commands;
using null_tgbot.Service;
using null_tgbot.Services;
using Telegram.Bot;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        
        // Register named HttpClient to benefits from IHttpClientFactory
        // and consume it with ITelegramBotClient typed client.
        // More read:
        //  https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-5.0#typed-clients
        //  https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
        services.AddHttpClient("telegram_bot_client").RemoveAllLoggers()
                .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                {
                    //Токен тут
                    TelegramBotClientOptions options = new("");
                    return new TelegramBotClient(options, httpClient);
                });

        services.AddScoped<TgBotApp>();
        services.AddScoped<ReceiverService>();

        services.AddScoped<ICommandList, CommandList>();
        services.AddScoped<IOtherComand, OtherCommand>();


        services.AddScoped<MessageAction>();
        services.AddScoped<CallbackAction>();


        #region Команды для CALLBACK
        services.AddScoped<ICallbackHandler, CallbackAction>();
        services.AddScoped<ICallbackCommandHandler, TestCallBack>();
        #endregion

        services.AddHostedService<PollingService>();

       

    })
    .Build();

await host.RunAsync();