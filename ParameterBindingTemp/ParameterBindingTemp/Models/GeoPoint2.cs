using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ParameterTemp.Models
{
    [TypeConverter(typeof (GeoPointConverter))]
    public class GeoPoint2
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static bool TryParse(string s, out GeoPoint2 result)
        {
            result = null;

            var parts = s.Split(',');
            if (parts.Length != 2)
            {
                return false;
            }

            double latitude, longitude;
            if (double.TryParse(parts[0], out latitude) &&
                double.TryParse(parts[1], out longitude))
            {
                result = new GeoPoint2() { Longitude = longitude, Latitude = latitude };
                return true;
            }
            return false;
        }
    }

    public class GeoPointConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                GeoPoint2 location;
                if (GeoPoint2.TryParse((string)value, out location))
                {
                    return location;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}