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
    /// longeraction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadNumbers_Click(object sender, RoutedEventArgs e)
        {
            List<string> numbers = LoadNumbersFromFile("szamok.txt");
            if (numbers != null)
            {
                List<string> anagrams = FindAnagrams("2354211341", numbers);
                foreach (string anagram in anagrams)
                {
                    numberListBox.Items.Add(anagram);
                }
                MessageBox.Show($"A fájlban {numberListBox.Items.Count} darab szám van amely a 2354211341-nek az anagrammája.");
            }
            else
            {
                MessageBox.Show("A szamok.txt fájl nem található vagy üres.");
            }
        }

        private List<string> LoadNumbersFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                return File.ReadAllLines(fileName).ToList();
            }
            return null;
        }

        private List<string> FindAnagrams(string targetNumber, List<string> numbers)
        {
            List<string> anagrams = new List<string>();
            foreach (string number in numbers)
            {
                if (IsAnagram(targetNumber, number))
                {
                    anagrams.Add(number);
                }
            }
            return anagrams;
        }

        private bool IsAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            char[] chars1 = str1.ToCharArray();
            char[] chars2 = str2.ToCharArray();

            Array.Sort(chars1);
            Array.Sort(chars2);

            for (int i = 0; i < str1.Length; i++)
            {
                if (chars1[i] != chars2[i])
                    return false;
            }

            return true;
        }
    }
}