using System;
using Checklist.Core.Models;
using Checklist.Core.ViewModels;
using Checklist.iOS.Cells;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace Checklist.iOS.Views
{
	public partial class AllCheckListsView : MvxViewController
	{
		public new AllCheckListsViewModel ViewModel
		{
			get { return (AllCheckListsViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public AllCheckListsView() : base("AllCheckListsView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			ConfigureNavigationView();
			ConfigureTableView();
		}

		private void ConfigureTableView()
		{
			var TableViewSource = new AllCheckListsSource(ViewModel, TableView, CheckListCell.Key, CheckListCell.Key);
			TableView.Source = TableViewSource;

			var set = this.CreateBindingSet<AllCheckListsView, AllCheckListsViewModel>();
			set.Bind(TableViewSource).To(vm => vm.Items);
			set.Bind(TableViewSource).For(s => s.SelectionChangedCommand).To(vm => vm.ItemSelectedCommand);
			set.Bind(TableViewSource).For(s => s.AccessoryTappedCommand).To(vm => vm.EditItemCommand);
			set.Apply();

			TableView.ReloadData();
		}

		private void ConfigureNavigationView()
		{
			this.Title = "Checklists";

			var PlusItem = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddItemHandler);
			this.NavigationItem.RightBarButtonItem = PlusItem;
		}

		void AddItemHandler(object sender, EventArgs e)
		{
			ViewModel.PopItemCommand.Execute(null);
		}

		private class AllCheckListsSource : MvxSimpleTableViewSource
		{
			private readonly AllCheckListsViewModel _vm;
			public AllCheckListsSource(AllCheckListsViewModel vm, UITableView tableView, string nibName, string cellIdentifier = null) : base(tableView, nibName, cellIdentifier)
			{
				_vm = vm;
			}

			public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			{
				CheckList item = _vm.Items[indexPath.Row];
				_vm.DataService.DeleteCheckList(item);
			}
		}
	}
}
