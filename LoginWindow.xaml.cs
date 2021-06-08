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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotoStudio
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка входа
        /// </summary>
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text;
            string passsword = PasswordTB.Password;

            if(BD.Context.Employee.FirstOrDefault(a => a.Login == login) == null) //если не найдена запись с логином
            {
                MessageBox.Show("Ошибка в логине!"); 
                return;
            }

            if (BD.Context.Employee.FirstOrDefault(a => a.Login == login).Password != passsword) // если неверный пароль
            {
                MessageBox.Show("Ошибка в пароле!");
                return;
            }

            new CapchaWindow().Show(); //показываем окно с капчей
            Close(); //закрываем это окно
        }
    }
}
