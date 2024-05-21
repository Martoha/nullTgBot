using System;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace null_tgbot
{
    internal class TgBotApp : TgAction
    {
        private TgActionCallBack _CallBack;

        public TgBotApp()
        {
            _CallBack = new TgActionCallBack();
        }


        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Api Err:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageReceived(botClient, update.Message!, cancellationToken),
                UpdateType.EditedMessage => BotOnMessageReceived(botClient, update.EditedMessage!, cancellationToken),
                UpdateType.CallbackQuery => BotOnCallbackQueryReceived(botClient, update.CallbackQuery!, cancellationToken),


                _ => UnknownUpdateHandlerAsync(botClient, update)
            };

            try
            {
                await handler;
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(botClient, exception, cancellationToken);
            }
        }

        private async Task BotOnMessageReceived(ITelegramBotClient bk, Message message, CancellationToken cancellationToken)
        {


            Console.WriteLine("{0} - {1} - {2} - {3}",
                message.From.FirstName,
                message.From.LastName,
                message.From.Username,
                message.Text);



            try
            {
                switch (message.Type.ToString())
                {
                    case "Text":
                        await ExecCommand(message.Text.ToUpper(), message.From.Id, message.From.Username!, bk, message);
                        break;
                    default:
                        await UnknownMessagesAsync(bk, message);
                        Console.WriteLine("Неизвестный тип сообшения");
                        break;
                }
            }
            catch (Exception e)
            {
                await HandleErrorAsync(bk, e, cancellationToken);
            }
        }


        private async Task BotOnCallbackQueryReceived(ITelegramBotClient botClient, CallbackQuery callbackQuery, CancellationToken cancellationToken)
        {
            try
            {
                 await _CallBack.execCallBackAsync(botClient, callbackQuery);
            }
            catch (Exception ex)
            {
                
                await HandleErrorAsync(botClient, ex, cancellationToken);
            }
        }

        private static Task UnknownUpdateHandlerAsync(ITelegramBotClient botClient, Update update)
        {
            //Console.WriteLine($"Unknown update type: {update.Id} - {update.Message} - {update.Message.Text} - {update.Type}");
            return Task.CompletedTask;
        }

        private static Task UnknownMessagesAsync(ITelegramBotClient botClient, Message message)
        {
            Console.WriteLine($"Unknown msg type: {message.Chat.Id} - {message.Chat.Username} - {message.Text} - {message.Type}");
            return Task.CompletedTask;
        }
    }
}