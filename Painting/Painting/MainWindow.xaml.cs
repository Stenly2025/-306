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

namespace Painting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Brush curbrush = Brushes.Black;
        double widgh = 10;
        double height = 10;
        bool ErMode = false;


        private void Field_MouseMove(object sender, MouseEventArgs e)
        {
            if (ErMode == false && Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Point position = Mouse.GetPosition(Field);
                Ellipse ellipse = new Ellipse();

                ellipse.Width = widgh;
                ellipse.Height = height;
                ellipse.Fill = curbrush;
                ellipse.Margin = new Thickness(position.X, position.Y, 0, 0);
                ellipse.MouseEnter += Erase;

                Field.Children.Add(ellipse);
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            curbrush = rect.Fill;
            ErMode = false;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Field.Children.Clear();
            Image img1 = (Image)sender;
            Image img2 = new Image();
            img2.Source = img1.Source;
            img2.Width = Field.Width;
            img2.Height = Field.Height;

            Field.Children.Add(img2);
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;
            widgh = ellipse.Width;
            height = ellipse.Height;
        }

        private void Erase(object sender, MouseEventArgs e)
        {

            Ellipse  ell = (Ellipse)sender;
            if (ErMode == true && Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Field.Children.Remove(ell);
            }
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ErMode = true;
        }
    }
}
