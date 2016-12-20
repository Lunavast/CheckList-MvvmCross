using System;
using MvvmCross.Platform.Converters;

namespace Checklist.Core.Converters
{
	public class ItemsValueConverter : MvxValueConverter<int, string>
	{
		protected override string Convert(int value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return string.Format("{0} Remaining", value);
		}
	}
}
