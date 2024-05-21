using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace null_tgbot
{
    internal class Program
    {
        private static TelegramBotClient? Bot;

        public static async Task Main()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

          

            TgBotApp app = new();


            //токен тут
            Bot = new TelegramBotClient("");

            User me = await Bot.GetMeAsync();
            Console.Title = me.Username!;

            using CancellationTokenSource? cts = new();

            ReceiverOptions receiverOptions = new() { AllowedUpdates = { } };
            Bot.StartReceiving(app.HandleUpdateAsync,
                               app.HandleErrorAsync,
                               receiverOptions,
                               cts.Token);

            Console.WriteLine($"Start  @{me.Username}");

            _ = Console.ReadLine();
            cts.Cancel();
        }
    }
}
