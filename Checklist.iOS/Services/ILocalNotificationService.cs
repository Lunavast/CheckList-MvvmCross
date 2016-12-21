using System;
using Checklist.Core.Models;
using Foundation;
using UIKit;

namespace Checklist.iOS.Services
{
	public interface ILocalNotificationService
	{
		void RegisterNoifications();

		void ScheduleNotification(CheckListItem item, NSDate time);

		UILocalNotification NotificationForItem(CheckListItem item);

		void CancelNotification(CheckListItem item);
	}
	
}
