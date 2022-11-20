using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameProject
{
    public class TextInput : WindowControl
    {
        public Color backNormalColor;
        public Color backFocusColor;
        public Color borderColor;
        public Color textColor;

        bool focused;
        List<char> chars;
        StringBuilder textObject;

        bool readOnly;
        bool showBorder;

        public TextInput()
        {
            backNormalColor = Color.White;
            backFocusColor = Color.LightSkyBlue;
            borderColor = Color.Black;
            textColor = Color.Black;

            horizontal = Alignment.Center;
            vertical = Alignment.Custom;

            focused = false;
            chars = new List<char>(20);
            textObject = new StringBuilder();

            readOnly = false;
            showBorder = true;
        }

        public string Text
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    textObject.Clear();
                    textObject.Append(value);
                    chars.Clear();
                    chars.AddRange(value.ToCharArray());
                }
            }
            get { return textObject.ToString(); }
        }

        public bool ReadOnly
        {
            set { readOnly = value; }
            get { return readOnly; }
        }

        public bool ShowBorder
        {
            set { showBorder = value; }
            get { return showBorder; }
        }

        public override void Draw(Graphics g)
        {
            // Прямоугольник отображения            
            Rectangle rect = CurrentRectangle;

            // Кисть для заполнения
            Brush backBrush = focused ? new SolidBrush(backFocusColor) : new SolidBrush(backNormalColor);
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
            Rectangle textRect = rect;
            textRect.Inflate(-2, -2);
            g.DrawString(textObject.ToString(), font, textBrush, textRect, format);

            // Освободить ресурсы
            textBrush.Dispose();
            font.Dispose();

            if (showBorder)
            {
                // Перо для рамки
                Pen borderPen = new Pen(borderColor, 1);

                // Нарисовать рамку
                g.DrawRectangle(borderPen, rect);
                borderPen.Dispose();
            }
        }
        public override void ProcessInput(UserInput input)
        {
            if (readOnly)
                return;

            Rectangle rect = CurrentRectangle;

            if (rect.Contains(input.Mouse))
            {
                if (input.LeftButton == MouseButtonStates.Down)
                {
                    focused = true;
                }
            }
            else
            {
                if (input.LeftButton == MouseButtonStates.Up)
                {
                    focused = false;
                }
            }

            /* if (focused && input.KeyDown)
             {
                 // определяем какой символ нажат
                 if (input.KeyCode == System.Windows.Forms.Keys.Back)
                 {
                     // удаляем последний символ
                     if (chars.Count > 0)
                     {
                         int last = chars.Count - 1;
                         chars.RemoveAt(last);
                         UpdateText();
                     }
                 }
                 else
                 {
                     char c = GameKeyboard.Keyboard.GetChar(input.KeyValue, input.Shift);
                     if (char.IsDigit(c) || char.IsLetter(c) || char.IsWhiteSpace(c) ||
                         c == '-' || c == '+' || c == '_' || c == '=' || c == ' ')
                     {
                         chars.Add(c);
                         UpdateText();
                     }
                     else
                         MessageBox.Show(input.KeyValue.ToString(), "Клавиша");

                     char c = ((char)input.KeyValue);
                     if (char.IsDigit(c) || char.IsLetter(c) || char.IsWhiteSpace(c))
                     {
                         chars.Add(c);
                         UpdateText();
                     }
                 }
             }*/
        }

        protected void UpdateText()
        {
            textObject.Clear();
            foreach (char c in chars)
                textObject.Append(c);
        }

    }
}
