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
using System.Windows.Shapes;

namespace PhotoStudio
{
    public partial class EditWindow : Window
    {
        Service serv;
        public EditWindow(Service service)
        {
            InitializeComponent();
            serv = service;
            NameTB.Text = serv.Name;
            Desc.Text = serv.Description;
            Price.Text = serv.Price.ToString();
        }

        /// <summary>
        /// Сохранение
        /// </summary>
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            string name = NameTB.Text;
            string desc = Desc.Text;
            decimal price = 0;

            if (!decimal.TryParse(Price.Text, out price))//проверка корректности цены
            {
                MessageBox.Show("Неверная цена(Должна быть через запятую)");
                return;
            }

            serv.Name = name;
            serv.Description = desc;
            serv.Price = price;

            BD.Context.SaveChanges();

            Close();
        }
    }
}
