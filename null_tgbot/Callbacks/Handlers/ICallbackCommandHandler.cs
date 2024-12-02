
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Handlers
{
	public interface ICallbackCommandHandler
	{
		
		string Command { get; }
		Task HandleAsync(CallbackQuery callbackQuery, ITelegramBotClient bot);
	}

}
