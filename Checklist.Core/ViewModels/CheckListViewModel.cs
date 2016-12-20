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

		public class Nav
		{
			public int Id { get; set; }
		}

		public void Init(Nav navigation)
		{
			int id = navigation.Id;
			_checkList = DataService.GetCheckList(id);
			Title = _checkList.Name;
			if (_checkList != null)
				Items = DataService.GetCheckListItems(_checkList);
		}

		private string _title;
		public string Title
		{
			get { return _title; }
			set { _title = value; RaisePropertyChanged(() => Title); }
		}

		private CheckList _checkList;

		private List<CheckListItem> _items;
		public List<CheckListItem> Items
		{
			get { return _items; }
			set { _items = value; RaisePropertyChanged(() => Items); }
		}
		private readonly MvxSubscriptionToken _token;

		public CheckListViewModel(IDataService dataService, IMvxMessenger messenger)
		{
			_dataService = dataService;
			_token = messenger.Subscribe<DataChangeMessage>(OnDataChange);
		}

		void OnDataChange(DataChangeMessage obj)
		{
			Items = _dataService.GetCheckListItems(_checkList);
		}

		public ICommand PopItemCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<ItemDetailViewModel>(new ItemDetailViewModel.Nav()
				{
					Id = -1,
					CheckListId = _checkList.Id
				}));
			}
		}

		public ICommand EditItemCommand
		{
			get
			{
				return new MvxCommand<CheckListItem>(i => ShowViewModel<ItemDetailViewModel>(new ItemDetailViewModel.Nav()
				{
					Id = i.Id,
					CheckListId = _checkList.Id
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
					DataService.UpdateItem(i);
				});
			}
		}

		private MvxCommand _updateNewTasksCommand;
		public ICommand UpdateNewTasksCommand
		{
			get
			{
				_updateNewTasksCommand = _updateNewTasksCommand ?? new MvxCommand(DoUpdateNewTasks);
				return _updateNewTasksCommand;
			}
		}

		private void DoUpdateNewTasks()
		{
			_checkList.ToDo = DataService.GetToDoCheckListItems(_checkList).Count;
			DataService.UpdateCheckList(_checkList);
		}
	}
}
