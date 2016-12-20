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
	[Register ("CheckListItemCell")]
	partial class CheckListItemCell
	{
		[Outlet]
		UIKit.UILabel CheckListTitleLabel { get; set; }

		[Outlet]
		UIKit.UILabel CheckmarkSign { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CheckListTitleLabel != null) {
				CheckListTitleLabel.Dispose ();
				CheckListTitleLabel = null;
			}

			if (CheckmarkSign != null) {
				CheckmarkSign.Dispose ();
				CheckmarkSign = null;
			}
		}
	}
}
