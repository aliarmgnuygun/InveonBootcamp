namespace DIP.IdealCode
{
    public interface INotificationProvider
    {
        void Send(string message);
    }
    public class HotmailService : INotificationProvider
    {
        public void Send(string message)
        {
            Console.WriteLine($"Hotmail: {message}");
        }
    }

    public class GmailService : INotificationProvider
    {
        public void Send(string message)
        {
            Console.WriteLine($"Gmail: {message}");
        }
    }

    public class YandexService : INotificationProvider
    {
        public void Send(string message)
        {
            Console.WriteLine($"Yandex: {message}");
        }
    }

    public class MsnService : INotificationProvider
    {
        public void Send(string message)
        {
            Console.WriteLine($"MSN: {message}");
        }
    }
}
