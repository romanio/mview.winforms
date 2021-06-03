using OpenTK;
using OpenTK.Graphics;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace mview
{
    public partial class Tab2DView : UserControl, ITabObserver
    {
        bool suspendEvents = false;

        readonly MapModel model = null;
        readonly GLControl glControl = null;

        public Tab2DView(EclipseProject ecl)
        {
            InitializeComponent();

            model = new MapModel(ecl);
            
            suspendEvents = true;

            GraphicsMode grx = new GraphicsMode(new ColorFormat(8, 8, 8, 8), 24, 8, 4);
            glControl = new GLControl(grx, 1, 5, GraphicsContextFlags.Default);

            glControl.Paint += GLControlOnPaint;
            glControl.Load += GLControlOnLoad;
            glControl.Resize += GLControlOnResize;

            glControl.MouseClick += GlControlOnMouseClick;
            glControl.MouseMove += GLControlOnMouseMove;
            glControl.MouseWheel += GlControlOnMouseWheel;

            glControl.Dock = DockStyle.Fill;

            panelOpenGL.Controls.Add(glControl);

            suspendEvents = false;
       }

        private void GlControlOnMouseWheel(object sender, MouseEventArgs e)
        {
            model.MouseWheel(e);
            GLControlOnPaint(null, null);
        }

        private void GLControlOnMouseMove(object sender, MouseEventArgs e)
        {
            model.MouseMove(e);
            GLControlOnPaint(null, null);
        }

        private void GlControlOnMouseClick(object sender, MouseEventArgs e)
        {
            model.MouseClick(e);
            GLControlOnPaint(null, null);
        }

        public void UpdateSelectedWells(TabSelectedWellsData data)
        {
            // None
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.LightSteelBlue, ButtonBorderStyle.Solid);
        }

        private void GLControlOnLoad(object sender, EventArgs e)
        {
            model.OnLoad();
        }

        private void GLControlOnPaint(object sender, PaintEventArgs e)
        {
            model.OnPaint();
            glControl.SwapBuffers();
        }

        private void GLControlOnResize(object sender, EventArgs e)
        {
            model.OnResize(glControl.Width, glControl.Height);
            glControl.SwapBuffers();
        }

        public void UpdateSelectedProjects(EclipseProject ecl)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            model.ReadGrid();

            UpdateFormData();

            GLControlOnPaint(null, null);
        }
            
        void UpdateFormData()
        {
            suspendEvents = true;

            // Имена свойств из INIT файла

            treeProperties.Nodes[0].Nodes.Clear();
            treeProperties.Nodes[1].Nodes.Clear();

            var statics = model.GetStaticProperties();
            var dynamics = model.GetDynamicProperties();

            treeProperties.BeginUpdate();

            foreach (string item in statics)
            {
                treeProperties.Nodes[0].Nodes.Add(item);
            }

            foreach (string item in dynamics)
            {
                treeProperties.Nodes[1].Nodes.Add(item);
            }

            treeProperties.EndUpdate();

            // Список из всех доступных рестартов

            boxRestartDates.Items.Clear();

            boxRestartDates.BeginUpdate();
            boxRestartDates.Items.AddRange(model.GetRestartDates());

            if (boxRestartDates.Items.Count > 0)
                boxRestartDates.SelectedIndex = boxRestartDates.Items.Count - 1;

            boxRestartDates.EndUpdate();

            // Размерность по X, Y, Z

            boxSlideX.Items.Clear();
            boxSlideX.BeginUpdate();

            for (int it = 0; it < model.GetNX(); ++it)
                boxSlideX.Items.Add((it + 1).ToString());

            boxSlideX.SelectedIndex = 0;
            boxSlideX.EndUpdate();

            //

            boxSlideY.Items.Clear();
            boxSlideY.BeginUpdate();

            for (int it = 0; it < model.GetNY(); ++it)
                boxSlideY.Items.Add((it + 1).ToString());

            boxSlideY.SelectedIndex = 0;
            boxSlideY.EndUpdate();

            //

            boxSlideZ.Items.Clear();
            boxSlideZ.BeginUpdate();

            for (int it = 0; it < model.GetNZ(); ++it)
                boxSlideZ.Items.Add((it + 1).ToString());

            boxSlideZ.SelectedIndex = 0;
            boxSlideZ.EndUpdate();

            //
            suspendEvents = false;
        }

        private void TabSideControlOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSideControl.SelectedIndex == 0)
            {
                model.SetPosition(ViewMode.X);
                GLControlOnPaint(null, null);
            }

            if (tabSideControl.SelectedIndex == 1)
            {
                model.SetPosition(ViewMode.Y);
                GLControlOnPaint(null, null);
            }

            if (tabSideControl.SelectedIndex == 2)
            {
                model.SetPosition(ViewMode.Z);
                GLControlOnPaint(null, null);
            }

        }
    }
}
