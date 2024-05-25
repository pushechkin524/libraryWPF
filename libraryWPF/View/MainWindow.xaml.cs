using libraryWPF.Model;
using libraryWPF.ViewModel;
using Microsoft.Win32;
using System;
using System.Windows;
using WpfLibrary1;

namespace libraryWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void SerializeToXmlButton_Click(object sender, RoutedEventArgs e)
        {
            var person = new Person
            {
                Name = NameTextBox.Text,
                Age = AgeTextBox.Text
            };

            string xml = Serializer.SerializeToXml(person);
            OutputTextBox.Text = xml;
        }

        private void DeserializeFromXmlButton_Click(object sender, RoutedEventArgs e)
        {
            var xml = OutputTextBox.Text;
            var person = Serializer.DeserializeFromXml<Person>(xml);
            NameTextBox.Text = person.Name;
            AgeTextBox.Text = person.Age;
        }


        private void DeserializeFromJsonButton_Click(object sender, RoutedEventArgs e)
        {
            var json = OutputTextBox.Text;
            var person = Serializer.DeserializeFromJson<Person>(json);
            NameTextBox.Text = person.Name;
            AgeTextBox.Text = person.Age;
        }

        private void SaveToDesktop(string data, string extension)
        {
            var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = desktopFolder,
                Filter = $"{extension} files|*.{extension}",
                DefaultExt = extension
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, data);
                MessageBox.Show("File saved successfully!");
            }
        }

        private void SaveXmlButton_Click(object sender, RoutedEventArgs e)
        {
            SaveToDesktop(OutputTextBox.Text, "xml");
        }

        private void SaveJsonButton_Click(object sender, RoutedEventArgs e)
        {
                SaveToDesktop(OutputTextBox.Text, "json");
        }

        private void ClearAll(object sender, RoutedEventArgs e)
        {
            NameTextBox.Text = "";
            AgeTextBox.Text = "";
            OutputTextBox.Text = "";
        }

     
    }
}
