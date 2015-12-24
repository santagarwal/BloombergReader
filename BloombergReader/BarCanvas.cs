using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

using BloombergReader.Model;
using BloombergReader.ViewModel;
using BloombergReader.View.Shapes;
using System.Globalization;

namespace BloombergReader
{
    public class BarCanvas : Canvas
    {
        private const double AxisThickness = 1;
        private const double XShiftFromScreenBorder = 50;
        private const double YShiftFromScreenBorder = 50;
        private const double AxisFontSize = 16;

        public static readonly DependencyProperty BarsProperty = DependencyProperty.Register("Bars",
            typeof(ObservableCollection<Bar>), typeof(BarCanvas), new FrameworkPropertyMetadata(null, OnBarsChanged));

        public ObservableCollection<Bar> Bars
        {
            get { return (ObservableCollection<Bar>)GetValue(BarsProperty); }
            set { SetValue(BarsProperty, value); }
        }

        private static void OnBarsChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }
        
        protected override void OnRender(DrawingContext dc)
        {
            DrawСoordinateSystem(dc);

            // draw all bars
            for (int i=0; i<Bars.Count; i++)
            {
                Bar bar = Bars[i];

                // DrawBar(dc, i, 10, 10, bar);
            }
        }

        private void DrawСoordinateSystem(DrawingContext dc)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush();
            solidColorBrush.Color = Colors.Black;
            Pen pen = new Pen(solidColorBrush, AxisThickness);
            pen.DashStyle = DashStyles.Solid;
    
            FormattedText priceText = new FormattedText(
                "Price",
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                AxisFontSize,
                solidColorBrush);

            ArrowLine xAsix = DefineXAxis();
            ArrowLine yAsix = DefineYAxis();

            dc.DrawGeometry(solidColorBrush, pen, xAsix.DefiningGeometry);
            dc.DrawGeometry(solidColorBrush, pen, yAsix.DefiningGeometry);

            dc.DrawText(priceText, new Point(yAsix.X2 - priceText.Width / 2, yAsix.Y2 - priceText.Height));
        }

        private ArrowLine DefineYAxis()
        {
            ArrowLine yAsix = new ArrowLine();
            yAsix.ArrowEnds = ArrowEnds.End;
            yAsix.X1 = XShiftFromScreenBorder;
            yAsix.Y1 = ActualHeight - YShiftFromScreenBorder;
            yAsix.X2 = yAsix.X1;
            yAsix.Y2 = YShiftFromScreenBorder;
            return yAsix;
        }

        private ArrowLine DefineXAxis()
        {
            ArrowLine xAsix = new ArrowLine();
            xAsix.ArrowEnds = ArrowEnds.End;
            xAsix.X1 = XShiftFromScreenBorder;
            xAsix.Y1 = ActualHeight - YShiftFromScreenBorder;
            xAsix.X2 = ActualWidth - XShiftFromScreenBorder;
            xAsix.Y2 = xAsix.Y1;
            return xAsix;
        }
    }
}
