using System;
using Checklist.Core.Models;
using Checklist.Core.Services;
using Foundation;
using UIKit;
using Checklist.iOS.Extensions;

namespace Checklist.iOS.Services
{
	public class LocalNotificationService : ILocalNotificationService
	{
		public void RegisterNoifications()
		{
			var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
																		  new NSSet());
			UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
		}

		public void ScheduleNotification(CheckListItem item)
		{
			if (item.Reminder == null)
			{
				CancelNotification(item);
				return;
			}

			CancelNotification(item);
			var LocalNotification = new UILocalNotification()
			{
				FireDate = item.Reminder.Value.ToNSDate(),
				TimeZone = NSTimeZone.DefaultTimeZone,
				AlertBody = item.Text,
				SoundName = UILocalNotification.DefaultSoundName,
				UserInfo = new NSDictionary("ItemId", item.Id)
			};
			UIApplication.SharedApplication.ScheduleLocalNotification(LocalNotification);
		}

		private UILocalNotification NotificationForItem(CheckListItem item)
		{
			var AllNotifications = UIApplication.SharedApplication.ScheduledLocalNotifications;

			foreach (UILocalNotification notification in AllNotifications)
			{
				var number = notification.UserInfo["ItemId"] as NSNumber;
				if (number.Int32Value == item.Id)
				{
					return notification;
				}
			}
			return null;
		}

		public void CancelNotification(CheckListItem item)
		{
			var Notification = NotificationForItem(item);
			if (Notification != null)
			{
				UIApplication.SharedApplication.CancelLocalNotification(Notification);
			}
		}
	}
}
