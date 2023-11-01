using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = getColorList();
        }

        private MyColor[] getColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var mycolor = (MyColor)((ComboBox)sender).SelectedItem;
            var color = mycolor.Color;
            var name = mycolor.Name;
            rValue.Text = mycolor.Color.R.ToString();
            gValue.Text = mycolor.Color.G.ToString();
            bValue.Text = mycolor.Color.B.ToString();

        }

        private void rgbSlider_ValueChenged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            Color c = Color.FromRgb((byte)rSlider.Value,(byte)gSlider.Value,(byte)bSlider.Value);
            SolidColorBrush brush = new SolidColorBrush(c);
            colorArea.Background = brush;
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            if () {

            }
            else {
                stockList.Items.Insert(0, "R:　"+ rValue.Text + "　G:　" + gValue.Text + "　B:　" + bValue.Text);
            }
            

            
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            string[] split = stockList.SelectedItem.ToString().Split('　');
            rValue.Text = split[1];
            gValue.Text = split[3];
            bValue.Text = split[5];
        }
    }
}
public class MyColor {
    public Color Color { get; set; }
    public string Name { get; set; }
}
