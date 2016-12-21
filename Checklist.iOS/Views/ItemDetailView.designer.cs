// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Checklist.iOS.Views
{
	[Register ("ItemDetailView")]
	partial class ItemDetailView
	{
		[Outlet]
		UIKit.UIDatePicker DatePicker { get; set; }

		[Outlet]
		UIKit.UIView DateView { get; set; }

		[Outlet]
		UIKit.UILabel DueDateLabel { get; set; }

		[Outlet]
		UIKit.UISwitch ReminderSwitch { get; set; }

		[Outlet]
		UIKit.UITextField TextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DatePicker != null) {
				DatePicker.Dispose ();
				DatePicker = null;
			}

			if (DueDateLabel != null) {
				DueDateLabel.Dispose ();
				DueDateLabel = null;
			}

			if (ReminderSwitch != null) {
				ReminderSwitch.Dispose ();
				ReminderSwitch = null;
			}

			if (DateView != null) {
				DateView.Dispose ();
				DateView = null;
			}

			if (TextField != null) {
				TextField.Dispose ();
				TextField = null;
			}
		}
	}
}
