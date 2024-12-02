using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace null_tgbot.Commands
{
	public class OtherCommand : IOtherComand
	{
		private readonly ICommandList _commandList;
		private readonly ILogger<OtherCommand> _logger;


		// Конструктор с инициализацией всех зависимостей
		public OtherCommand(ICommandList commandList, ILogger<OtherCommand> logger)
		{
			_commandList = commandList ?? throw new ArgumentNullException(nameof(commandList));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task ExecuteOtherCommandAsync(string commandName, long chatId, string userName, ITelegramBotClient botClient, Message msg)
		{
			#warning ТУТ написать
			await Task.CompletedTask;
        }
	}
}
