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
    public partial class ServiceWindow : Window
    {
        List<Service> basket = new List<Service>(); // корзина с услугами
        public ServiceWindow()
        {
            InitializeComponent();
            ServiceLV.ItemsSource = BD.Context.Service.ToList(); //выводим данные об услугах
        }

        /// <summary>
        /// Добавление 
        /// </summary>
        private void Add(object sender, RoutedEventArgs e)
        {
            AddWindow win = new AddWindow();
            win.ShowDialog();
            ServiceLV.ItemsSource = BD.Context.Service.ToList(); 
        }

        /// <summary>
        /// Удаление
        /// </summary>
        private void Delete(object sender, RoutedEventArgs e)
        {
            if (ServiceLV.SelectedItems.Count == 0)//если не выбрана запись в таблице
            {
                MessageBox.Show("Ошибка! Не выбрана запись");
                return;
            }

            Service record = (Service)ServiceLV.SelectedItem; //получаем запись
            BD.Context.Service.Remove(record);
            BD.Context.SaveChanges();
            ServiceLV.ItemsSource = BD.Context.Service.ToList(); //обновляем данные в таблице
        }

        /// <summary>
        /// Обновление
        /// </summary>
        private void Update(object sender, RoutedEventArgs e)
        {
            if (ServiceLV.SelectedItems.Count == 0)//если не выбрана запись в таблице
            {
                MessageBox.Show("Ошибка! Не выбрана запись");
                return;
            }

            Service record = (Service)ServiceLV.SelectedItem; //получаем запись
            EditWindow editWin = new EditWindow(record); 
            editWin.ShowDialog();
            ServiceLV.ItemsSource = BD.Context.Service.ToList(); //обновляем данные в таблице
        }

        /// <summary>
        /// Добавление в корзину
        /// </summary>
        private void BusketAdd(object sender, RoutedEventArgs e)
        {
            if (ServiceLV.SelectedItems.Count == 0)//если не выбрана запись в таблице
            {
                MessageBox.Show("Ошибка! Не выбрана запись");
                return;
            }

            Service record = (Service)ServiceLV.SelectedItem; //получаем запись
            if (!basket.Contains(record)) //если запись не содержится в корзине
            {
                basket.Add(record); //добавляем в корзину 
            }
        }

        /// <summary>
        /// Корзина
        /// </summary>
        private void OpenBasket(object sender, RoutedEventArgs e)
        {
            BasketWindow basketWin = new BasketWindow(basket);
            basketWin.ShowDialog();
            basket.Clear(); 
        }
    }
}
