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
using System.IO;

namespace ChainLegth
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

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = File.ReadAllText(@"C:\INPUT.txt");
                string fileName = @"C:\OUTPUT.txt";
                var count = FindChain(text);
                var result = CountNumber(count);
                File.WriteAllText(fileName,result );

                MessageBox.Show("Done");
            }
            catch (Exception eq)
            {

                MessageBox.Show(eq.Message);
            }
        }
         private string CountNumber(int count)
         {
             string str = string.Empty;
             for (int i = 0; i < count; i++)
             {
                 str += 0;
             }
             return str;
         }
        private int FindChain(string text)
        {
            var c = 1;
            var maxSeq = 1;
            var max = 1;
            var arr = text.ToArray();
            var is0before = arr[0] == 48;
                
            while (c < arr.Length)
            {
                if (arr[c]==48)
                {
                    if (is0before)
                    {
                        max++;
                    }
                    is0before = true;
                }
                else
                {
                    is0before = false;
                    if (max > maxSeq)
                    {
                        maxSeq = max;
                    }
                    max = 1;
                }
                c++;
            }
            return maxSeq;
        }
    }
}
