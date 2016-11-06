using System.Drawing;
using System.Windows;
using SolarSystem.ObjectsInSpace;

namespace Visualization
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Sun sun = new Sun(332940, new Point(350, 400), 10);
            InitializeComponent();
        }
    }
}
