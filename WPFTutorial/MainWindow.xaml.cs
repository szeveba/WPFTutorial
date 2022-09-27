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

namespace WPFTutorial
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

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.WidthChanged) LBL_Width.Content = e.NewSize.Width;
            if (e.HeightChanged) LBL_Height.Content = e.NewSize.Height;
        }

        private void Window_GotMouseCapture(object sender, MouseEventArgs e)
        {

        }

        private void Window_QueryCursor(object sender, QueryCursorEventArgs e)
        {
            var point = e.GetPosition(this);
            LBL_CursorX.Content = point.X;
            LBL_CursorY.Content = point.Y;
        }

        private async void BTN_Calculating_Click(object sender, RoutedEventArgs e)
        {
            var calcResult = await Task.Run(UselessCalculating);
            MessageBox.Show(calcResult.ToString(), "Eredmény", MessageBoxButton.OK, MessageBoxImage.Information);
            var result = MessageBox.Show("Megismételjük?", "Számítás", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    BTN_Calculating_Click(sender, e);
                    break;
                    case MessageBoxResult.No:
                    MainWindow main2 = new MainWindow();
                    main2.Show();
                    break;
                default:
                    break;
            }
        }

        private decimal UselessCalculating()
        {
            decimal d = 0;
            for (int i = 0; i < 100000000; i++)
            {
                d += i;
            }
            return d;
        }

        private void BTN_Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TB_Text.Text))
            {
                LB_Text.Items.Add(TB_Text.Text);
                TB_Text.Clear();
            }
        }

        private void TB_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            BTN_Add.IsEnabled = !string.IsNullOrWhiteSpace(TB_Text.Text);
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            LB_Text.Items.Remove(LB_Text.SelectedItem);
            LB_Text.SelectedItem = null;
        }

        private void LB_Text_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BTN_Delete.IsEnabled = LB_Text.SelectedIndex != -1;
        }
    }
}
