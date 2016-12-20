using System;
using MvvmCross.Binding.BindingContext;
using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using Checklist.Core.Models;

namespace Checklist.iOS.Cells
{
	public partial class CheckListCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("CheckListCell");
		public static readonly UINib Nib;

		static CheckListCell()
		{
			Nib = UINib.FromName("CheckListCell", NSBundle.MainBundle);
		}

		protected CheckListCell(IntPtr handle) : base(handle)
		{
			this.SelectionStyle = UITableViewCellSelectionStyle.None;
			this.DelayBind(() =>
			{
				this.CreateBinding(TextLabel).To((CheckList l) => l.Name).Apply();
				this.CreateBinding(DetailTextLabel).To((CheckList l) => l.ToDo).WithConversion("Items").Apply();
			});
		}
	}
}
