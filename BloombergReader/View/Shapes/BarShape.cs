using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace BloombergReader.View.Shapes
{
    public class BarShape : Shape
    {
        private decimal _open; 
        private decimal _high; 
        private decimal _low;
        private decimal _close;

        protected PathGeometry _pathgeo;

        public BarShape(decimal open, decimal high, decimal low, decimal close)
        {
            _open = open;
            _high = high;
            _low = low;
            _close = close;

            _pathgeo = new PathGeometry();
        }

        protected override Geometry DefiningGeometry
        {
            
            get
            {
                var pathFigure = new PathFigure();
                var lineSegment1 = new LineSegment(new Point(150, 150), false);
                var lineSegment2 = new LineSegment(new Point(250, 250), true);
                
                pathFigure.Segments.Add(lineSegment1);
                pathFigure.Segments.Add(lineSegment2);
                _pathgeo.Figures.Add(pathFigure);

                return _pathgeo;
            }
        }

        
        public Geometry MyGeometry
        {
            get
            {
                return DefiningGeometry;
            }
        }
        

        protected override void OnRender(DrawingContext dc)
        {
            var solidColorBrush = new SolidColorBrush();
            solidColorBrush.Color = Colors.Black;

            var priceText = new FormattedText(
               "123456778990",
               CultureInfo.InvariantCulture,
               FlowDirection.LeftToRight,
               new Typeface("Verdana"),
               10,
               solidColorBrush);

            dc.DrawText(priceText, new Point(100, 200));

            //base.OnRender(dc);
        }
    }
}
