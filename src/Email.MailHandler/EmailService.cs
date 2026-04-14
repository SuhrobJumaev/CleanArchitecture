using Email.Interfaces;

namespace Email.MailHandler;

public class EmailService : IEmailService
{
	public Task SendAsync(string address, string subject, string body)
	{
		return Task.CompletedTask;
	}
}