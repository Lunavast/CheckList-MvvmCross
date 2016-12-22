using System;
using Checklist.Core.Models;

namespace Checklist.Core.Services
{
	public interface ILocalNotificationService
	{
		void RegisterNoifications();

		void ScheduleNotification(CheckListItem item);

		void CancelNotification(CheckListItem item);
	}
	
}
