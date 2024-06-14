namespace firstconsole
{
    public interface IEmailSender
    {
        
        void SendEmail(string recipient, string message);
    }
}