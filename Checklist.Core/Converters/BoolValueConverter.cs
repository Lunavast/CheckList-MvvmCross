using System;
using MvvmCross.Platform.Converters;

namespace Checklist.Core.Converters
{
	public class BoolValueConverter : MvxValueConverter<bool, bool>
	{
		protected override bool Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return !value;
		}
	}
}
