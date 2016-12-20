using System;
using Checklist.Core.Models;
using Checklist.Core.ViewModels;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using Checklist.Core.Converters;

namespace Checklist.iOS.Cells
{
	public partial class CheckListItemCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("CheckListItemCell");
		public static readonly UINib Nib;

		static CheckListItemCell()
		{
			Nib = UINib.FromName("CheckListItemCell", NSBundle.MainBundle);
		}

		protected CheckListItemCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
			this.SelectionStyle = UITableViewCellSelectionStyle.None;
			this.DelayBind(() =>
			{
				this.CreateBinding(CheckListTitleLabel).To((CheckListItem i) => i.Text).Apply();
				this.CreateBinding(CheckmarkSign).For(c => c.Hidden).To((CheckListItem i) => i.Done).WithConversion("Bool").Apply();
			});
		}
	}
}
