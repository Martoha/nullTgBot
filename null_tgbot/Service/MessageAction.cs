using null_tgbot.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace null_tgbot.Service
{
    public class MessageAction
	{
		private readonly Dictionary<string, Delegate> commands;
		private readonly ICommandList commandList;
		private IOtherComand _otherCommand;


		public MessageAction(ICommandList commandList, IOtherComand otherCommand)
		{
			this.commandList = commandList;
			_otherCommand = otherCommand;


			commands = new Dictionary<string, Delegate>
			{
				["/start"] = new Func<string, long, string, ITelegramBotClient, Message, Task>(commandList.Start),

            };
		}

		public async Task ReadMsg(Message msg, ITelegramBotClient botClient)
		{
			if (msg.Text is not { } commandName)
				return;

			string userName = msg.From?.Username ?? msg.From?.FirstName ?? "" + msg.From?.LastName ?? ""; 
			long chatId = msg.Chat.Id; // ID чата


			if (commands.TryGetValue(commandName, out var matchedCommand))
			{
				var command = matchedCommand as Func<string, long, string, ITelegramBotClient, Message, Task>;
				if (command != null)
				{
					await command.Invoke(commandName, chatId, userName, botClient, msg);
				}
				else
				{
					throw new InvalidOperationException($"Команда '{commandName}' не зарегистрирована");
				}
			}
			else
			{
				//Обработка сообшений из чата
				await _otherCommand.ExecuteOtherCommandAsync(commandName, chatId, userName, botClient, msg);
			}
		}

    }
}
