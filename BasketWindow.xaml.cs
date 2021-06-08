using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PhotoStudio
{
    /// <summary>
    /// Interaction logic for BasketWin.xaml
    /// </summary>
    public partial class BasketWindow : Window
    {
        List<Service> services;
        public BasketWindow(List<Service> servs)
        {
            InitializeComponent();
            services = servs;
            ServList.ItemsSource = servs;
        }

        /// <summary>
        /// Добавить заказ
        /// </summary>
        private void AddOreder(object sender, RoutedEventArgs e)
        {
            int idClnt = 0;
            if (!int.TryParse(ClientId.Text, out idClnt))//если не получается перевести текст в int
            {
                MessageBox.Show("Неверный Формат id");
                return;
            }

            if(BD.Context.Сlient.Where(a => a.idClient == idClnt).Count() == 0)//если нету клиента с таким id
            {
                MessageBox.Show("Неверный id");
                return;
            }

            Client clnt = BD.Context.Сlient.Where(a => a.idClient == idClnt).FirstOrDefault(); //получаем клиента с указанным id

            Order ord = new Order()
            {
                ordDate = DateTime.Now,
                idClient = clnt.idClient
            };

            foreach (var serv in services) //добавляем все указанные услуги в заказ
            {
                ord.Service.Add(serv);
            }
            
            BD.Context.Order.Add(ord);

            BD.Context.SaveChanges();
        }
    }
}
