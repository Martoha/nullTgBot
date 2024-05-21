using System.Xml.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace null_tgbot
{
    internal class TgActionCallBack
    {
        public async Task execCallBackAsync(ITelegramBotClient bk, CallbackQuery clq)
        {
            var dataQ = clq.Data switch
            {
                "data"  => Task.FromResult(0),
                _ => Task.CompletedTask
            };

            await dataQ;
        }
    }
}