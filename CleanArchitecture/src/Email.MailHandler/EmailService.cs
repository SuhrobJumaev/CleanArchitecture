using Email.Interfaces;

namespace Email.MailHandler;

public class EmailService : IEmailService
{
	public Task SendAsync(string address, string subject, string body)
	{
		Console.WriteLine($"Sending email to {address} with subject {subject} and body {body}");
		Console.Out.Flush();
		return Task.CompletedTask;
	}
}