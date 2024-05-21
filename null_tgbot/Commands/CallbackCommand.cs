using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace null_tgbot.Commands
{
    internal class CallbackCommand : ICallbackCommand
    {
        public async Task Test(ITelegramBotClient bk, CallbackQuery clq)
        {
            await bk.SendTextMessageAsync(clq.From.Id,  clq.Data ?? "null");
        }
    }
}
