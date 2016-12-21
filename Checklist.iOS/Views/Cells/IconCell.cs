using System;
using Checklist.Core.Models;
using Checklist.iOS.Converters;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace Checklist.iOS.Cells
{
	public partial class IconCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("IconCell");
		public static readonly UINib Nib;

		static IconCell()
		{
			Nib = UINib.FromName("IconCell", NSBundle.MainBundle);
		}


		protected IconCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
			this.DelayBind(() =>
			{
				this.CreateBinding(IconNameLabel).To((Icon i) => i.Name).Apply();
				this.CreateBinding(IconImageView).To((Icon i) => i.Name).WithConversion("NameToImage").Apply();
			});
		}
	}
}
