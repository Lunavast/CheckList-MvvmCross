using System;
using Checklist.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;
using MvvmCross.Binding.BindingContext;
using Foundation;
using Checklist.iOS.Extensions;
using System.Diagnostics;
using Checklist.Core.Models;
using Checklist.iOS.Services;

namespace Checklist.iOS.Views
{
	public partial class ItemDetailView : MvxViewController, IMvxModalIosView
	{
		public UIBarButtonItem CancelItem;
		public UIBarButtonItem DoneItem;

		public new ItemDetailViewModel ViewModel
		{
			get { return (ItemDetailViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public ItemDetailView() : base("ItemDetailView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			BindView();
			ConfigureNavigationView();
			TextField.BecomeFirstResponder();

			if (ViewModel.Item.Reminder != null && ViewModel.Item.Reminder > DateTime.Now)
			{
				ReminderSwitch.On = true;
			}
			else 
			{
				ViewModel.Item.Reminder = null;
				DueDateLabel.Text = "";
			}
		}

		private void BindView()
		{
			var set = this.CreateBindingSet<ItemDetailView, ItemDetailViewModel>();
			set.Bind(TextField).To(vm => vm.Text);
			set.Bind(DoneItem).For(b => b.Enabled).To(vm => vm.EnableDone);
			set.Bind(DueDateLabel).To(vm => vm.Item.Reminder).WithConversion("DueDateValueConverter");
			set.Apply();

			ReminderSwitch.ValueChanged += ReminderSwitch_ValueChanged;
			DatePicker.ValueChanged += DatePicker_ValueChanged;
			TextField.EditingDidBegin += TextField_EditingDidBegin;
		}

		void ReminderSwitch_ValueChanged(object sender, EventArgs e)
		{
			new LocalNotificationService().RegisterNoifications();

			if (ReminderSwitch.On)
			{
				TextField.ResignFirstResponder();
			}
			else
			{
				TextField.BecomeFirstResponder();
			}


			DateView.Hidden = !ReminderSwitch.On;
			if (!ReminderSwitch.On)
			{
				DueDateLabel.Text = "";
				ViewModel.Item.Reminder = null;
			}
			else
			{
				ViewModel.Item.Reminder = DatePicker.Date.ToDateTime();
			}
		}

		void DatePicker_ValueChanged(object sender, EventArgs e)
		{
			TextField.ResignFirstResponder();
			DatePicker.MinimumDate = DateTime.Now.ToNSDate();
			ViewModel.Item.Reminder = DatePicker.Date.ToDateTime();
			DueDateLabel.Text = ViewModel.Item.Reminder.ToString();
		}

		void TextField_EditingDidBegin(object sender, EventArgs e)
		{
			DateView.Hidden = true;
		}

		private void ConfigureNavigationView()
		{
			this.Title = ViewModel.Title;

			CancelItem = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, CancelItemHandler);
			this.NavigationItem.LeftBarButtonItem = CancelItem;

			DoneItem = new UIBarButtonItem(UIBarButtonSystemItem.Done, DoneItemHandler);
			this.NavigationItem.RightBarButtonItem = DoneItem;
		}

		void CancelItemHandler(object sender, EventArgs e)
		{
			TextField.ResignFirstResponder();
			ViewModel.CancelCommand.Execute(null);
		}

		void DoneItemHandler(object sender, EventArgs e)
		{
			new LocalNotificationService().ScheduleNotification(ViewModel.Item, DatePicker.Date);
			TextField.ResignFirstResponder();
			ViewModel.DoneCommand.Execute(null);
		}
	}
}