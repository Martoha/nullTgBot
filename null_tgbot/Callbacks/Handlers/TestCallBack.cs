using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Handlers
{
    public class TestCallBack : ICallbackCommandHandler
	{
		private readonly ILogger<TestCallBack> _logger;

		public TestCallBack( ILogger<TestCallBack> logger)
		{
			_logger = logger;
		}

		public string Command => "Test";

		public async Task HandleAsync(CallbackQuery clq, ITelegramBotClient bot)
		{
          
             await bot.AnswerCallbackQuery(clq.Id, "Тест", showAlert: true);
           
        }
	}
}
