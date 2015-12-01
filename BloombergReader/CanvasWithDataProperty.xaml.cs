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

namespace BloombergReader
{
    /// <summary>
    /// Interaction logic for CanvasWittDataProperty.xaml
    /// </summary>
    public partial class CanvasWithDataProperty : UserControl
    {
        public CanvasWithDataProperty()
        {
            InitializeComponent();
        }

        public int YearPublished
        {
            get { return (int)GetValue(YearPublishedProperty); }
            set { SetValue(YearPublishedProperty, value); }
        }

        public static readonly DependencyProperty
           YearPublishedProperty = DependencyProperty.Register(
              "YearPublished", typeof(int), typeof(CanvasWithDataProperty),
              new UIPropertyMetadata(2000));

    }
}
