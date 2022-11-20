using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public class PregameWindow : Window 
    {
        TextInput playerName;
        TextInput selectDifficulty;
        public PregameWindow()
        {

        }

        public PregameWindow(WindowManager manager)
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

            Size = new Size(350, 250);

            BackColor = new SolidBrush(Color.Black);

            // Кнопки
            int width = 100;
            int height = 30;
            Size bSize = new Size(width, height);

            // Назад
            Button back = new Button();
            back.Owner = this;
            back.Text = "Назад";
            back.ID = 0;
            back.Horizontal = Alignment.Custom;
            back.Vertical = Alignment.Custom;
            back.Location = new Point(10, Size.Height - 10 - bSize.Height);
            back.Size = bSize;
            back.textColor = Color.Yellow;
            back.normal = Color.Black;
            back.Click = Back_Click;
            controls.Add(back);

            // Начать
            Button start = new Button();
            start.Owner = this;
            start.Text = "Начать";
            start.ID = 1;
            start.Horizontal = Alignment.Custom;
            start.Vertical = Alignment.Custom;
            start.Location = new Point(130 + bSize.Width, Size.Height - 10 - bSize.Height);
            start.Size = bSize;
            start.textColor = Color.Yellow;
            start.normal = Color.Black;
            start.Click = Start_Click;
            controls.Add(start);

            // Заголовок имя игрока
            TextInput captionNamePlayer = new TextInput();
            captionNamePlayer.Owner = this;
            captionNamePlayer.Text = "Введите имя игрока: ";
            captionNamePlayer.Horizontal = Alignment.Near;
            captionNamePlayer.Vertical = Alignment.Custom;
            captionNamePlayer.Location = new Point(20, 10);
            captionNamePlayer.Size = new Size(200, 30);
            captionNamePlayer.ReadOnly = true;
            captionNamePlayer.ShowBorder = false;
            captionNamePlayer.backNormalColor = Color.Black;
            captionNamePlayer.textColor = Color.Yellow;
            controls.Add(captionNamePlayer);

            // Поле для ввода имени игрока
            playerName = new TextInput();
            playerName.Owner = this;
            playerName.Text = "Игрок";
            playerName.Horizontal = Alignment.Custom;
            playerName.Vertical = Alignment.Custom;
            playerName.Location = new Point(captionNamePlayer.Size.Width, 10);
            playerName.Size = new Size(100, 30);
            playerName.backNormalColor = Color.Black;
            playerName.textColor = Color.Yellow;
            playerName.backFocusColor = Color.Black;
            playerName.borderColor = Color.Yellow;
            controls.Add(playerName);

            // Заголовок сложность игры
            TextInput сaptionDifficulty = new TextInput();
            сaptionDifficulty.Owner = this;
            сaptionDifficulty.Text = "Выберите сложность игры: ";
            сaptionDifficulty.Horizontal = Alignment.Near;
            сaptionDifficulty.Vertical = Alignment.Custom;
            сaptionDifficulty.Location = new Point(20, 10 + captionNamePlayer.Size.Height + 10);
            сaptionDifficulty.Size = new Size(230, 30);
            сaptionDifficulty.ReadOnly = true;
            сaptionDifficulty.ShowBorder = false;
            сaptionDifficulty.backNormalColor = Color.Black;
            сaptionDifficulty.textColor = Color.Yellow;
            controls.Add(сaptionDifficulty);

            // Поле для выбора сложности игры
            selectDifficulty = new TextInput();
            selectDifficulty.Owner = this;
            selectDifficulty.Text = "Лёгкая";
            selectDifficulty.Horizontal = Alignment.Custom;
            selectDifficulty.Vertical = Alignment.Custom;
            selectDifficulty.Location = new Point(сaptionDifficulty.Size.Width, сaptionDifficulty.Location.Y);
            selectDifficulty.Size = new Size(100, 30);
            selectDifficulty.backNormalColor = Color.Black;
            selectDifficulty.textColor = Color.Yellow;
            selectDifficulty.backFocusColor = Color.Black;
            selectDifficulty.borderColor = Color.Yellow;
            controls.Add(selectDifficulty);
        }
        /// <summary>
        /// Обработка кнопки Назад
        /// </summary>
        /// <param name="b"></param>
        void Back_Click(Button b)
        {
            if (b != null)
            {
                // Показать основное меню
                manager.SetCurrentWindow(Windows.MainMenu);
            }
        }
        /// <summary>
        /// Обработка кнопки Начать
        /// </summary>
        /// <param name="b"></param>
        void Start_Click(Button b)
        {
            if (b != null)
            {
                // Показать основное меню
                manager.SetCurrentWindow(Windows.GameScreen);
            }
        }

        protected override void DrawFrame(Graphics g)
        {
            g.DrawRectangle(Pens.Black, CurrentRectangle);
        }

        protected override void DrawBackground(Graphics g)
        {
            g.FillRectangle(BackColor, CurrentRectangle);
            
        }
    }
}
