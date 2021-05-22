using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public class Camera2D
    {
        public ViewMode CurrentViewMode = ViewMode.X;

        public float scale = 0.01f;
        public float scale_z = 20;

        public float shift_start_x, shift_start_y;
        public float shift_end_x, shift_end_y;
        public float shift_x, shift_y;

        public bool is_mouse_shift = false;

        public void MouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0) scale *= 1.05f;
            if (e.Delta < 0) scale *= 0.95f;
        }

        public void MouseMove(MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        if (!is_mouse_shift)
                        {
                            shift_start_x = e.X / scale;

                            if (CurrentViewMode != ViewMode.Z)
                            {
                                shift_start_y = e.Y / (scale_z * scale);
                            }
                            else
                            {
                                shift_start_y = e.Y / scale;
                            }
                        }

                        shift_end_x = e.X / scale;

                        if (CurrentViewMode != ViewMode.Z)
                        {
                            shift_end_y = e.Y / (scale_z * scale);
                        }
                        else
                        {
                            shift_end_y = e.Y / scale;
                        }

                        is_mouse_shift = true;

                        break;
                    }

                default:
                    if (is_mouse_shift)
                    {
                        is_mouse_shift = false;
                        shift_x += shift_end_x - shift_start_x;
                        shift_y += -(shift_end_y - shift_start_y);

                        shift_start_x = 0;
                        shift_start_y = 0;
                        shift_end_x = 0;
                        shift_end_y = 0;
                    }

                    is_mouse_shift = false;

                    break;
            }
        }
    }

}
