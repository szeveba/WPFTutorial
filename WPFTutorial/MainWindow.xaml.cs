using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            if (e.HeightChanged) Label_Height.Content = e.NewSize.Height;
            if (e.WidthChanged) Label_Width.Content = e.NewSize.Width;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void BTN_Calculating_Click(object sender, RoutedEventArgs e)
        {
            var calcResult = await Task.Run(Calculating);
            var result = MessageBox.Show($"Számítás eredménye: {calcResult}\nMegismételjük?", "Eredmény", MessageBoxButton.YesNo, MessageBoxImage.Information);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    BTN_Calculating_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private int Calculating()
        {
            int x = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                x += i;
            }
            return x;
        }

        private void BTN_Text_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Text.Text != "")
            {
                LB_Text.Items.Add(TB_Text.Text);
                TB_Text.Clear();
            }
        }

        private void LB_Text_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TB_Text.Text = (string)LB_Text.SelectedItem;
            BTN_Save.IsEnabled = LB_Text.SelectedItem != null;
        }

        private void TB_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            BTN_Save.IsEnabled = !string.IsNullOrWhiteSpace(TB_Text.Text) && LB_Text.SelectedItem != null && (string)LB_Text.SelectedItem != TB_Text.Text;
        }

        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            LB_Text.Items[LB_Text.SelectedIndex] = TB_Text.Text;
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            LB_Text.Items.Remove(LB_Text.SelectedValue);
        }
    }
}
