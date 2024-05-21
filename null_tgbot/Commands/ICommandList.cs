using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace null_tgbot.Commands
{
    internal interface ICommandList
    {
        Task OtherComand(string commandName, long chatId, string userName, ITelegramBotClient bk, Message message);
        Task Start(string commandName, long chatId, string userName, ITelegramBotClient bk, Message message);
    }
}
