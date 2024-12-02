namespace null_tgbot.Keyboard
{
    using Telegram.Bot.Types.ReplyMarkups;

    public static class Keyboards
	{
		public static ReplyKeyboardMarkup GetContact()
		{
			return new ReplyKeyboardMarkup(new[]
			{
                 new KeyboardButton("Это кнопка")
            })
			{
				ResizeKeyboard = true
			};
		}

	}

}
