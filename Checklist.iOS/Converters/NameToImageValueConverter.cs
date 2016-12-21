using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using UIKit;

namespace Checklist.iOS.Converters
{
	public class NameToImageValueConverter : MvxValueConverter<string, UIImage>
	{
		protected override UIImage Convert(string value, Type targetType, object parameter, CultureInfo culture)
		{
			var file = value;
			var image = UIImage.FromBundle(file);

			return image;
		}
	}
}
