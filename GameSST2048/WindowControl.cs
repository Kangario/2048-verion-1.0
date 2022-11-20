using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameProject
{
    public class WindowControl
    {
        protected Point location;
        protected Size size;
        Rectangle currentRectangle;

        protected Window owner;

        protected bool visible;

        protected Alignment horizontal;
        protected Alignment vertical;

        public WindowControl()
        {
            owner = null;
            visible = true;
            owner = null;
            horizontal = Alignment.Center;
            vertical = Alignment.Center;

            Initialize();
        }

        protected virtual void Initialize()
        {

        }

        public Window Owner
        {
            set { owner = value; }
            get { return owner; }
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

        public bool Visible
        {
            set { visible = value; }
            get { return visible; }
        }

        public virtual void Draw(Graphics g)
        {

        }

        public virtual void ProcessInput(UserInput input)
        {

        }

        public Rectangle CurrentRectangle
        {
            get
            {
                return currentRectangle;
            }
        }

        public void UpdateCurrentLocation()
        {
            currentRectangle = new Rectangle(location, size);

            if (owner != null)
            {
                switch (horizontal)
                {
                    case Alignment.Center:
                        currentRectangle.X = owner.CurrentRectangle.Left + ((owner.CurrentRectangle.Width - size.Width) >> 1);
                        break;
                    case Alignment.Far:
                        currentRectangle.X = owner.CurrentRectangle.Right - size.Width;
                        break;
                    case Alignment.Near:
                        currentRectangle.X = owner.CurrentRectangle.Left;
                        break;
                    case Alignment.Custom:
                        currentRectangle.X = owner.CurrentRectangle.X + location.X;
                        break;
                }

                switch (vertical)
                {
                    case Alignment.Center:
                        currentRectangle.Y = owner.CurrentRectangle.Top + ((owner.CurrentRectangle.Height - size.Height) >> 1);
                        break;
                    case Alignment.Far:
                        currentRectangle.Y = owner.CurrentRectangle.Bottom - size.Height;
                        break;
                    case Alignment.Near:
                        currentRectangle.Y = owner.CurrentRectangle.Y;
                        break;
                    case Alignment.Custom:
                        currentRectangle.Y = owner.CurrentRectangle.Y + location.Y;
                        break;
                }
            }
        }
    }
}
