using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Gevrek_Medya_Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //global elements
        bool menu_bar_state = true;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

        }


        private void animaMenuBar(int move_x)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = rectangleTransform.X;
            animation.To = move_x;
            animation.Duration = TimeSpan.FromSeconds(0.3);

            rectangleTransform.BeginAnimation(TranslateTransform.XProperty, animation);
        }
        //menu main functions
        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //menu bar set timer 
        private void menu_bar_timer(object sender, EventArgs e)
        {
            main_menu_btn.Visibility = Visibility.Visible;
            create_location_image_btn.Visibility = Visibility.Visible;
            create_template_btn.Visibility = Visibility.Visible;
            add_location_btn.Visibility = Visibility.Visible;
            add_image_btn.Visibility = Visibility.Visible;
            close_btn.Visibility = Visibility.Visible;
            minimize_btn.Visibility = Visibility.Visible;
            magnification_btn.Visibility = Visibility.Visible;
            menu_bar.Visibility = Visibility.Visible;
            timer.Stop();
        }
        private void menu_bar_active(object sender, RoutedEventArgs e)
        {
            if (menu_bar_state)
            {

                //menu btn animation

                DoubleAnimation animation = new DoubleAnimation();
                animation.From = menu_bar_btn_transform.X;
                animation.To = 350;
                animation.Duration = TimeSpan.FromSeconds(0.3);

                menu_bar_btn_transform.BeginAnimation(TranslateTransform.XProperty, animation);



                //menu background animation
                DoubleAnimation widthAnimation = new DoubleAnimation();
                widthAnimation.From = 764;
                widthAnimation.To = 66; // Yeni genişlik değeri
                widthAnimation.Duration = TimeSpan.FromSeconds(0.35); // Animasyon süresi

                title_bar_background.BeginAnimation(Border.WidthProperty, widthAnimation);

                //close buttons
                main_menu_btn.Visibility = Visibility.Hidden;
                create_location_image_btn.Visibility = Visibility.Hidden;
                create_template_btn.Visibility = Visibility.Hidden;
                add_location_btn.Visibility = Visibility.Hidden;
                add_image_btn.Visibility = Visibility.Hidden;
                close_btn.Visibility = Visibility.Hidden;
                minimize_btn.Visibility = Visibility.Hidden;
                magnification_btn.Visibility = Visibility.Hidden;
                menu_bar.Visibility = Visibility.Hidden;
                menu_bar_state = false;
            }
            else
            {
                //menu btn animation

                DoubleAnimation animation = new DoubleAnimation();
                animation.From = menu_bar_btn_transform.X;
                animation.To = 0;
                animation.Duration = TimeSpan.FromSeconds(0.3);

                menu_bar_btn_transform.BeginAnimation(TranslateTransform.XProperty, animation);



                //menu background animation
                DoubleAnimation widthAnimation = new DoubleAnimation();
                widthAnimation.From = 66;
                widthAnimation.To = 764; // Yeni genişlik değeri
                widthAnimation.Duration = TimeSpan.FromSeconds(0.35); // Animasyon süresi

                title_bar_background.BeginAnimation(Border.WidthProperty, widthAnimation);

                // DispatcherTimer'ı oluşturun
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(0.3);
                timer.Tick += menu_bar_timer;
                timer.Start();
                //close buttons

                menu_bar_state = true;
            }

        }




        //menu button click
        private void main_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            animaMenuBar(0);
        }

        private void create_location_image_btn_Click(object sender, RoutedEventArgs e)
        {
            animaMenuBar(-70);
        }

        private void create_template_btn_Click(object sender, RoutedEventArgs e)
        {
            animaMenuBar(-136);
        }

        private void add_location_btn_Click(object sender, RoutedEventArgs e)
        {
            animaMenuBar(67);
        }
        private void add_image_btn_Click(object sender, RoutedEventArgs e)
        {
            animaMenuBar(132);
        }




    }
}
