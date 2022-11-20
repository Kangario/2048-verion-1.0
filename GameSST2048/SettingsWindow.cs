using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Principal;

namespace GameProject
{
    /// <summary>
    /// Реализует окно настроек
    /// </summary>
    public class SettingsWindow : Window
    {
        Size bSize;
        public SettingsWindow()
        {

        }

        public SettingsWindow(WindowManager manager)
            : base(manager)
        {

        }
        /// <summary>
        /// Выполняет инициализацию окна
        /// </summary>
        protected override void Initialize()
        {
            // Создание кнопок
            Horizontal = Alignment.Center;
            Vertical = Alignment.Center;

            Size = new Size(300, 250);

            BackColor = new SolidBrush(Color.Black);

            // Кнопки
            int width = 100;
            int height = 30;
            bSize = new Size(width, height);

            // Применить
            Button accept = new Button();
            accept.Owner = this;
            accept.Text = "Применить";
            accept.ID = 0;
            accept.Horizontal = Alignment.Custom;
            accept.Vertical = Alignment.Custom;
            accept.Location = new Point(10, Size.Height - 10 - bSize.Height);
            accept.Size = bSize;
            accept.Click = Accept_Click;
            controls.Add(accept);

            // Отменить
            Button cancel = new Button();
            cancel.Owner = this;
            cancel.Text = "Отменить";
            cancel.ID = 1;
            cancel.Horizontal = Alignment.Custom;
            cancel.Vertical = Alignment.Custom;
            cancel.Location = new Point(20 + bSize.Width, Size.Height - 10 - bSize.Height);
            cancel.Size = bSize;
            cancel.Click = Cancel_Click;
            controls.Add(cancel);

            // Заголовок
            TextInput caption = new TextInput();
            caption.Owner = this;
            caption.Text = "Настройки";
            caption.Horizontal = Alignment.Center;
            caption.Vertical = Alignment.Custom;
            caption.Location = new Point(20, 10);
            caption.Size = new Size(200, 20);
            caption.textColor = Color.Red;
            caption.backNormalColor = Color.Black;
            caption.ReadOnly = true;
            caption.ShowBorder = false;
            controls.Add(caption);

            // Заголовок настройки звука
            TextInput soundCaption = new TextInput();
            soundCaption.Owner = this;
            soundCaption.Text = "Звук";
            soundCaption.Horizontal = Alignment.Custom;
            soundCaption.Vertical = Alignment.Custom;
            soundCaption.Location = new Point(25, 10 + caption.Size.Height + 15);
            soundCaption.Size = new Size(50, 30);
            soundCaption.textColor = Color.Red;
            soundCaption.backNormalColor = Color.Black;
            soundCaption.ReadOnly = true;
            soundCaption.ShowBorder = false;
            controls.Add(soundCaption);

            //  Заголовок настройки яркости
            TextInput brightnessCaption = new TextInput();
            brightnessCaption.Owner = this;
            brightnessCaption.Text = "Яркость";
            brightnessCaption.Horizontal = Alignment.Custom;
            brightnessCaption.Vertical = Alignment.Custom;
            brightnessCaption.Location = new Point(17, 10 + caption.Size.Height + 75);
            brightnessCaption.Size = new Size(80, 30);
            brightnessCaption.textColor = Color.Red;
            brightnessCaption.backNormalColor = Color.Black;
            brightnessCaption.ReadOnly = true;
            brightnessCaption.ShowBorder = false;
            controls.Add(brightnessCaption);

            // Заголовок настройки подсказок
            TextInput hintsCaption = new TextInput();
            hintsCaption.Owner = this;
            hintsCaption.Text = "Подсказки";
            hintsCaption.Horizontal = Alignment.Custom;
            hintsCaption.Vertical = Alignment.Custom;
            hintsCaption.Location = new Point(13, 10 + caption.Size.Height + 130);
            hintsCaption.Size = new Size(89, 30);
            hintsCaption.textColor = Color.Red;
            hintsCaption.backNormalColor = Color.Black;
            hintsCaption.ReadOnly = true;
            hintsCaption.ShowBorder = false;
            controls.Add(hintsCaption);

            // Кнопки настроек
            // Выключить подсказки
            Button hintsOff = new Button();
            hintsOff.Owner = this;
            hintsOff.Text = "ВЫКЛ.";
            hintsOff.ID = 0;
            hintsOff.Horizontal = Alignment.Center;
            hintsOff.Vertical = Alignment.Custom;
            hintsOff.Location = new Point(10, 10 + caption.Size.Height + 125);
            hintsOff.Size = new Size(80, 40);
            hintsOff.textColor = Color.Red;
            hintsOff.normal = Color.Black;
            hintsOff.Click = HintsOff_Click;
            controls.Add(hintsOff);

            // Включить подсказки
            Button hintsOn = new Button();
            hintsOn.Owner = this;
            hintsOn.Text = "ВКЛ.";
            hintsOn.ID = 0;
            hintsOn.Horizontal = Alignment.Custom;
            hintsOn.Vertical = Alignment.Custom;
            hintsOn.Location = new Point(200, 10 + caption.Size.Height + 125);
            hintsOn.Size = new Size(80, 40);
            hintsOn.textColor = Color.Red;
            hintsOn.normal = Color.Black;
            hintsOn.Click = HintsOn_Click;
            controls.Add(hintsOn);
        }

        /// <summary>
        /// Обработка кнопки Применить
        /// </summary>
        /// <param name="b"></param>
        void Accept_Click(Button b)
        {
            if (b != null)
            {
                // Показать основное меню
                manager.SetCurrentWindow(Windows.MainMenu);
            }
        }
        /// <summary>
        /// Обработка кнопки Отменить
        /// </summary>
        /// <param name="b"></param>
        void Cancel_Click(Button b)
        {
            if (b != null)
            {
                // Показать основное меню
                manager.SetCurrentWindow(Windows.MainMenu);
            }
        }
        /// <summary>
        /// Обработка кнопки ВКЛ.
        /// </summary>
        /// <param name="b"></param>
        void HintsOn_Click(Button b)
        {

        }
        /// <summary>
        /// Обработка кнопки ВЫКЛ.
        /// </summary>
        /// <param name="b"></param>
        void HintsOff_Click(Button b)
        {

        }

        protected override void DrawFrame(Graphics g)
        {
            g.DrawRectangle(Pens.Black, CurrentRectangle);
        }

        protected override void DrawBackground(Graphics g)
        {
            g.FillRectangle(BackColor, CurrentRectangle);
        }

        protected override void DrawContent(Graphics g)
        {
            // Сетка
            Pen pen = new Pen(Color.Yellow, 3);
            Rectangle grid = new Rectangle
                (CurrentRectangle.X + 10, CurrentRectangle.Y + 10 - (int)pen.Width, CurrentRectangle.Width - 20, CurrentRectangle.Height - 20 - bSize.Height - 2);
            g.DrawRectangle(pen, grid);
            // Горизонтальные линии
            Point pointLine1 = new Point(grid.Left, grid.Top + bSize.Height);
            Point pointLine2 = new Point(grid.Right, grid.Top + bSize.Height);
            g.DrawLine(pen, pointLine1, pointLine2);
            pointLine1.Y += (grid.Height - bSize.Height) / 3;
            pointLine2.Y += (grid.Height - bSize.Height) / 3;
            g.DrawLine(pen, pointLine1, pointLine2);
            pointLine1.Y += (grid.Height - bSize.Height) / 3;
            pointLine2.Y += (grid.Height - bSize.Height) / 3;
            g.DrawLine(pen, pointLine1, pointLine2);
            // Вертикальная линия
            g.DrawLine(pen, new Point
                (grid.Left + grid.Width / 3, grid.Top + bSize.Height), new Point(grid.Left + grid.Width / 3, grid.Bottom));
            // Пробные линии для регулировки звука и яркости
            pen.Color = Color.Red;
            g.DrawLine(pen, grid.Left+grid.Width/2, grid.Top + bSize.Height + bSize.Height,
                grid.Right - grid.Width / 8,grid.Top + bSize.Height + bSize.Height );
            g.DrawLine(pen, grid.Left + grid.Width / 2, grid.Top + (bSize.Height + bSize.Height)*2,
               grid.Right - grid.Width / 8, grid.Top + (bSize.Height + bSize.Height) * 2);
        }
    }
}
