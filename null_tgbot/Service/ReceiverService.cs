using Microsoft.Extensions.Logging;
using null_tgbot.Abstract;
using Telegram.Bot;

namespace null_tgbot
{
	public class ReceiverService(ITelegramBotClient botClient, TgBotApp updateHandler, ILogger<ReceiverServiceBase<TgBotApp>> logger)
	: ReceiverServiceBase<TgBotApp>(botClient, updateHandler, logger);
}
