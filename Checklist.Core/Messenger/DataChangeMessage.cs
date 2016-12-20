using System;
using MvvmCross.Plugins.Messenger;

namespace Checklist.Core.Messenger
{
	public class DataChangeMessage : MvxMessage
	{
		public DataChangeMessage(object sender) : base(sender)
		{
		}
	}
}
