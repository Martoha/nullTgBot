using Telegram.Bot;
using Telegram.Bot.Types;

namespace null_tgbot.Commands
{
    public interface IOtherComand
	{
		Task ExecuteOtherCommandAsync(string commandName, long chatId, string userName, ITelegramBotClient botClient, Message msg);
	}
}
