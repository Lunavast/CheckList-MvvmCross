using System;
using MvvmCross.Platform.Converters;

namespace Checklist.Core.Converters
{
	public class DueDateValueConverter : MvxValueConverter<DateTime?, string>
	{
		protected override string Convert(DateTime? value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value == null)
			{
				return "";
			}
			else
			{
				return value.ToString();
			}
		}
	}
}
