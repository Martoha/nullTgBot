using Telegram.Bot;
using Telegram.Bot.Types;

namespace null_tgbot.Callbacks
{
    public interface ICallbackHandler
	{
		Task HandleCallback(CallbackQuery callbackQuery, ITelegramBotClient bot);
	}

}
