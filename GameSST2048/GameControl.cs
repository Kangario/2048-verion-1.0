using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class GameControl : UserControl
    {
        Render render;
        Timer timer = new Timer();

        UserInput input;
        
        WindowManager windowManager;

        public GameControl()
        {
            InitializeComponent();

            // двойная буферизация
            DoubleBuffered = true;

            // Менеджер экранов            
            windowManager = new WindowManager(this.ParentForm);

            // ввод
            input = new UserInput();

            // рендер
            render = new Render();

            // размер экрана и буфера
            Size screen = windowManager.Size;
            render.CreateBuffers(screen.Width, screen.Height);

            // Отобразить
            windowManager.Draw(render);

            // настройка таймера
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (render != null)
            {
                // Получить изображение (кадр) для рисования
                Bitmap bitmap = render.Buffer;

                // Нарисовать изображение (кадр)
                if (bitmap != null)
                    e.Graphics.DrawImage(bitmap, Point.Empty);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            input.LeftButton = MouseButtonStates.Normal;
            input.RightButton = MouseButtonStates.Normal;

            // Собрать информацию о кнопках
            if (e.Button == MouseButtons.Left)
            {
                input.LeftButton = MouseButtonStates.Down;
            }
            if (e.Button == MouseButtons.Right)
            {
                input.RightButton = MouseButtonStates.Down;
            }

            // Обработать ввод
            windowManager.ProcessInput(input);

            // Отобразить
            windowManager.Draw(render);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            input.LeftButton = MouseButtonStates.Normal;
            input.RightButton = MouseButtonStates.Normal;

            // Собрать информацию о кнопках
            if (e.Button == MouseButtons.Left)
            {
                input.LeftButton = MouseButtonStates.Up;
            }
            if (e.Button == MouseButtons.Right)
            {
                input.RightButton = MouseButtonStates.Up;
            }

            // Обработать ввод
            windowManager.ProcessInput(input);

            // Отобразить
            windowManager.Draw(render);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // Собрать информацию о кнопках
            if (e.Button == MouseButtons.Left)
            {
                input.LeftButton = MouseButtonStates.Down;
            }
            else
            {
                input.LeftButton = MouseButtonStates.Normal;
            }
            if (e.Button == MouseButtons.Right)
            {
                input.RightButton = MouseButtonStates.Down;
            }
            else
            {
                input.RightButton = MouseButtonStates.Normal;
            }

            // Предыдущее положение указателя мыши
            Point m0 = input.Mouse;

            // Новое положение указателя мыши
            input.Mouse = e.Location;
            // Перемещение указателя мыши
            input.MouseDistance = new Size(e.X - m0.X, e.Y - m0.Y);

            // Обработать ввод
            windowManager.ProcessInput(input);

            // Отобразить
            windowManager.Draw(render);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            input.KeyCode = e.KeyCode;
            input.KeyValue = e.KeyValue;
            input.Shift = e.Shift;
            input.KeyDown = true;

            // Обработать ввод
            windowManager.ProcessInput(input);

            // Отобразить
            windowManager.Draw(render);

            // Сброс нажатия клавиши
            input.KeyDown = false;
        }
    }
}
