using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Path = System.IO.Path;

namespace ParenthesisValidator
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
        // read file
        private void readFile(string file)
        {
            try
            {
                using (var reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        var data = reader.ReadLine();
                        string[] lines = data.Split(',');
                        foreach (string line in lines)
                        {
                            // add each line to the listbox
                            lbx_inputs.Items.Add(line);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file cannot be read.");
                Console.WriteLine(e.Message);
            }
        }

        private bool validate(string line)
        {
            // replace non - "()" characters with empty
            line = Regex.Replace(line,@"[a-z]?[A-Z]?\s?", "");
            // if orignial line contains no parathesis, return false
            if (line == "") return false;
            // eliminate valid parathesis
            while (line.Contains("()"))
            {
                line = line.Replace("()", "");
            }
            // if remaining is empty, return true, otherwise false
            if (line == "") return true;
            else return false;
        }

        private void Btn_read_Click(object sender, RoutedEventArgs e)
        {
            // find file path
            string path = txb_path.Text;
            string fileName = @path;
            lbx_inputs.Items.Clear();
            readFile(fileName);
        }

        private void Btn_validate_Click(object sender, RoutedEventArgs e)
        {
            lbx_results.Items.Clear();
            foreach(string line in lbx_inputs.Items)
            {
                if (validate(line))
                {
                    lbx_results.Items.Add("Valid");
                }
                else
                {
                    lbx_results.Items.Add("Not Valid");
                }
            }
        }
    }
}
