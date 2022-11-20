using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GameProject
{
    /// <summary>
    /// Реализует окно игры
    /// </summary>
    public class GameWindow : Window
    {
        Point mouse;

        Rectangle touchRect;

        Rectangle boundRect;

        bool mouseDown;

        // Массив ячеек
        Rectangle[] arrayTouchRect;

        public GameWindow()
        {

        }

        public GameWindow(WindowManager manager)
            : base(manager)
        {

        }

        protected override void Initialize()
        {
            // Размер окна
            Size = manager.Size;
            // Создание кнопок
            // Кнопки
            int width = 100;
            int height = 30;
            Size bSize = new Size(width, height);

            // Меню
            Button menu = new Button();
            menu.Owner = this;
            menu.Text = "Меню";
            menu.ID = 0;
            menu.Horizontal = Alignment.Custom;
            menu.Vertical = Alignment.Custom;
            menu.Location = new Point(Size.Width - 10 - bSize.Width, 10);
            menu.Size = bSize;
            menu.normal = Color.Black;
            menu.textColor = Color.Yellow;
            menu.Click = Menu_Click;
            controls.Add(menu);

            // Заголовок
            TextInput caption = new TextInput();
            caption.Owner = this;
            caption.Text = "2048";
            caption.Horizontal = Alignment.Center;
            caption.Vertical = Alignment.Custom;
            caption.Location = new Point(20, 10);
            caption.Size = new Size(100, 30);
            caption.ReadOnly = true;
            caption.ShowBorder = false;
            caption.backNormalColor = Color.Black;
            caption.textColor = Color.Yellow;
            controls.Add(caption);

            // Заголовок счёт
            TextInput captionScore = new TextInput();
            captionScore.Owner = this;
            captionScore.Text = "Счёт: ";
            captionScore.Horizontal = Alignment.Custom;
            captionScore.Vertical = Alignment.Custom;
            captionScore.Location = new Point(20, Size.Height - bSize.Height - 10);
            captionScore.Size = bSize;
            captionScore.ReadOnly = true;
            captionScore.ShowBorder = false;
            captionScore.backNormalColor = Color.Black;
            captionScore.textColor = Color.Yellow;
            controls.Add(captionScore);

            // Заголовок рекорд
            TextInput captionRecord = new TextInput();
            captionRecord.Owner = this;
            captionRecord.Text = "Рекод: ";
            captionRecord.Horizontal = Alignment.Custom;
            captionRecord.Vertical = Alignment.Custom;
            captionRecord.Location = new Point(captionScore.Size.Width + 125, Size.Height - bSize.Height - 10);
            captionRecord.Size = bSize;
            captionRecord.ReadOnly = true;
            captionRecord.ShowBorder = false;
            captionRecord.backNormalColor = Color.Black;
            captionRecord.textColor = Color.Yellow;
            controls.Add(captionRecord);

            // ограничивающее поле
            int margin = 50;
            boundRect = new Rectangle(margin, margin,
                Size.Width - 2 * margin, Size.Height - 2 * margin);

            // информация о мыши
            mouse = Point.Empty;
            mouseDown = false;

            // Начать новую игру
            StartGame();
        }
        /// <summary>
        /// Выполняет обработку кнопки Меню
        /// </summary>
        /// <param name="b"></param>
        void Menu_Click(Button b)
        {
            if (b != null)
            {
                // Задать параметры                
                Parameters parameters = manager.Parameters;
                // Показать кнопку Продолжить
                parameters.ShowResume = true;
                // Показать основное меню
                manager.SetCurrentWindow(Windows.MainMenu);
            }
        }

        protected override void DrawContent(Graphics g)
        {
            base.DrawContent(g);

            // Отобразить имя игрока
            Rectangle playerRect = new Rectangle(10, 10, 150, 30);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            Font f1 = new Font("Arial", 14);
            g.DrawString("Player Name", f1, Brushes.Black, playerRect, format);

            Rectangle durationRect = new Rectangle();
            durationRect.Width = 300;
            durationRect.Height = 30;
            durationRect.X = CurrentRectangle.Left + (CurrentRectangle.Width - durationRect.Width) >> 1;
            durationRect.Y = CurrentRectangle.Bottom - durationRect.Height - 5;

            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            // Нарисовать сетку
            Rectangle gridGame = new Rectangle
                (boundRect.Left + 10, boundRect.Top + 10, boundRect.Width - 10 * 2, boundRect.Height - 10 * 2);
            // Вертикальные линии
            Point[] pointVertical = new Point[2];
            pointVertical[0] = new Point(gridGame.Left, gridGame.Top);
            pointVertical[1] = new Point(gridGame.Right, gridGame.Top);
            int heightCell = gridGame.Height / 5;
            for (int i = 0; i < 6; i++)
            {
                g.DrawLine(Pens.Black, pointVertical[0], pointVertical[1]);
                pointVertical[0].Y += heightCell;
                pointVertical[1].Y += heightCell;
            }
            //Горизонтальные линии
            Point[] pointHorizontal = new Point[2];
            pointHorizontal[0] = new Point(gridGame.Left, gridGame.Top);
            pointHorizontal[1] = new Point(gridGame.Left, gridGame.Bottom);
            int widthCell = gridGame.Width / 5;
            for (int i = 0; i < 6; i++)
            {
                g.DrawLine(Pens.Black, pointHorizontal[0], pointHorizontal[1]);
                pointHorizontal[0].X += widthCell;
                pointHorizontal[1].X += widthCell;
            }

            //Заполнить массив игровых квадратиков
            arrayTouchRect = new Rectangle[25];
            int padding = 5;
            Point pointCells = new Point(gridGame.Left + padding, gridGame.Top + padding);
            for (int i = 0; i < 5; i++)
            {
                arrayTouchRect[i] = new Rectangle(pointCells.X, pointCells.Y, widthCell - padding * 2, heightCell - padding * 2);
                pointCells.X += widthCell;
            }
            pointCells.Y += heightCell;
            pointCells.X = gridGame.Left + 5;
            for (int i = 5; i < 10; i++)
            {
                arrayTouchRect[i] = new Rectangle(pointCells.X, pointCells.Y, widthCell - padding * 2, heightCell - padding * 2);
                pointCells.X += widthCell;
            }
            pointCells.Y += heightCell;
            pointCells.X = gridGame.Left + 5;
            for (int i = 10; i < 15; i++)
            {
                arrayTouchRect[i] = new Rectangle(pointCells.X, pointCells.Y, widthCell - padding * 2, heightCell - padding * 2);
                pointCells.X += widthCell;
            }
            pointCells.Y += heightCell;
            pointCells.X = gridGame.Left + 5;
            for (int i = 15; i < 20; i++)
            {
                arrayTouchRect[i] = new Rectangle(pointCells.X, pointCells.Y, widthCell - padding * 2, heightCell - padding * 2);
                pointCells.X += widthCell;
            }
            pointCells.Y += heightCell;
            pointCells.X = gridGame.Left + 5;
            for (int i = 20; i < 25; i++)
            {
                arrayTouchRect[i] = new Rectangle(pointCells.X, pointCells.Y, widthCell - padding * 2, heightCell - padding * 2);
                pointCells.X += widthCell;
            }


            // Заполнить прямоугольники
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // Выбор рандомного цвета
            SolidBrush touchRectColor;

            for (int i = 0; i < 25; i++)
            {
                touchRectColor = RandomColorTouchRect();
                g.FillRectangle( new SolidBrush(Color.Yellow), arrayTouchRect[i]);
                g.DrawString($"{i + 1}", f1, Brushes.Black, arrayTouchRect[i], sf);
            }

            // нарисовать рамку
            g.DrawRectangle(Pens.DarkBlue, boundRect);

            // Удалить кисть
            f1.Dispose();
        }

        /// <summary>
        /// Возвращает рандомный цвет для прямоугольников
        /// </summary>
        // 0 - жёлтый, 1 - фиолетовый, 2 - бежевый, 3 - тёмно-зелёный, 4 - сливовый
        SolidBrush RandomColorTouchRect()
        {
            SolidBrush colorTouchRect = new SolidBrush(Color.Yellow);

            Random random = new Random();

            if (random.Next(0, 5) == 0)
            {
                colorTouchRect.Color = Color.Yellow;
            }
            else if (random.Next(0, 5) == 1)
            {
                colorTouchRect.Color = Color.Purple;
            }
            else if (random.Next(0, 5) == 2)
            {
                colorTouchRect.Color = Color.Beige;
            }
            else if (random.Next(0, 5) == 3)
            {
                colorTouchRect.Color = Color.DarkSeaGreen;
            }
            else if (random.Next(0, 5) == 4)
            {
                colorTouchRect.Color = Color.Plum;
            }

            return colorTouchRect;
        }

        /// <summary>
        /// Выполняет обработку ввода пользователя
        /// </summary>
        /// <param name="input">Ввод пользователя</param>
        public override void ProcessInput(UserInput input)
        {
            base.ProcessInput(input);
            // новые координаты 
            Point pt = input.Mouse;

            // новая информация о нажатии            
            bool down = input.LeftButton == MouseButtonStates.Down;

            // смещение
            int dx = pt.X - mouse.X;
            int dy = pt.Y - mouse.Y;

            // обновить состояние
            mouse = pt;
            mouseDown = down;
        }

        /// <summary>
        /// Выполняет старт новой игры
        /// </summary>
        protected void StartGame()
        {
            // объект
            touchRect = new Rectangle();
            touchRect.Width = 40;
            touchRect.Height = 40;
            touchRect.X = (Size.Width - touchRect.Width) >> 1;
            touchRect.Y = (Size.Height - touchRect.Height) >> 1;
        }

        protected override void DrawBackground(Graphics g)
        {
            LinearGradientBrush gradBrush = new LinearGradientBrush
                (boundRect, Color.Green, Color.Blue, LinearGradientMode.Vertical);
            g.FillRectangle(gradBrush, boundRect);
        }

        protected override void DrawFrame(Graphics g)
        {
            g.DrawRectangle(Pens.DarkBlue, boundRect);
        }
    }
}
