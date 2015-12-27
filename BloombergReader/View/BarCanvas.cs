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

namespace BloombergReader.View
{
    // https://zamjad.wordpress.com/2009/09/21/creating-dotplot-in-wpf-using-c/
    // https://zamjad.wordpress.com/2010/03/18/creating-bar-graph-with-list-box/
    // https://zamjad.wordpress.com/2010/05/04/creating-bar-graph-with-list-box-revisited/
    // https://zamjad.wordpress.com/2011/11/27/creating-high-low-graph/


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
            SolidColorBrush solidColorBrush = new SolidColorBrush();
            solidColorBrush.Color = Colors.Black;
            Pen pen = new Pen(solidColorBrush, AxisThickness);
            pen.DashStyle = DashStyles.Solid;

            DrawСoordinateSystem(dc, solidColorBrush, pen);

            // draw all bars
            for (int i=0; i<Bars.Count; i++)
            {
                Bar bar = Bars[i];

                BarShape barShape = new BarShape(bar.Open, bar.High, bar.Low, bar.Close);
                // TODO: motherfucker
                dc.DrawGeometry(solidColorBrush, pen, barShape.MyGeometry);
            }

        }

        private void DrawСoordinateSystem(DrawingContext dc, SolidColorBrush solidColorBrush, Pen pen)
        {
            ArrowLine xAsix = DefineXAxis();
            ArrowLine yAsix = DefineYAxis();

            dc.DrawGeometry(solidColorBrush, pen, xAsix.DefiningGeometry);
            dc.DrawGeometry(solidColorBrush, pen, yAsix.DefiningGeometry);

            FormattedText priceText = new FormattedText(
                "Price",
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                AxisFontSize,
                solidColorBrush);

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
