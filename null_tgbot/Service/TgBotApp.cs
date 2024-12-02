using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot;

using Microsoft.Extensions.Logging;
using Telegram.Bot.Polling;
using null_tgbot.Service;



public class TgBotApp(ITelegramBotClient bot, ILogger<TgBotApp> logger, MessageAction _tgAction, CallbackAction _CallBackAction) : IUpdateHandler
{

	public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
	{
		var ErrorMessage = exception switch
		{
			ApiRequestException apiRequestException => $"Api Err:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
			_ => exception.ToString()
		};

		logger.LogInformation(ErrorMessage);
		return Task.CompletedTask;
	}

	public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
	{

		cancellationToken.ThrowIfCancellationRequested();
		await (update switch
		{
			{ Message: { } message } => OnMessage(message),
			//{ EditedMessage: { } message } => OnMessage(message),
			{ CallbackQuery: { } callbackQuery } => OnCallbackQuery(callbackQuery),

			_ => UnknownUpdateHandlerAsync(update)
		});

	}


	private async Task OnMessage(Message message)
	{

        logger.LogInformation($"{message.From!.Id} - {message.From.FirstName ?? ""} - {message.From.LastName ?? ""} - {message.From.Username ?? ""} - {message.Text}", message);

        switch (message)
        {
            case { Text: not null }:
                await _tgAction.ReadMsg(message, bot);
                break;
            default:
                return;
        }
    }

	private async Task OnCallbackQuery(CallbackQuery callbackQuery)
	{

		await _CallBackAction.HandleCallback(callbackQuery, bot);
	}

	private Task UnknownUpdateHandlerAsync(Update update)
	{
		logger.LogInformation("Неизвестный тип: {UpdateType}", update.Type);
		return Task.CompletedTask;
	}

	public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
	{
		logger.LogInformation("Ошибка : {Exception}", exception);

		if (exception is RequestException)
			await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
	}
}
