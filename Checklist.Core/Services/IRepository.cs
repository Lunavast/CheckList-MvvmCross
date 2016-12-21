using System;
using System.Collections.Generic;
using System.Linq;
using Checklist.Core.Models;
using SQLite;

namespace Checklist.Core.Services
{
	public interface IRepository
	{
		void Add(CheckListItem checkListItem);
		void Delete(CheckListItem checkListItem);
		void Update(CheckListItem checkListItem);
		CheckListItem GetItem(int id);

		List<CheckList> AllCheckLists();

		void Add(CheckList checkList);
		void Delete(CheckList checkList);
		void Update(CheckList checkList);
		CheckList GetCheckList(int id);

		List<CheckListItem> GetCheckListItems(CheckList checkList);
		int GetToDoCountCheckListItems(CheckList checkList);
	}
}
