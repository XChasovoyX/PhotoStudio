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
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Сохранение
        /// </summary>
        private void Save(object sender, RoutedEventArgs e)
        {
            string name = NameTB.Text;
            string desc = Desc.Text;
            decimal price = 0; 

            if(!decimal.TryParse(Price.Text, out price))//проверка на корректность цены
            {
                MessageBox.Show("Неверная цена");
                return;
            }

            var serv = new Service()//создаём новую услугу
            {
                Name = name,
                Description = desc,
                Price = price
            };

            BD.Context.Service.Add(serv);
            BD.Context.SaveChanges();

            Close(); 
        }
    }
}
