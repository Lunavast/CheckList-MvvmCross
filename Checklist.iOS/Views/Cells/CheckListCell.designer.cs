// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Checklist.iOS.Cells
{
	[Register ("CheckListCell")]
	partial class CheckListCell
	{
		[Outlet]
		UIKit.UIImageView ChecklistImageView { get; set; }

		[Outlet]
		UIKit.UILabel ChecklistTasksLabel { get; set; }

		[Outlet]
		UIKit.UILabel ChecklistTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ChecklistImageView != null) {
				ChecklistImageView.Dispose ();
				ChecklistImageView = null;
			}

			if (ChecklistTitle != null) {
				ChecklistTitle.Dispose ();
				ChecklistTitle = null;
			}

			if (ChecklistTasksLabel != null) {
				ChecklistTasksLabel.Dispose ();
				ChecklistTasksLabel = null;
			}
		}
	}
}
