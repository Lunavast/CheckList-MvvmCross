using System;
using Checklist.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace Checklist.Core.Messenger
{
	public class IconChangeMessage : MvxMessage
	{
		public Icon Icon { get; set; }
		public IconChangeMessage(object sender, Icon icon) : base(sender)
		{
			Icon = icon;
		}
	}
}
