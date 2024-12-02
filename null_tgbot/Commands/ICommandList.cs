using Telegram.Bot.Types;
using Telegram.Bot;

namespace null_tgbot.Commands
{
    public interface ICommandList
	{
        Task Start(string command, long chatId, string userName, ITelegramBotClient botClient, Message message);
      
    }
}
