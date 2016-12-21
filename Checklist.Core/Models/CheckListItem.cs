using System;
using SQLite;

namespace Checklist.Core.Models
{
	[Table("checklistItem")]
	public class CheckListItem
	{
		[PrimaryKey, AutoIncrement]
		public int Id { set; get; }
		public int CheckListId { set; get; }

		public string Text { get; set; }
		public bool Done { get; set; }

		public DateTime? Reminder { get; set; }
	}
}
