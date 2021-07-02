using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;

namespace mview
{
    public class Camera2D
    {
        private float startX, startY;
        private float endX, endY;
        private float shiftX;
        private float shiftY;

        private float scale = 0.01f;
        private float zscale = 12;

        public float ZScale
        {
            set => zscale = value;
            get => zscale;
        }

        public float Scale
        {
            set => scale = value;
            get => scale;
        }

        public Vector2 Shift
        {
            set
            {
                shiftX = value.X;
                shiftY = value.Y;
            }

            get
            {
                return new Vector2((shiftX + endX - startX), (-shiftY + endY - startY));
            }
        }

        public bool isMouseShift = false;

        public void MouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0) scale *= 1.05f;
            if (e.Delta < 0) scale *= 0.95f;
        }

        public void MouseMove(MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.None:
                    {
                        if (isMouseShift)
                        {
                            isMouseShift = false;
                            shiftX += endX - startX;
                            shiftY += -(endY - startY);

                            startX = 0;
                            startY = 0;
                            endX = 0;
                            endY = 0;
                        }

                        isMouseShift = false;

                        break;
                    }
                case MouseButtons.Right:
                    {
                        if (!isMouseShift)
                        {
                            startX = e.X / scale;
                            startY = e.Y / scale;
                        }

                        endX = e.X / scale;
                        endY = e.Y / scale;

                        isMouseShift = true;

                        break;
                    }
            }
        }
    }
}