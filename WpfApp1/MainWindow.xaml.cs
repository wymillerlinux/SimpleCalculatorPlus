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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private bool Validate()
        {

            if (radbtn_metric.IsChecked == false && radbtn_engkish.IsChecked == false)
            {
                MessageBox.Show("Please select a unit of measure.");
                radbtn_engkish.IsChecked = true;
                return false;
            }

            if (txtbox_length.Text == "")
            {
                MessageBox.Show("Please enter an integer in the length box.");
                return false;
            }

            if (txtbox_width.Text == "")
            {
                MessageBox.Show("Please enter an integer in the width box.");
                return false;
            }

            return true;
        }

        private void btn_help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.ShowDialog();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void radbtn_metric_Checked(object sender, RoutedEventArgs e)
        {
            if (radbtn_metric.IsChecked == true)
            {
                lbl_width.Content = "Width (m)";
                lbl_length.Content = "Length (m)";
            }
        }

        private void radbtn_engkish_Checked(object sender, RoutedEventArgs e)
        {
            if (radbtn_engkish.IsChecked == true)
            {
                lbl_width.Content = "Width (ft)";
                lbl_length.Content = "Length (ft)";
            }
        }

        private void btn_calc_Click(object sender, RoutedEventArgs e)
        {
                bool isValidated = Validate();
                if (isValidated)
                {
                    int x = Convert.ToInt32(txtbox_length.Text);
                    int y = Convert.ToInt32(txtbox_width.Text);
                    int answer = 2*(x * y);
                    if (radbtn_engkish.IsChecked == true)
                    {
                        CalculateWindow calc = new CalculateWindow(answer, "feet");
                        calc.ShowDialog();
                    }
                    if (radbtn_metric.IsChecked == true)
                    {
                        CalculateWindow calc = new CalculateWindow(answer, "meters");
                        calc.ShowDialog();
                    }

            }
        }
    }
}
