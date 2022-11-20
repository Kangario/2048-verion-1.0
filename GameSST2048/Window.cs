using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameProject
{
    public enum Alignment
    {
        Near,
        Center,
        Far,
        Custom
    }

    public class Window : IDisposable
    {
        protected WindowManager manager;
        protected List<WindowControl> controls;

        Point location;
        Size size;
        Alignment horizontal;
        Alignment vertical;
        Rectangle currentRectangle;
        SolidBrush backColor;

        public Window()
        {
            controls = new List<WindowControl>();
            manager = null;

            // Выполнить инициализацию
            Initialize();
        }

        public Window(WindowManager manager)
        {
            controls = new List<WindowControl>();
            this.manager = manager;

            // Выполнить инициализацию
            Initialize();
        }

        protected virtual void Initialize()
        {

        }

        public Alignment Horizontal
        {
            set { horizontal = value; }
            get { return horizontal; }
        }

        public Alignment Vertical
        {
            set { vertical = value; }
            get { return vertical; }
        }

        public Point Location
        {
            set { location = value; }
            get { return location; }
        }

        public Size Size
        {
            set { size = value; }
            get { return size; }
        }

        public Rectangle CurrentRectangle
        {
            get { return currentRectangle; }
        }

        public SolidBrush BackColor
        {
            set { backColor = value; }
            get { return backColor; }
        }


        public WindowManager WindowManager
        {
            set { manager = value; }
            get { return manager; }
        }

        public virtual void Dispose()
        {

        }

        public virtual void Draw(Graphics g)
        {
            // Нарисовать фон
            DrawBackground(g);

            // Нарисовать содержимое
            DrawContent(g);

            // Нарисовать элементы управления
            DrawControls(g);

            // Нарисовать рамку
            DrawFrame(g);
        }

        protected virtual void DrawBackground(Graphics g)
        {
            
        }

        protected virtual void DrawContent(Graphics g)
        {

        }

        protected virtual void DrawFrame(Graphics g)
        {

        }

        protected void DrawControls(Graphics g)
        {
            foreach (WindowControl c in controls)
                if (c.Visible)
                    c.Draw(g);
        }

        public virtual void AcceptParameters()
        {

        }

        public virtual void ProcessInput(UserInput input)
        {
            foreach (WindowControl c in controls)
                if (c.Visible)
                    c.ProcessInput(input);
        }

        public void UpdateCurrectLocation()
        {
            currentRectangle = new Rectangle(location, size);

            if (manager != null)
            {
                switch (horizontal)
                {
                    case Alignment.Center:
                        currentRectangle.X = ((manager.Size.Width - size.Width) >> 1);
                        break;
                    case Alignment.Far:
                        currentRectangle.X = manager.Size.Width - size.Width;
                        break;
                    case Alignment.Near:
                        currentRectangle.X = 0;
                        break;
                    case Alignment.Custom:
                        currentRectangle.X = location.X;
                        break;
                }

                switch (vertical)
                {
                    case Alignment.Center:
                        currentRectangle.Y = ((manager.Size.Height - size.Height) >> 1);
                        break;
                    case Alignment.Far:
                        currentRectangle.Y = manager.Size.Height - size.Height;
                        break;
                    case Alignment.Near:
                        currentRectangle.Y = 0;
                        break;
                    case Alignment.Custom:
                        currentRectangle.Y = location.Y;
                        break;
                }
            }

            foreach (WindowControl c in controls)
                c.UpdateCurrentLocation();
        }
    }
}
