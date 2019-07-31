using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Pos2Web
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        private static T mConverter = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (mConverter == null)
                mConverter = new T();

            return mConverter ?? (mConverter = new T());
        }

        #region ValueConverterMethods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
        #endregion
    }
}
