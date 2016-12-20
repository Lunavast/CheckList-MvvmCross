using System;
using System.Collections.Generic;
using Checklist.Core.Models;

namespace Checklist.Core.Services
{
	public interface IDataService
	{
		List<CheckListItem> GetItemsList();

		void AddItem(CheckListItem item);
		void DeleteItem(CheckListItem item);
		void UpdateItem(CheckListItem item);

		CheckListItem GetItem(int id);
	}

}
