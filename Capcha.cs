using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio
{
    public class Capcha
    {
        /// <summary>
        /// Текст капчи
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Создание капчи
        /// </summary>
        public void Generate()
        {
            var r = new Random();
            string str = "";

            for (int i = 0; i < 4; i++) // создаём новые случайные 4 числа 
            {
                str += (char)r.Next(65, 123);
            }

            Text = str;
        }
    }
}
