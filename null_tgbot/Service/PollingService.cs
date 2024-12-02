
using Microsoft.Extensions.Logging;
using null_tgbot.Abstract;


namespace null_tgbot.Services;
public class PollingService : PollingServiceBase<ReceiverService>
{
	public PollingService(IServiceProvider serviceProvider, ILogger<PollingService> logger)
		: base(serviceProvider, logger)
	{
	}
}