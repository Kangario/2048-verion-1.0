using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class MainMenu : Window
    {
        Button resume = null;
        List<Button> buttons = new List<Button>();
        Rectangle ratingRect;
        public MainMenu()
        {

        }

        public MainMenu(WindowManager manager)
            : base(manager)
        {

        }

        void Resume_Click(Button b)
        {
            // Продолжить
            if (b != null)
            {
                manager.SetCurrentWindow(Windows.GameScreen);
            }
        }

        void StartGame_Click(Button b)
        {
            // Новая игра
            if (b != null)
            {
                manager.SetCurrentWindow(Windows.Pregame);
            }
        }

        void Settings_Click(Button b)
        {
            // Настройки
            if (b != null)
            {
                manager.SetCurrentWindow(Windows.Settings);
            }
        }

        void Exit_Click(Button b)
        {
            // Выход
            if (b != null)
            {
                manager.Exit();
            }
        }

        protected override void Initialize()
        { 
            Horizontal = Alignment.Center;
            Vertical = Alignment.Center;

            Size = new Size(300, 250);

            BackColor = new SolidBrush(Color.Black);

            // Кнопки
            int width = 120;
            int height = 30;
            Size bSize = new Size(width, height);

            // Продолжить
            Button resume = new Button();
            resume.Owner = this;
            resume.Text = "Продолжить";
            resume.ID = 0;
            resume.Horizontal = Alignment.Near;
            resume.Vertical = Alignment.Custom;
            resume.Location = new Point(10, 10);
            resume.Size = bSize;
            resume.Click = Resume_Click;
            resume.Visible = false;
            resume.textColor = Color.Red;
            resume.normal = Color.Black;
            this.resume = resume;
            controls.Add(resume);
            buttons.Add(resume);

            //  Начать игру
            Button startGame = new Button();
            startGame.Owner = this;
            startGame.Text = "Начать игру";
            startGame.ID = 1;
            startGame.Horizontal = Alignment.Near;
            startGame.Vertical = Alignment.Custom;
            startGame.Location = new Point(10, 10);
            startGame.Size = bSize;
            startGame.Click = StartGame_Click;
            startGame.textColor = Color.Red;
            startGame.normal = Color.Black;
            controls.Add(startGame);
            buttons.Add(startGame);

            // Настройки
            Button settings = new Button();
            settings.Owner = this;
            settings.Text = "Настройки";
            settings.ID = 2;
            settings.Horizontal = Alignment.Near;
            settings.Vertical = Alignment.Custom;
            settings.Location = new Point(10, 10);
            settings.Size = bSize;
            settings.Click = Settings_Click;
            settings.textColor = Color.Red;
            settings.normal = Color.Black;
            controls.Add(settings);
            buttons.Add(settings);

            // Выход
            Button exit = new Button();
            exit.Owner = this;
            exit.Text = "Выход";
            exit.ID = 4;
            exit.Horizontal = Alignment.Near;
            exit.Vertical = Alignment.Custom;
            exit.Location = new Point(10, 10);
            exit.Size = bSize;
            exit.Click = Exit_Click;
            exit.textColor = Color.Red;
            exit.normal = Color.Black;
            controls.Add(exit);
            buttons.Add(exit);
           
            // Задать положение кнопок
            UpdateButtonsLocation();
        }

        protected override void DrawFrame(Graphics g)
        {
            g.DrawRectangle(Pens.Black, CurrentRectangle);
        }

        protected override void DrawContent(Graphics g)
        {
            // Рейтинг
            Pen pen = new Pen(Color.Yellow, 3);
            Font font = new Font("Arial", 10);

            ratingRect = new Rectangle(CurrentRectangle.Right - CurrentRectangle.Width / 3, CurrentRectangle.Top + 5,
             CurrentRectangle.Right - (CurrentRectangle.Right - CurrentRectangle.Width / 3) - 5, CurrentRectangle.Bottom / 3);

            g.DrawRectangle(pen, ratingRect);

            int heightCell = ratingRect.Height / 5;

            Point[] pointsLine = new Point[2];
            pointsLine[0] = new Point(ratingRect.Left, ratingRect.Top + heightCell);
            pointsLine[1] = new Point(ratingRect.Right, ratingRect.Top + heightCell);

            // горизонтальные линии
            for (int i = 0; i < 4; i++)
            {
                g.DrawLine(pen, pointsLine[0], pointsLine[1]);
                pointsLine[0].Y += heightCell;
                pointsLine[1].Y += heightCell;
            }
            // вертикальная линия
            pointsLine[0].X = ratingRect.Right - ratingRect.Width / 4;
            pointsLine[0].Y = ratingRect.Top + heightCell;
            pointsLine[1].X = ratingRect.Right - ratingRect.Width / 4;
            pointsLine[1].Y = ratingRect.Bottom;
            g.DrawLine(pen, pointsLine[0], pointsLine[1]);

            BackColor.Color = Color.Yellow;
            g.DrawString("Рейтинг", font, BackColor ,ratingRect.Width/3 + ratingRect.Left, ratingRect.Top);
            g.DrawString("Имя", font, BackColor, ratingRect.Width / 4 + ratingRect.Left, ratingRect.Top + heightCell);
            g.DrawString("О", font, BackColor, ratingRect.Right - ratingRect.Width/5, ratingRect.Top + heightCell);
            BackColor.Color = Color.Black;
        }

        protected override void DrawBackground(Graphics g)
        {
            g.FillRectangle(BackColor, CurrentRectangle);
        }

        public override void AcceptParameters()
        {
            // Применить параметры            
            Parameters parameters = manager.Parameters;

            resume.Visible = parameters.ShowResume;

            if (parameters.ShowResume)
            {

            }
            else
            {

            }

            // Задать положение кнопок
            UpdateButtonsLocation();

            // Обновить текущее положение кнопок относительно окна
            foreach (WindowControl c in controls)
                c.UpdateCurrentLocation();
        }

        protected void UpdateButtonsLocation()
        {
            // Задать координаты кнопок
            int y = 10 + 30 + 10;
            int x;
            int margin = 10;
            /*foreach (WindowControl c in controls)
            {
                if (c.Visible)
                {
                    x = c.Location.X;
                    c.Location = new Point(x, y);
                    y += c.Size.Height + margin;
                }
            }*/
            foreach (Button b in buttons)
            {
                if (b.Visible)
                {
                    x = b.Location.X;
                    b.Location = new Point(x, y);
                    y += b.Size.Height + margin;
                }
            }
        }
    }
}
