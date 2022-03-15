using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.Task6
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string windDirection;
        private int windSpeed;
        private int precipitations;

        public int Precipitations
                    {
            get => precipitations;
            set => precipitations = value;
        }
        public enum Precipitation
        {
            солнечно,
            облачно,
            дождь,
            снег
        }
        public string WindDirection
        {
            get => windDirection;
            set => windDirection = value;
        }

        public int WindSpeed
        {
            get => windSpeed;
            set => windSpeed = value;
        }
               
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public WeatherControl(int temperature, string windDirection, int windSpeed, int precipitations)
        {
            this.Temperature = temperature;
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
            this.Precipitations = precipitations;
            var precipitation =(Precipitation)Precipitations;
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int) baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return 0;
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v <= 50 && v >= -50)
                return true;
            else
                return false;
        }
    }

}
