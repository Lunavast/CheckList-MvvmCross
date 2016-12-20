using System;
using SQLite;

namespace Checklist.Core.Models
{
	public class CheckListItem
	{
		[PrimaryKey, AutoIncrement]
		public int Id { set; get; }

		public string Text
		{
			get;
			set;
		}

		public bool Done
		{
			get;
			set;
		}

		public CheckListItem()
		{
		}
	}
}
