using System;
using System.Collections.Generic;
using System.Windows.Input;
using Checklist.Core.Models;
using Checklist.Core.Services;
using Checklist.Core.Messenger;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace Checklist.Core.ViewModels
{
	
	public class ChooseIconViewModel : MvxViewModel
	{
		private List<Icon> _icons;
		public List<Icon> Icons
		{
			get { return _icons; }
			set { _icons = value; RaisePropertyChanged(() => Icons); }
		}

		private readonly IDataService _dataService;
		private readonly IMvxMessenger _messenger;
		public ChooseIconViewModel(IDataService dataService, IMvxMessenger messenger)
		{
			_dataService = dataService;
			_messenger = messenger;
			Icons = new List<Icon>()
			{
				new Icon("NoIcon"),
				new Icon("Appointments"),
				new Icon("Birthdays"),
				new Icon("Chores"),
				new Icon("Drinks"),
				new Icon("Folder"),
				new Icon("Groceries"),
				new Icon("Inbox"),
				new Icon("Photos"),
				new Icon("Trips")
			};
		}

		public ICommand ItemSelectedCommand
		{
			get
			{
				return new MvxCommand<Icon>(i =>
				{
					_messenger.Publish(new IconChangeMessage(this, i));
					Close(this);
				});
			}
		}
	}
}
