using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameProject
{
    /// <summary>
    /// Определяет состояния кнопки
    /// </summary>
    public enum GameButtonStates
    {
        Normal,
        Hilighted,
        Pressed,
        Up
    }

    public delegate void ButtonAction(Button b);

    public class Button : WindowControl
    {
        string text;
        ButtonAction click;

        public Color normal;
        public Color hilighted;
        public Color pressed;
        public Color borderColor;
        public Color textColor;
        public Color backColor;

        GameButtonStates state;

        int id;

        public Button()
        {
            text = string.Empty;
            click = null;

            normal = Color.White;
            hilighted = Color.LightGray;
            pressed = Color.DarkGray;
            borderColor = Color.Black;
            textColor = Color.Black;

            state = GameButtonStates.Normal;

            horizontal = Alignment.Center;
            vertical = Alignment.Custom;

            id = -1;
        }

        public string Text
        {
            set { text = value; }
            get { return text; }
        }

        public ButtonAction Click
        {
            set { click = value; }
            get { return click; }
        }

        public int ID
        {
            set { id = value; }
            get { return id; }
        }

        public override void ProcessInput(UserInput input)
        {
            Rectangle rect = CurrentRectangle;

            GameButtonStates s = GameButtonStates.Normal;

            if (rect.Contains(input.Mouse))
            {
                switch (input.LeftButton)
                {
                    case MouseButtonStates.Normal:
                        s = GameButtonStates.Hilighted;
                        break;
                    case MouseButtonStates.Down:
                        s = GameButtonStates.Pressed;
                        break;
                    case MouseButtonStates.Up:
                        s = GameButtonStates.Up;
                        break;
                }
            }
            state = s;

            if (state == GameButtonStates.Up)
            {
                if (click != null)
                {
                    ButtonAction temp = click;
                    temp(this);
                }
            }
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            // Прямоугольник отображения            
            Rectangle rect = CurrentRectangle;

            // Кисть для заполнения
            Brush backBrush = null;
            switch (state)
            {
                case GameButtonStates.Normal:
                    backBrush = new SolidBrush(normal);
                    break;
                case GameButtonStates.Hilighted:
                    backBrush = new SolidBrush(hilighted);
                    break;
                case GameButtonStates.Pressed:
                    backBrush = new SolidBrush(pressed);
                    break;
            }
            if (backBrush != null)
            {
                // Заполнить фон
                g.FillRectangle(backBrush, rect);
                backBrush.Dispose();
            }

            // Формат отображения текста
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            // Шрифт
            Font font = new Font("Arial", 12);
            // Кисть для текста
            Brush textBrush = new SolidBrush(textColor);

            // Отобразить текст
            g.DrawString(text, font, textBrush, rect, format);

            // Освободить ресурсы
            textBrush.Dispose();
            font.Dispose();

            // Перо для рамки
            Pen borderPen = new Pen(borderColor, 1);
            // Нарисовать рамку
            g.DrawRectangle(borderPen, rect);
            borderPen.Dispose();
        }
    }
}
