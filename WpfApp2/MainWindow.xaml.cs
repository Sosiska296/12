using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32; 
using System.IO; 

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void ChangeTextColor_Click(object sender, RoutedEventArgs e)
        {
            string colorName = (sender as MenuItem).Tag.ToString();
            textBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(colorName);
        }

        private void ChangeFontFamily_Click(object sender, RoutedEventArgs e)
        {
            string fontFamily = (sender as MenuItem).Tag.ToString();
            textBox.FontFamily = new FontFamily(fontFamily);
        }

        private void ChangeFontSize_Click(object sender, RoutedEventArgs e)
        {
            string fontSizeStr = (sender as MenuItem).Tag.ToString();
            if (double.TryParse(fontSizeStr, out double fontSize))
            {
                textBox.FontSize = fontSize;
            }
        }

        private void ToggleBold_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight == FontWeights.Bold)
                textBox.FontWeight = FontWeights.Normal;
            else
                textBox.FontWeight = FontWeights.Bold;
        }

        private void ToggleItalic_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Italic)
                textBox.FontStyle = FontStyles.Normal;
            else
                textBox.FontStyle = FontStyles.Italic;
        }

        private void ToggleUnderline_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations == TextDecorations.Underline)
                textBox.TextDecorations = null;
            else
                textBox.TextDecorations = TextDecorations.Underline;
        }
    }
}
