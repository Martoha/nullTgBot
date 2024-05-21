using null_tgbot.Commands;
using System.Xml.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace null_tgbot
{
    internal class TgActionCallBack
    {
        ICallbackCommand clData = new CallbackCommand();

        public async Task execCallBackAsync(ITelegramBotClient bk, CallbackQuery clq)
        {
            var dataQ =  clq.Data switch
            {
                "data" =>  clData.Test(bk, clq),
            };

            await dataQ;
        }

       
    }
}