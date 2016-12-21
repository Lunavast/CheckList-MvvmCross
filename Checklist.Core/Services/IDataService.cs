using System;
using System.Collections.Generic;
using Checklist.Core.Models;

namespace Checklist.Core.Services
{
	public interface IDataService
	{
		void AddItem(CheckListItem item);
		void DeleteItem(CheckListItem item);
		void UpdateItem(CheckListItem item);
		CheckListItem GetItem(int id);

		List<CheckList> GetCheckListsList();

		void AddCheckList(CheckList checkList);
		void DeleteCheckList(CheckList checkList);
		void UpdateCheckList(CheckList checkList);
		CheckList GetCheckList(int id);

		List<CheckListItem> GetCheckListItems(CheckList checkList);
		int GetToDoCountCheckListItems(CheckList checkList);
	}

}
