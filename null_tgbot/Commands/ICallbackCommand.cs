using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace null_tgbot.Commands
{
    internal interface ICallbackCommand
    {
        Task Test(ITelegramBotClient bk, CallbackQuery clq);
    }
}
