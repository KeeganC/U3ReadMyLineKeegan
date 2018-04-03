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

namespace U3ReadMyLine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //we need to add a reference
            // in solution explorere right click references and add reference, under assemblies check system.windows.Forms
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.ShowDialog();

            new System.IO.StreamReader(openFileDialog.FileName);

            //webclient to get info
            System.Net.WebClient webClient = new System.Net.WebClient();

            webClient.BaseAddress = "https://twitter.com/GuyFieri?ref_src=twsrc%5Egoogle%7Ctwcamp%5Eserp%7Ctwgr%5Eauthor";

            System.IO.StreamReader streamReader = new System.IO.StreamReader(openFileDialog.FileName);

            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("somefile.txt");

            try
            {
                while(!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    MessageBox.Show(line);
                    streamWriter.WriteLine(line);
                }
                streamWriter.Write(streamReader.ReadToEnd());
                streamWriter.Flush();
                streamWriter.Close();
                streamReader.Close();
                MessageBox.Show("I have read everything!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
            }
        }
    }
}