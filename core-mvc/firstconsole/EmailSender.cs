namespace firstconsole {
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string recipient, string message) { Console.WriteLine($"Email sent to {recipient}: {message}"); }
    }
}