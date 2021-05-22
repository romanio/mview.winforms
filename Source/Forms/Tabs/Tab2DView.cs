using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace mview
{
    public partial class Tab2DView : UserControl, ITabObserver
    {
        bool suspendEvents = false;
        bool glContextInit = false;

        readonly MapModel model = null;

        GLControl glControl = null;

        public Tab2DView(EclipseProject ecl)
        {
            InitializeComponent();

            model = new MapModel(ecl);
            
            suspendEvents = true;

            boxGroupMode.SelectedIndex = 0;
            boxChartsPositions.SelectedIndex = 1;


            glControl = new GLControl(new GraphicsMode(new ColorFormat(8, 8, 8, 0), 24, 8, 4), 1, 5, GraphicsContextFlags.Default);
            glControl.Paint += GLControl_Paint;
            glControl.Load += GLControl_Load;
            glControl.Resize += GLControl_Resize;
            glControl.Dock = DockStyle.Fill;

            panelOpenGL.Controls.Add(glControl);



            suspendEvents = false;
       }


        public void UpdateSelectedWells(TabSelectedWellsData data)
        {
            // None
        }

        public void UpdateSelectedProjects()
        {
            // None
        }


        private void BoxGroupModeOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            //
        }

        private void BoxChartsPositionsOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            //
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.LightSteelBlue, ButtonBorderStyle.Solid);
        }

        private void CheckShowAnnoOnCheckedChanged(object sender, EventArgs e)
        {
            //
            
        }

        private void GLControl_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Load");

            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.Multisample);
                    }

        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Paint");

            if (glContextInit == false) return;

 
        }

        Matrix4 projection;
        Matrix4 modelview;
        Matrix4 mvp;

        private void GLControl_Resize(object sender, EventArgs e)
        {
            if (glContextInit == false) return;

            GLControl_Paint(null, null);
        }

        public void UpdateSelectedProjects(EclipseProject ecl)
        {
            throw new NotImplementedException();
        }
    }
}
