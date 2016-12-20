using System;
using System.Collections.Generic;
using System.Linq;
using Checklist.Core.Models;
using MvvmCross.Plugins.Sqlite;
using SQLite;

namespace Checklist.Core.Services
{
	public interface IRepository
	{
		List<CheckListItem> All();
		void Add(CheckListItem checkListItem);
		void Delete(CheckListItem checkListItem);
		void Update(CheckListItem checkListItem);

		CheckListItem Get(int id);
	}

	
}
