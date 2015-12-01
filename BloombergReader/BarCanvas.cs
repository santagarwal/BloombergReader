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

namespace BloombergReader
{
    // http://www.anotherearlymorning.com/example/Makotoro/DynamicCanvas.html
    // http://www.codeproject.com/Articles/139216/A-Simple-Technique-for-Data-binding-to-the-Positio

    //http://techbus.safaribooksonline.com/book/programming/microsoft-wpf/9781849686228/1dot-foundations/id286723836?query=((Dependency+property))#snippet

    public class BarCanvas : Canvas
    {
        /*
        public static readonly DependencyProperty IsSpinningProperty = DependencyProperty.Register("IsSpinning", 
            typeof(Boolean), typeof(Boolean));

        public bool IsSpinning
        {
            get { return (bool)GetValue(IsSpinningProperty); }
            set { SetValue(IsSpinningProperty, value); }
        }
         */


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

        public BarCanvas()
        {
            /*
            foreach (var item in Bars)
            {
                MessageBox.Show(item.Open.ToString());
            }
             */
        }

        protected override void OnRender(DrawingContext dc)
        {
            for (int i=0; i<Bars.Count; i++)
            {
                Bar bar = Bars[i];

                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Colors.LimeGreen;
                Pen myPen = new Pen(Brushes.Blue, 1);

                Point p1 = new Point(i * 10 + 10, (double)bar.Open);
                Point p2 = new Point(i * 10 + 10, (double)bar.Close);

                dc.DrawLine(myPen, p1, p2);
            }
        }
    }
}
