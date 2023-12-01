using System;
using System.Collections.Generic;
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

namespace pr11
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

        private void infoClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнила Кулькова А.\r\n Дана строка 'aa aba abba abbba abbbba abbbbba'. Напишите регулярное выражение, которое найдет строки вида aba, в которых 'b' встречается более 4-х раз (включительно).\r\nДана строка 'avb a1b a2b a3b a4b a5b abb acb'. Напишите регулярное выражение, которое найдет строки следующего вида: по краям стоят буквы 'a' и 'b', а между ними - не число.");
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void rasClick(object sender, RoutedEventArgs e)
        {
            string a = "aa aba abba abbba abbbba abbbbba";//первая строка
            string b = "avb a1b a2b a3b a4b a5b abb acb";//вторая строка
            Regex regexa = new Regex("ab{4,}a");//переменная класса реджекс, в строке ищем а, затем б 4+ раз, и заканчиваться должно а
            Regex regexb = new Regex("a[^0-9]b");//в строке ищем а, затем какой угодно символ, кроме цифры, затем б
            MatchCollection matcha = regexa.Matches(a);//создаем коллекцию совпадений и ищем совпадения в строке а
            if (matcha.Count > 0)//если в коллекции совпадений их больше 0, то продолжаем
            {
                object[] masa = new object[matcha.Count];//создаем объект типа массива на количество совпадений
                matcha.CopyTo(masa, 0);//копируем совпадения в массив
                lba.ItemsSource = masa;//выводим элементы массива в листбокс
            }
            MatchCollection matchb = regexb.Matches(b);//создаем вторую коллекцию совпадений для второй строки
            if(matchb.Count > 0)//если совпаденй больше 0
            {
                object[] masb = new object[matchb.Count];//создаем объект типа массив на количество совпадений
                matchb.CopyTo(masb, 0);//копируем совпадения в массив
                lbb.ItemsSource = masb;//заполняем листбокс совпадениями
            }
        }
    }
}
