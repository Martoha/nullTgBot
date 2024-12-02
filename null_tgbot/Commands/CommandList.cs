
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using null_tgbot.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace null_tgbot.Commands
{
    public class CommandList : ICommandList
	{

        public async Task Start(string command, long chatId, string userName, ITelegramBotClient botClient, Message message)
		{

            var keyboard = new InlineKeyboardMarkup(new[]
               {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("TEST.", callbackData:"Test")

                    },
                   
                });

            await botClient.SendMessage(
                   chatId: chatId,
                   text: BotMessages.StartMessage,
                   parseMode: ParseMode.Html,
                   replyMarkup: keyboard
               );
        }

      
    }
}
