using Telegram.Bot.Types.ReplyMarkups;

namespace null_tgbot.Keyboard
{
    internal class InlineKeyboards
	{
		public static InlineKeyboardMarkup YesOrNo()
		{
			return new InlineKeyboardMarkup(new[]
			{
				InlineKeyboardButton.WithCallbackData("Yes", "Test"),
				InlineKeyboardButton.WithCallbackData("No", "Test")
			});
		}
	}
}