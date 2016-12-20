using System;
using Checklist.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace Checklist.iOS.Views
{
	public partial class CheckListDetailView : MvxViewController, IMvxModalIosView
	{
		public UIBarButtonItem CancelItem;
		public UIBarButtonItem DoneItem;

		public new CheckListDetailViewModel ViewModel
		{
			get { return (CheckListDetailViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public CheckListDetailView() : base("CheckListDetailView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			ConfigureNavigationView();

			TextField.BecomeFirstResponder();

			var set = this.CreateBindingSet<CheckListDetailView, CheckListDetailViewModel>();
			set.Bind(TextField).To(vm => vm.Text);
			set.Bind(DoneItem).For(b => b.Enabled).To(vm => vm.EnableDone);

			set.Apply();
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
			TextField.ResignFirstResponder();
			ViewModel.DoneCommand.Execute(null);
		}
	}
}

