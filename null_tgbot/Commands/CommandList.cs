using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace null_tgbot.Commands
{
    internal class CommandList : ICommandList
    {
        public async Task OtherComand(string text, long chatId, string userName, ITelegramBotClient bk, Message message)
        {


            await bk.SendTextMessageAsync(chatId, "Я не знаю - " + text);


        }

        public async Task Start(string commandName, long chatId, string userName, ITelegramBotClient bk, Message message)
        {
          
            Message instructionsMessage = await bk.SendTextMessageAsync(chatId, "Это /start");
        }
    }
}
