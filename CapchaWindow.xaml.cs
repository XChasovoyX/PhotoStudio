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
    public partial class CapchaWindow : Window
    {
        Capcha captha;
        public CapchaWindow()
        {
            InitializeComponent();
            //создаём капчу
            captha = new Capcha();
            captha.Generate();
            Captha.Text = captha.Text;
        }

        /// <summary>
        /// Проверяет капчу после нажатия ок
        /// </summary>
        private void OkClick(object sender, RoutedEventArgs e)
        {
            if (CapthaProv.Text == captha.Text)
            {
                ServiceWindow serviceWin = new ServiceWindow();//открываем окно услуг
                serviceWin.Show();
                Close();
            }
            else // иначе создаём новую капчу
            {
                MessageBox.Show("Хорошая попытка!");
                captha.Generate();
                Captha.Text = captha.Text;
            }
        }
    }
}
