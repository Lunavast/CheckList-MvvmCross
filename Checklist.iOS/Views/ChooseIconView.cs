using System;
using Checklist.Core.ViewModels;
using Checklist.iOS.Cells;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace Checklist.iOS.Views
{
	public partial class ChooseIconView : MvxViewController
	{
		public new ChooseIconViewModel ViewModel
		{
			get { return (ChooseIconViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public ChooseIconView() : base("ChooseIconView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			this.Title = "Choose Icon";

			ConfigureTableView();
		}

		private void ConfigureTableView()
		{
			var Source = new MvxSimpleTableViewSource(TableView, IconCell.Key, IconCell.Key);
			TableView.Source = Source;

			var set = this.CreateBindingSet<ChooseIconView, ChooseIconViewModel>();
			set.Bind(Source).To(vm => vm.Icons);
			set.Bind(Source).For(s => s.SelectionChangedCommand).To(vm => vm.ItemSelectedCommand);
			set.Apply();

			TableView.ReloadData();
		}
	}
}

