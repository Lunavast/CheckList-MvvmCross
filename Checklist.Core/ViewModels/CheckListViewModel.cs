using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Checklist.Core.Messenger;
using Checklist.Core.Models;
using Checklist.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace Checklist.Core.ViewModels
{
	public class CheckListViewModel
		: MvxViewModel
	{
		private readonly IDataService _dataService;
		public IDataService DataService
		{
			get { return _dataService; }
		}
		private readonly MvxSubscriptionToken _token;

		private List<CheckListItem> _items;
		public List<CheckListItem> Items
		{
			get { return _items; }
			set { _items = value; RaisePropertyChanged(() => Items); }
		}

		public CheckListViewModel(IDataService dataService, IMvxMessenger messenger)
		{
			_dataService = dataService;
			_items = _dataService.GetItemsList();
			_token = messenger.Subscribe<DataChangeMessage>(OnDataChange);
		}

		void OnDataChange(DataChangeMessage obj)
		{
			Items = _dataService.GetItemsList();
		}

		public void AddItem(CheckListItem item)
		{
			_dataService.AddItem(item);
		}

		public void DeleteItem(CheckListItem item)
		{
			_dataService.DeleteItem(item);
		}

		public ICommand PopItemCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<ItemDetailViewModel>(new ItemDetailViewModel.Nav()
				{
					Id = -1
				}));
			}
		}

		public ICommand EditItemCommand
		{
			get
			{
				return new MvxCommand<CheckListItem>(i => ShowViewModel<ItemDetailViewModel>(new ItemDetailViewModel.Nav()
				{
					Id = i.Id
				}));
			}
		}

		public ICommand ItemSelectedCommand
		{
			get
			{
				return new MvxCommand<CheckListItem>(i =>
				{
					i.Done = !i.Done;
					_dataService.UpdateItem(i);
					Debug.WriteLine(i.Done);
				});
			}
		}
	}
}
