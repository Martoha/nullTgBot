using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using null_tgbot.Callbacks;
using Handlers;



public class CallbackAction : ICallbackHandler
{
	private readonly IEnumerable<ICallbackCommandHandler> _handlers;
	private readonly ILogger<CallbackAction> _logger;

	public CallbackAction(IEnumerable<ICallbackCommandHandler> handlers, ILogger<CallbackAction> logger)
	{
		_handlers = handlers;
		_logger = logger;
	}

	public async Task HandleCallback(CallbackQuery callbackQuery, ITelegramBotClient bot)
	{
		if (callbackQuery == null || string.IsNullOrEmpty(callbackQuery.Data))
		{
			_logger.LogWarning("Получен пустой или некорректный CallbackQuery.");
			return;
		}

		var handler = _handlers.FirstOrDefault(h => h.Command == callbackQuery.Data);

		if (handler != null)
		{
			await handler.HandleAsync(callbackQuery, bot);
		}
		else
		{
			_logger.LogWarning("Неизвестная команда: {Command}", callbackQuery.Data);
		}
	}
}
