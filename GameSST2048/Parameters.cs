using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameProject
{
    public class Parameters
    {
        bool showResumeGame;

        Color objectColor;

        public Parameters()
        {
            showResumeGame = false;
           
            objectColor = Color.DarkGray;
        }
        
        /// <summary>
        /// Получает или задает цвет объекта
        /// </summary>
        public Color ObjectColor
        {
            set { objectColor = value; }
            get { return objectColor; }
        }

        /// <summary>
        /// Управляет отображением кнопки Продолжить
        /// </summary>
        public bool ShowResume
        {
            set { showResumeGame = value; }
            get { return showResumeGame; }
        }
    }
}
