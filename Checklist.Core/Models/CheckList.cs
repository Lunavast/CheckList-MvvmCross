using System;
using System.Collections.Generic;
using SQLite;

namespace Checklist.Core.Models
{
	[Table("checklist")]
	public class CheckList
	{
		[PrimaryKey, AutoIncrement]
		public int Id { set; get; }

		public string Name { get; set; }
		public string IconName { get; set; }
		public int ToDo { get; set; }

		public CheckList()
		{
			this.ToDo = -1;
			this.IconName = "NoIcon";
		}
	}
}
