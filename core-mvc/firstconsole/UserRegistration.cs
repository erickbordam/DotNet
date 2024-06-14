namespace firstconsole
{
    public class UserRegistration
    {
        private readonly IEmailSender _emailSender;

        public UserRegistration(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void RegisterUser(string email, string password)
        {
            Console.WriteLine($"User registered with email: {email}");
            _emailSender.SendEmail(email, "Welcome to our application!");
        }
    }
}