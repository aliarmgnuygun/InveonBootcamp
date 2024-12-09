namespace DIP.IdealCode
{
    public class NotificationService
    {
        private readonly INotificationProvider _notificationProvider;
        public NotificationService(INotificationProvider notificationProvider)
        {
            _notificationProvider = notificationProvider;
        }
        public void SendNotification(string message)
        {
            _notificationProvider.Send(message);
        }
    }
}
