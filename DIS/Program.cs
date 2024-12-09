#region Not Ideal Code
/*
using DIP.NotIdealCode;

NotificationService service = new();
service.SendNotification("Hotmail", "...");
service.SendNotification("Gmail", "...");
*/
#endregion

#region Ideal Code

using DIP.IdealCode;
NotificationService service = new(new HotmailService());
service.SendNotification("...");

service = new(new GmailService());
service.SendNotification("...");

#endregion