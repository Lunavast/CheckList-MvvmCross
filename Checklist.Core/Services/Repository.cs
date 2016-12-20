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
			_connection = factory.GetConnection("items.sql");
			_connection.CreateTable<CheckListItem>();
		}

		public void Add(CheckListItem checkListItem)
		{
			_connection.Insert(checkListItem);
		}

		public List<CheckListItem> All()
		{
			return _connection.Table<CheckListItem>().ToList();
		}

		public void Delete(CheckListItem checkListItem)
		{
			_connection.Delete(checkListItem);
		}

		public void Update(CheckListItem checkListItem)
		{
			_connection.Update(checkListItem);
		}

		public CheckListItem Get(int id)
		{
			return _connection.Get<CheckListItem>(id);
		}
	}
}
