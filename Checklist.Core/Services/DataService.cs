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

		public CheckListItem GetItem(int id)
		{
			return _repository.GetItem(id);
		}

		public List<CheckList> GetCheckListsList()
		{
			return _repository.AllCheckLists();
		}

		public void AddCheckList(CheckList checkList)
		{
			_repository.Add(checkList);
			_messenger.Publish(new DataChangeMessage(this));
		}

		public void DeleteCheckList(CheckList checkList)
		{
			_repository.Delete(checkList);
			_messenger.Publish(new DataChangeMessage(this));
		}

		public void UpdateCheckList(CheckList checkList)
		{
			_repository.Update(checkList);
			_messenger.Publish(new DataChangeMessage(this));
		}

		public CheckList GetCheckList(int id)
		{
			return _repository.GetCheckList(id);
		}

		public List<CheckListItem> GetCheckListItems(CheckList checkList)
		{
			return _repository.GetCheckListItems(checkList);
		}

		public List<CheckListItem> GetToDoCheckListItems(CheckList checkList)
		{
			return _repository.GetToDoCheckListItems(checkList);
		}
	}
}
