using System.Globalization;
using System.Windows.Data;

namespace To_Doodles;

public class WidthMinusMarginConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double width && parameter is string margin && double.TryParse(margin, out double marginValue))
        {
            return Math.Max(0, width - marginValue);
        }
        return value!;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}