namespace DIP.NotIdealCode
{
    public class NotificationService
    {
        public void SendNotification(string provider, string message)
        {
            if (provider == "Hotmail")
            {
                var hotmail = new HotmailService();
                hotmail.Send(message);
            }
            else if (provider == "Gmail")
            {
                var gmail = new GmailService();
                gmail.Send(message);
            }
            else if (provider == "Yandex")
            {
                var yandex = new YandexService();
                yandex.Send(message);
            }
            else if (provider == "MSN")
            {
                var msn = new MsnService();
                msn.Send(message);
            }
            else
            {
                Console.WriteLine("Invalid provider.");
            }
        }
    }

    public class HotmailService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Hotmail: {message}");
        }
    }

    public class GmailService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Gmail: {message}");
        }
    }

    public class YandexService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Yandex: {message}");
        }
    }

    public class MsnService
    {
        public void Send(string message)
        {
            Console.WriteLine($"MSN: {message}");
        }
    }
}
