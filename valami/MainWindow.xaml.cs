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

namespace valami
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> sorok = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            string[] lines = File.ReadAllLines("szamok.txt");
            foreach (var item in lines)
            {
                sorok.Add(item);
            }
        }

        private void btn1feladat_Click(object sender, RoutedEventArgs e)
        {
            List<int> szamOsztok = new List<int>();
            List<int> alandoOsztok = new List<int>();
            int allando = 1310438493;
            for(int x = 1; x < allando; x++)
            {
                alandoOsztok.Add(allando % x);
            }
            for (int i = 0; i < sorok.Count; i++){
                for (int j = 1; j < int.Parse(sorok[i]); j++)
                {
                    szamOsztok.Add(int.Parse(sorok[j]) % j);
                }
            }
            List<int> kozosOsztok = szamOsztok.Intersect(alandoOsztok).ToList();
            MessageBox.Show(kozosOsztok.Count.ToString());

        }
    }
}
