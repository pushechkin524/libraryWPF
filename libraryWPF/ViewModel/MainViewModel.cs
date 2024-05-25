using libraryWPF.Model;
using SecondLibPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary1;

namespace libraryWPF.ViewModel
{
    internal class MainViewModel:BindingHelper
    {
        public BindableCommand serialize { get; set; }
        public MainViewModel() {
            serialize = new BindableCommand(_ => a());
        }

        private string name { get; set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        } 
        
        private string age { get; set; }
        public string Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged();
            }
        } 
        
        private string output { get; set; }
        public string Output
        {
            get => output;
            set
            {
                output = value;
                OnPropertyChanged();
            }
        }

        private void a()
        {
            var person = new Person
            {
                Name = Name,
                Age = Age
            };

            string xml = Serializer.SerializeToJson(person);
            Output = xml;
        }
    }
}
