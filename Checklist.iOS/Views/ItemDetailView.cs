using System;
using Checklist.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;
using MvvmCross.Binding.BindingContext;

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
		}

		private void BindView()
		{
			var set = this.CreateBindingSet<ItemDetailView, ItemDetailViewModel>();
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

