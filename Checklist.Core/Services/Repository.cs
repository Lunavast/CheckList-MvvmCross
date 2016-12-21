using System;
using System.Collections.Generic;
using System.Linq;
using Checklist.Core.Models;
using MvvmCross.Plugins.Sqlite;
using SQLite;

namespace Checklist.Core.Services
{

	public class Repository : IRepository
	{
		private readonly SQLiteConnection _connection;
		public Repository(IMvxSqliteConnectionFactory factory)
		{
			_connection = factory.GetConnection("checklist.sql");
			_connection.CreateTable<CheckListItem>();
			_connection.CreateTable<CheckList>();
		}

		public void Add(CheckListItem checkListItem)
		{
			_connection.Insert(checkListItem);
		}

		public void Delete(CheckListItem checkListItem)
		{
			_connection.Delete(checkListItem);
		}

		public void Update(CheckListItem checkListItem)
		{
			_connection.Update(checkListItem);
		}

		public CheckListItem GetItem(int id)
		{
			return _connection.Get<CheckListItem>(id);
		}

		public List<CheckList> AllCheckLists()
		{
			return _connection.Table<CheckList>().ToList();
		}

		public void Add(CheckList checkList)
		{
			_connection.Insert(checkList);
		}

		public void Delete(CheckList checkList)
		{
			foreach (CheckListItem item in this.GetCheckListItems(checkList)) 
			{
				_connection.Delete(item);
			}
			_connection.Delete(checkList);
		}

		public void Update(CheckList checkList)
		{
			_connection.Update(checkList);
		}

		public CheckList GetCheckList(int id)
		{
			return _connection.Get<CheckList>(id);
		}

		public List<CheckListItem> GetCheckListItems(CheckList checkList)
		{
			return _connection.Query<CheckListItem>("select * from CheckListItem where CheckListId = ?", checkList.Id).ToList();
		}

		public int GetToDoCountCheckListItems(CheckList checkList)
		{
			if (this.GetCheckListItems(checkList).Count == 0)
			{
				return -1;
			}
			else
			{
				return _connection.Query<CheckListItem>("select * from CheckListItem where CheckListId = ? and Done = 0", checkList.Id).ToList().Count;
			}
		}
	}
}
