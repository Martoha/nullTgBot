using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using null_tgbot.Commands;

namespace null_tgbot
{
    public class TgAction
    {

        public Dictionary<string, Delegate> commands;
        ICommandList commandList;

        public TgAction()
        {
            commandList = new CommandList();

            commands = new Dictionary<string, Delegate>
            {
                ["/START"] = new Func<string, long, string, ITelegramBotClient, Message, Task>(commandList.Start),

            };
        }

        public async Task ExecCommand(string commandName, long chatId, string userName, ITelegramBotClient bk, Message message)
        {
            if (message.Chat.Type == ChatType.Private)
            {
                // Проверка есть ли команда
                if (commands.ContainsKey(commandName))
                {
                    _ = commands[commandName].DynamicInvoke(commandName, chatId, userName, bk, message);
                }
                else
                {
                    // Прикрутить ответы потом
                    await commandList.OtherComand(commandName, chatId, userName, bk, message);
                }
            }
        }

    }
}