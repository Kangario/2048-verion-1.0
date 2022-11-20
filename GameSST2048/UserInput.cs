using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    public enum MouseButtonStates
    {
        Normal,
        Down,
        Up
    }

    public class UserInput
    {
        Point mouse;
        Size mouseDistance;

        bool mouseDown;

        MouseButtonStates leftButton;
        MouseButtonStates rightButton;
        int mouseClicks;

        Keys keyCode;
        int keyValue;
        bool keyDown;
        bool shift;

        public UserInput()
        {
            mouse = Point.Empty;
            mouseDown = false;
            leftButton = MouseButtonStates.Normal;
            rightButton = MouseButtonStates.Normal;
            mouseDistance = new Size(0, 0);
            mouseClicks = 0;
            keyDown = false;
            shift = false;
        }

        public Point Mouse
        {
            set { mouse = value; }
            get { return mouse; }
        }

        public bool MouseDown
        {
            set { mouseDown = value; }
            get { return mouseDown; }
        }

        public MouseButtonStates LeftButton
        {
            set { leftButton = value; }
            get { return leftButton; }
        }

        public MouseButtonStates RightButton
        {
            set { rightButton = value; }
            get { return rightButton; }
        }

        public Size MouseDistance
        {
            set { mouseDistance = value; }
            get { return mouseDistance; }
        }

        public int MouseClicks
        {
            set { mouseClicks = value; }
            get { return mouseClicks; }
        }

        public Keys KeyCode
        {
            set { keyCode = value; }
            get { return keyCode; }
        }

        public int KeyValue
        {
            set { keyValue = value; }
            get { return keyValue; }
        }

        public bool KeyDown
        {
            set { keyDown = value; }
            get { return keyDown; }
        }

        public bool Shift
        {
            set { shift = value; }
            get { return shift; }
        }
    }
}
