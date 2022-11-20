using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameProject
{
    public class Render
    {
        Bitmap front;
        Bitmap back;

        public Render()
        {
            front = null;
            back = null;
        }

        /// <summary>
        /// Создает буферы заданного размера
        /// </summary>
        /// <param name="width">Ширина буфера</param>
        /// <param name="height">Высота буфера</param>
        public void CreateBuffers(int width, int height)
        {
            if (width > 0 && height > 0)
            {
                if (front != null)
                    front.Dispose();
                front = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                if (back != null)
                    back.Dispose();
                back = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            }
        }

        /// <summary>
        /// Получает объект Graphics для внеэкранного буфера
        /// </summary>
        public Graphics Graphics
        {
            get
            {
                Graphics g = null;
                if (back != null)
                {
                    g = Graphics.FromImage(back);
                }
                return g;
            }
        }

        public Bitmap Buffer
        {
            get { return front; }
        }

        public void FlipBuffers()
        {
            Bitmap temp = front;
            front = back;
            back = temp;
        }
    }
}
