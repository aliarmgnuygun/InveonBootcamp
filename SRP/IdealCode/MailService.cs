namespace SRP.IdealCode
{
    public class MailService
    {
        public void SendMail(string email, string message)
        {
            // Send mail
            Console.WriteLine($"Mail sent to {email}\n Message is: {message}");

        }
    }
}
