using System;
using System.Windows.Input;
using Checklist.Core.Models;
using Checklist.Core.Services;
using MvvmCross.Core.ViewModels;

namespace Checklist.Core.ViewModels
{
	public class CheckListDetailViewModel : MvxViewModel
	{
		private Mode _mode;
		private readonly IDataService _dataService;
		public CheckListDetailViewModel(IDataService dataService)
		{
			_dataService = dataService;
		}
		
		public class Nav
		{
			public int CheckListId { get; set; }
		}
		
		public void Init(Nav navigation)
		{
			int id = navigation.CheckListId;
			if (id == -1)
			{
				_mode = Mode.Adding;
				Item = new CheckList();
				Title = "Add new checklist";
			}
			else
			{
				_mode = Mode.Editing;
				Item = _dataService.GetCheckList(id);
				Text = Item.Name;
				Title = "Edit checklist";
			}
		}

		private string _title;
		public string Title
		{
			get { return _title; }
			set { _title = value; RaisePropertyChanged(() => Title); }
		}

		public bool EnableDone
		{
			get { return !string.IsNullOrEmpty(Text); }
		}

		private string _text;
		public string Text
		{
			get { return _text; }
			set { _text = value; Item.Name = value; RaisePropertyChanged(() => Text); RaisePropertyChanged(() => EnableDone); }
		}

		private CheckList _item;
		public CheckList Item
		{
			get { return _item; }
			set { _item = value; RaisePropertyChanged(() => EnableDone); RaisePropertyChanged(() => Text); }
		}

		private MvxCommand _cancelCommand;
		public ICommand CancelCommand
		{
			get
			{
				_cancelCommand = _cancelCommand ?? new MvxCommand(DoCancel);
				return _cancelCommand;
			}
		}

		private void DoCancel()
		{
			Close(this);
		}

		private MvxCommand _doneCommand;
		public ICommand DoneCommand
		{
			get
			{
				_doneCommand = _doneCommand ?? new MvxCommand(DoDone);
				return _doneCommand;
			}
		}

		private void DoDone()
		{
			if (_mode == Mode.Adding)
			{
				_dataService.AddCheckList(Item);
			}
			else
			{
				_dataService.UpdateCheckList(Item);
			}
			Close(this);
		}
	}
}
