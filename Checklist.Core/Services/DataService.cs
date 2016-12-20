using System;
using System.Collections.Generic;
using Checklist.Core.Messenger;
using Checklist.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace Checklist.Core.Services
{

	public class DataService : IDataService
	{
		private readonly IRepository _repository;
		private readonly IMvxMessenger _messenger;

		public DataService(IRepository repository, IMvxMessenger messenger)
		{
			_repository = repository;
			_messenger = messenger;
		}

		public void AddItem(CheckListItem item)
		{
			_repository.Add(item);
			_messenger.Publish(new DataChangeMessage(this));
		}

		public void DeleteItem(CheckListItem item)
		{
			_repository.Delete(item);
			_messenger.Publish(new DataChangeMessage(this));
		}

		public void UpdateItem(CheckListItem item)
		{
			_repository.Update(item);
			_messenger.Publish(new DataChangeMessage(this));
		}

		public List<CheckListItem> GetItemsList()
		{
			return _repository.All();
		}

		public CheckListItem GetItem(int id)
		{
			return _repository.Get(id);
		}
	}
}
