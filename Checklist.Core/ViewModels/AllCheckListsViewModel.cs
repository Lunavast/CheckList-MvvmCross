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
	public class AllCheckListsViewModel : MvxViewModel
	{
		private readonly IDataService _dataService;
		public IDataService DataService
		{
			get { return _dataService; }
		}
		private readonly MvxSubscriptionToken _token;

		private List<CheckList> _items;
		public List<CheckList> Items
		{
			get { return _items; }
			set { _items = value; RaisePropertyChanged(() => Items); }
		}

		public AllCheckListsViewModel(IDataService dataService, IMvxMessenger messenger)
		{
			_dataService = dataService;
			_items = _dataService.GetCheckListsList();
			_token = messenger.Subscribe<DataChangeMessage>(OnDataChange);
		}

		void OnDataChange(DataChangeMessage obj)
		{
			Items = _dataService.GetCheckListsList();
		}

		public ICommand PopItemCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<CheckListDetailViewModel>(new CheckListDetailViewModel.Nav()
				{
					Id = -1
				}));
			}
		}

		public ICommand EditItemCommand
		{
			get
			{
				return new MvxCommand<CheckList>(i => ShowViewModel<CheckListDetailViewModel>(new CheckListDetailViewModel.Nav()
				{
					Id = i.Id
				}));
			}
		}

		public ICommand ItemSelectedCommand
		{
			get
			{
				return new MvxCommand<CheckList>(i => ShowViewModel<CheckListViewModel>(new CheckListViewModel.Nav()
				{
					Id = i.Id
				}));
			}
		}

	}
}
