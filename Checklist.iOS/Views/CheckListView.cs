using System;
using System.Collections.Generic;
using System.Diagnostics;
using Checklist.Core.Models;
using Checklist.Core.Services;
using Checklist.Core.ViewModels;
using Checklist.iOS.Cells;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace Checklist.iOS.Views
{
	public partial class CheckListView : MvxViewController
	{
		public new CheckListViewModel ViewModel
		{
			get { return (CheckListViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public CheckListView() : base("CheckListView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			ConfigureNavigationView();
			ConfigureTableView();
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			ViewModel.UpdateNewTasksCommand.Execute(null);
		}

		private void ConfigureTableView()
		{
			var TableViewSource = new CheckListSource(ViewModel, TableView, CheckListItemCell.Key, CheckListItemCell.Key);
			TableView.Source = TableViewSource;

			var set = this.CreateBindingSet<CheckListView, CheckListViewModel>();
			set.Bind(TableViewSource).To(vm => vm.Items);
			set.Bind(TableViewSource).For(s => s.SelectionChangedCommand).To(vm => vm.ItemSelectedCommand);
			set.Bind(TableViewSource).For(s => s.AccessoryTappedCommand).To(vm => vm.EditItemCommand);
			set.Apply();

			TableView.ReloadData();
		}

		private void ConfigureNavigationView()
		{
			this.Title = ViewModel.Title;
			
			var PlusItem = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddItemHandler);
			this.NavigationItem.RightBarButtonItem = PlusItem;
		}

		void AddItemHandler(object sender, EventArgs e)
		{
			ViewModel.PopItemCommand.Execute(null);
		}

		private class CheckListSource : MvxSimpleTableViewSource
		{
			private readonly CheckListViewModel _vm;
			public CheckListSource(CheckListViewModel vm, UITableView tableView, string nibName, string cellIdentifier = null) : base(tableView, nibName, cellIdentifier)
			{
				_vm = vm;
			}

			public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			{
				CheckListItem item = _vm.Items[indexPath.Row];
				_vm.DataService.DeleteItem(item);	
			}
		}
	}
}

