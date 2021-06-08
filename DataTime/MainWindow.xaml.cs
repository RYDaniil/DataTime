using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfDataTimeLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private List<Card> Table = new List<Card>();
        private CardsTable Table = new CardsTable();

        public MainWindow()
        {
            InitializeComponent();

            var D = new Card();
            D.ID = 0;
            D.Name = "123";
            D.Post = "123";
            D.DateBirth = Convert.ToDateTime("12.03.2001");
            D.DateBegin = DateTime.Now;
            D.Monie = 13;
            D.Gender = 'М';
            Table.Add(D);

            D = new Card();
            D.ID = 0;
            D.Name = "123";
            D.Post = "123";
            D.DateBirth = Convert.ToDateTime("12.03.2001");
            D.DateBegin = Convert.ToDateTime("12.05.1980");
            D.Monie = 13;
            D.Gender = 'М';
            Table.Add(D);

            var t = new DataView();
            t.Table = Table.ToTable();
            list.ItemsSource = t;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var D = new Card();
            D.ID = Convert.ToInt32(IDTextBox.Text);
            D.Name = NameTextBox.Text;
            D.DateBirth = (DateTime)DatePickerBirth.SelectedDate;
            D.Gender = Convert.ToChar(GenderTextBox.Text);
            D.DateBegin = (DateTime)DatePickerBegin.SelectedDate;
            D.Post = PostTextBox.Text;
            D.Monie = Convert.ToInt32(MonieTextBox.Text);
            Table.Add(D);

            var t = new DataView();
            t.Table = Table.ToTable();
            list.ItemsSource = t;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Table.Delete(Convert.ToInt32(DeleteTextBox.Text));

            var t = new DataView();
            t.Table = Table.ToTable();
            list.ItemsSource = t;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckBox.IsChecked)
            {
                var t = new DataView();
                t.Table = Table.ToTablePers();
                list.ItemsSource = t;
            } 
            else
            {
                var t = new DataView();
                t.Table = Table.ToTable();
                list.ItemsSource = t;
            }            
        }
    }
}
