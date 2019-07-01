using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new Demo();
        }
    }

    public class Demo : INotifyPropertyChanged
    {
        public Demo()
        {
            InitItems();
        }

        private void InitItems()
        {
            var subItems = new List<DemoA>();
            for (int i = 0; i < 8; i++)
            {
                var item = new DemoA();
                item.Title = $"Sub {i}";
                subItems.Add(item);
            }

            var maintems = new List<DemoA>();
            for (int i = 0; i < 11; i++)
            {
                var item = new DemoA();
                item.Title = $"Main {i}";
                item.Children = new ObservableCollection<DemoA>(subItems);
                maintems.Add(item);
            }
            Items = new ObservableCollection<DemoA>(maintems);
            OnPropertyChanged(nameof(Items));
        }
        public ObservableCollection<DemoA> Items { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DemoA
    {
        public string Title { get; set; }
        public ObservableCollection<DemoA> Children { get; set; }
    }

}