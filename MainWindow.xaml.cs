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
using System.Speech;
using System.Speech.Synthesis;

namespace SpeechRecog
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
        SpeechSynthesizer reader = new SpeechSynthesizer();
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.SelectAll();
            string myText = richTextBox.Selection.Text;
            if (myText != "")
            {

                reader.Dispose();
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(myText);
            }
            else
            {
                MessageBox.Show("Please enter some text");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(reader != null)
            {
                if (reader.State == SynthesizerState.Speaking)
                {
                    reader.Pause();
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Paused)
                {
                    reader.Resume();
                }
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (reader != null)
            {
                reader.Dispose();
            }
        }
    }
}
