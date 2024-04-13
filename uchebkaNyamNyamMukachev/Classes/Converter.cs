using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public class Converter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is BitmapImage bitmapImage)
        {
            BitmapSource source = bitmapImage as BitmapSource;
            FormatConvertedBitmap grayscaleBitmap = new FormatConvertedBitmap();
            grayscaleBitmap.BeginInit();
            grayscaleBitmap.Source = source;
            grayscaleBitmap.DestinationFormat = PixelFormats.Gray32Float;
            grayscaleBitmap.EndInit();
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}