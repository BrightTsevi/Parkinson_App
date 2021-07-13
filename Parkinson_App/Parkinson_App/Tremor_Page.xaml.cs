using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Accord;
using System.Numerics;
using SkiaSharp;


namespace Parkinson_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tremor_Page : ContentPage
    {
        SensorSpeed speed = SensorSpeed.UI;
        public Tremor_Page()
        {
            InitializeComponent();

        }

        private void Start_Clicked(object sender,  EventArgs e)
        {
            if (!Accelerometer.IsMonitoring)
            {
                Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
                Accelerometer.Start(speed);
            }
            else
            {
                Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            }
        }
        List<float> x_vals = new List<float>();
        List<float> y_vals = new List<float>();
        List<float> z_vals = new List<float>();
        public string Label { get; private set; }
        public float ValueLabel { get; private set; }
        public Color Color { get; private set; }

        public void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            x_acc.Text = $"X: {e.Reading.Acceleration.X} ";
            y_acc.Text = $"X: {e.Reading.Acceleration.Y} ";
            z_acc.Text = $"X: {e.Reading.Acceleration.Z} ";
            x_vals.Add(e.Reading.Acceleration.X);
            y_vals.Add(e.Reading.Acceleration.X);
            z_vals.Add(e.Reading.Acceleration.X);

        }





        private void Stop_Clicked(object sender, EventArgs e)
        {
            
            if (Accelerometer.IsMonitoring)
            {
                Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                Accelerometer.Stop();
            }

            

            List<Microcharts.ChartEntry> source_x = new List<Microcharts.ChartEntry>();
            foreach(float p in x_vals)
            {
                source_x.Add(new Microcharts.ChartEntry(p)
                {
                    Label = p.ToString(),
                    ValueLabel = "",
                    Color = SKColor.Parse("#00CED1")

                });
            }
            List<Microcharts.ChartEntry> source_y = new List<Microcharts.ChartEntry>();
            foreach (float p in y_vals)
            {
                source_y.Add(new Microcharts.ChartEntry(p)
                {
                    Label = p.ToString(),
                    ValueLabel = "",
                    Color = SKColor.Parse("#FF1943")
                });
            }
            List<Microcharts.ChartEntry> source_z = new List<Microcharts.ChartEntry>();
            foreach (float p in z_vals)
            {
                source_z.Add(new Microcharts.ChartEntry(p)
                {
                    Label = p.ToString(),
                    ValueLabel = "",
                    Color = SKColor.Parse("#00BFFF")
                });
            }

            LineChart_X.Chart = new LineChart() { Entries = source_x };
            LineChart_Y.Chart = new LineChart() { Entries = source_y };
            LineChart_Z.Chart = new LineChart() { Entries = source_z };

        }

    }
}