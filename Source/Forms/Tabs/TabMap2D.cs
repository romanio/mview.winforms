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
using OpenTK.Graphics.OpenGL4;

namespace mview
{
    public partial class TabMap2D : UserControl, ITabObserver
    {
        bool suspendEvents = false;
        bool glContextInit = false;

        readonly ChartModel model = null;

        GLControl glControl = null;

        public TabMap2D(EclipseProject ecl)
        {
            System.Diagnostics.Debug.WriteLine("Initizalize");

            InitializeComponent();

            model = new ChartModel(ecl);

            Application.DoEvents();

            suspendEvents = true;

            boxGroupMode.SelectedIndex = 0;
            boxChartsPositions.SelectedIndex = 1;


            glControl = new GLControl(new GraphicsMode(new ColorFormat(8, 8, 8, 0), 24, 8, 4), 3, 3, GraphicsContextFlags.Default);
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

        readonly string VertexShader =
            "#version 330 core\n" +
            "\n" +
            "layout (location=0) in vec3 position;\n" +
            "layout (location=1) in float U;\n" +
            "layout (location=2) in vec3 bary_pos;\n" +
            "out float Ux;\n" +
            "out vec3 Bx;\n" +
            "uniform mat4 mvp;\n" +
            "void main(void)\n" +
            "{\n" +
            "  gl_Position = mvp * vec4(position, 1.0f);\n" +
            "  Ux = U;\n" +
            "  Bx = bary_pos;\n" +
            "}\n";


        readonly string FragmentShader =
            "#version 330 core\n" +
            "in float Ux;\n" +
            "in vec3 Bx;\n" +
            "out vec4 color;\n" +
            "uniform sampler1D tSampler; \n" +
            "float aastep(float threshold, float dist)\n" +
            "{\n" +
            "float afwidth = fwidth(dist) * 0.5;\n" +
            "return smoothstep(threshold - afwidth, threshold + afwidth, dist);\n" +
            "}\n" +
            "void main(void)\n" +
            "{\n" +
            "   float d = min(min(Bx.x, Bx.y), Bx.z);\n" +
            "   float computedThickness = 0.005;\n" +
            "   float edge = 1.0 - aastep(computedThickness, d);\n" +
            "   color.rgb = mix(texture(tSampler, Ux).rgb, vec3(0.0), edge);\n" +
            "}\n";



        private void GLControl_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Load");

            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.Multisample);
            //GL.Enable(EnableCap.PolygonOffsetFill);

            Text = "OpenGL Version " + GL.GetString(StringName.Version);

            System.Diagnostics.Debug.WriteLine("Remove " + GL.GetError().ToString());

            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);
            //
            VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, points.Length * sizeof(float), points, BufferUsageHint.StaticDraw);
            //
            IBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 7 * sizeof(float), 0);

            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 1, VertexAttribPointerType.Float, false, 7 * sizeof(float), 3 * sizeof(float));

            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 7 * sizeof(float), 4 * sizeof(float));

            program = CompileShaders();

            Bitmap bmp = new Bitmap(256, 1);

            int[,] defaultColors = new int[256, 3]
            {
                { 1, 0, 255 }, { 0, 4, 255 }, { 0, 4, 255 }, { 0, 9, 255 }, { 0, 14, 255 }, { 0, 19, 255 }, { 0, 24, 255 }, { 0, 24, 255 },
                { 0, 29, 255 }, { 0, 34, 255 }, { 0, 39, 255 }, { 0, 44, 255 }, { 0, 44, 255 }, { 0, 49, 255 }, { 0, 54, 255 }, { 0, 59, 255 },
                { 0, 64, 255 }, { 0, 64, 255 }, { 0, 69, 255 }, { 0, 74, 255 }, { 0, 79, 255 }, { 0, 84, 255 }, { 0, 84, 255 }, { 0, 89, 255 },
                { 0, 94, 255 }, { 0, 99, 255 }, { 0, 104, 255 }, { 0, 104, 255 }, { 0, 109, 255 }, { 0, 114, 255 }, { 0, 119, 255 }, { 0, 124, 255 },
                { 0, 124, 255 }, { 0, 128, 255 }, { 0, 133, 255 }, { 0, 138, 255 }, { 0, 143, 255 }, { 0, 143, 255 }, { 0, 148, 255 }, { 0, 153, 255 },
                { 0, 158, 255 }, { 0, 163, 255 }, { 0, 163, 255 }, { 0, 168, 255 }, { 0, 173, 255 }, { 0, 178, 255 }, { 0, 183, 255 }, { 0, 183, 255 },
                { 0, 188, 255 }, { 0, 193, 255 }, { 0, 198, 255 }, { 0, 203, 255 }, { 0, 203, 255 }, { 0, 208, 255 }, { 0, 213, 255 }, { 0, 218, 255 },
                { 0, 223, 255 }, { 0, 223, 255 }, { 0, 228, 255 }, { 0, 233, 255 }, { 0, 238, 255 }, { 0, 243, 255 }, { 0, 243, 255 }, { 0, 248, 255 },
                { 0, 253, 255 }, { 0, 255, 252 }, { 0, 255, 247 }, { 0, 255, 247 }, { 0, 255, 242 }, { 0, 255, 237 }, { 0, 255, 232 }, { 0, 255, 227 },
                { 0, 255, 227 }, { 0, 255, 222 }, { 0, 255, 217 }, { 0, 255, 212 }, { 0, 255, 207 }, { 0, 255, 207 }, { 0, 255, 202 }, { 0, 255, 197 },
                { 0, 255, 192 }, { 0, 255, 187 }, { 0, 255, 187 }, { 0, 255, 182 }, { 0, 255, 177 }, { 0, 255, 172 }, { 0, 255, 167 }, { 0, 255, 167 },
                { 0, 255, 162 }, { 0, 255, 157 }, { 0, 255, 152 }, { 0, 255, 147 }, { 0, 255, 147 }, { 0, 255, 142 }, { 0, 255, 137 }, { 0, 255, 132 },
                { 0, 255, 128 }, { 0, 255, 128 }, { 0, 255, 123 }, { 0, 255, 118 }, { 0, 255, 113 }, { 0, 255, 108 }, { 0, 255, 108 }, { 0, 255, 103 },
                { 0, 255, 98 }, { 0, 255, 93 }, { 0, 255, 88 }, { 0, 255, 88 }, { 0, 255, 83 }, { 0, 255, 78 }, { 0, 255, 73 }, { 0, 255, 68 },
                { 0, 255, 68 }, { 0, 255, 63 }, { 0, 255, 58 }, { 0, 255, 53 }, { 0, 255, 48 }, { 0, 255, 48 }, { 0, 255, 43 }, { 0, 255, 38 },
                { 0, 255, 33 }, { 0, 255, 28 }, { 0, 255, 28 }, { 0, 255, 23 }, { 0, 255, 18 }, { 0, 255, 13 }, { 0, 255, 8  }, { 0, 255, 8  },
                { 0, 255, 3  }, { 2, 255, 0  }, { 7, 255, 0  }, { 12, 255, 0  }, { 12, 255, 0  }, { 17, 255, 0  }, { 22, 255, 0  }, { 27, 255, 0  },
                { 32, 255, 0  }, { 32, 255, 0  }, { 37, 255, 0  }, { 42, 255, 0  }, { 47, 255, 0  }, { 52, 255, 0  }, { 52, 255, 0  }, { 57, 255, 0  },
                { 62, 255, 0  }, { 67, 255, 0  }, { 72, 255, 0  }, { 72, 255, 0  }, { 77, 255, 0  }, { 82, 255, 0  }, { 87, 255, 0  }, { 92, 255, 0  },
                { 92, 255, 0  }, { 97, 255, 0  }, { 102, 255, 0  }, { 107, 255, 0  }, { 112, 255, 0  }, { 112, 255, 0  }, { 117, 255, 0  }, { 122, 255, 0  },
                { 127, 255, 0  }, { 131, 255, 0  }, { 131, 255, 0  }, { 136, 255, 0  }, { 141, 255, 0  }, { 146, 255, 0  }, { 151, 255, 0  }, { 151, 255, 0  },
                { 156, 255, 0  }, { 161, 255, 0  }, { 166, 255, 0  }, { 171, 255, 0  }, { 171, 255, 0  }, { 176, 255, 0  }, { 181, 255, 0  }, { 186, 255, 0  },
                { 191, 255, 0  }, { 191, 255, 0  }, { 196, 255, 0  }, { 201, 255, 0  }, { 206, 255, 0  }, { 211, 255, 0  }, { 211, 255, 0  }, { 216, 255, 0  },
                { 221, 255, 0  }, { 226, 255, 0  }, { 231, 255, 0  }, { 231, 255, 0  }, { 236, 255, 0  }, { 241, 255, 0  }, { 246, 255, 0  }, { 251, 255, 0  },
                { 251, 255, 0  }, { 255, 254, 0  }, { 255, 249, 0  }, { 255, 244, 0  }, { 255, 239, 0  }, { 255, 239, 0  }, { 255, 234, 0  }, { 255, 229, 0  },
                { 255, 224, 0  }, { 255, 219, 0  }, { 255, 219, 0  }, { 255, 214, 0  }, { 255, 209, 0  }, { 255, 204, 0  }, { 255, 199, 0  }, { 255, 199, 0  },
                { 255, 194, 0  }, { 255, 189, 0  }, { 255, 184, 0  }, { 255, 179, 0  }, { 255, 179, 0  }, { 255, 174, 0  }, { 255, 169, 0  }, { 255, 164, 0  },
                { 255, 159, 0  }, { 255, 159, 0  }, { 255, 154, 0  }, { 255, 149, 0  }, { 255, 144, 0  }, { 255, 139, 0  }, { 255, 139, 0  }, { 255, 134, 0  },
                { 255, 129, 0  }, { 255, 125, 0  }, { 255, 120, 0  }, { 255, 120, 0  }, { 255, 115, 0  }, { 255, 110, 0  }, { 255, 105, 0  }, { 255, 100, 0  },
                { 255, 100, 0  }, { 255, 95, 0  }, { 255, 90, 0  }, { 255, 85, 0  }, { 255, 80, 0  }, { 255, 80, 0  }, { 255, 75, 0  }, { 255, 70, 0  },
                { 255, 65, 0  }, { 255, 60, 0  }, { 255, 60, 0  }, { 255, 55, 0  }, { 255, 50, 0  }, { 255, 45, 0  }, { 255, 40, 0  }, { 255, 40, 0  },
                { 255, 35, 0  }, { 255, 30, 0  }, { 255, 25, 0  }, { 255, 20, 0  }, { 255, 20, 0  }, { 255, 15, 0  }, { 255, 10, 0  }, { 255, 5, 0  }
            };

            for (int istep = 0; istep < 256; ++istep)
                bmp.SetPixel(istep, 0, Color.FromArgb(255, defaultColors[istep, 0], defaultColors[istep, 1], defaultColors[istep, 2]));


            pictureBox1.BackgroundImage = bmp;

            texture = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture1D, texture);
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);

            GL.TexParameter(TextureTarget.Texture1D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture1D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexImage1D(TextureTarget.Texture1D, 0, PixelInternalFormat.Rgba, 255, 0,
                PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);

            System.Diagnostics.Debug.WriteLine("Tex " + GL.GetError().ToString());

            System.Drawing.Imaging.BitmapData data = bmp.LockBits(new Rectangle(0, 0, 255, 1), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexSubImage1D(TextureTarget.Texture1D, 0, 0, 255, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);

            System.Diagnostics.Debug.WriteLine("Sub" + GL.GetError().ToString());

            GL.ActiveTexture(TextureUnit.Texture0);

            glContextInit = true;

            GLControl_Resize(null, null);
        }

        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Paint");

            if (glContextInit == false) return;

            GL.ClearColor(Color.White);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            GL.UseProgram(program);
            
            GL.BindVertexArray(VAO);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.DrawElements(BeginMode.Triangles, 36, DrawElementsType.UnsignedInt, 0);


            GL.BindVertexArray(0);

            glControl.SwapBuffers();
        }

        Matrix4 projection;
        Matrix4 modelview;
        Matrix4 mvp;

        private void GLControl_Resize(object sender, EventArgs e)
        {
            if (glContextInit == false) return;

            GL.Viewport(glControl.Size);

            float aspect = (float)glControl.Width / (float)glControl.Height;
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect, 1f, 10000);
            modelview = Matrix4.LookAt(new Vector3(+4, +6, -4), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            mvp = modelview * projection;
            GL.UseProgram(program);

            int loc_mvp = GL.GetUniformLocation(program, "mvp");
            GL.UniformMatrix4(loc_mvp, false, ref mvp);

            GLControl_Paint(null, null);
        }

        private int CompileShaders()
        {
            var program = GL.CreateProgram();

            var vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, VertexShader);
            GL.CompileShader(vertexShader);

            System.Diagnostics.Debug.WriteLine("Vertex Shader : " + GL.GetShaderInfoLog(vertexShader));
            GL.AttachShader(program, vertexShader);
            //
            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, FragmentShader);
            GL.CompileShader(fragmentShader);

            System.Diagnostics.Debug.WriteLine("Fragment Shader : " + GL.GetShaderInfoLog(fragmentShader));
            GL.AttachShader(program, fragmentShader);
            //

            GL.LinkProgram(program);

            System.Diagnostics.Debug.WriteLine("Program Shader : " + GL.GetProgramInfoLog(program));

            GL.DetachShader(program, vertexShader);
            GL.DetachShader(program, fragmentShader);

            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            return program;
        }

        int program;

        int VBO, IBO, VAO;
        int texture;

        private void button1_Click(object sender, EventArgs e)
        {
            GL.DeleteBuffer(VBO);
            GL.DeleteBuffer(IBO);
            GL.DeleteTexture(texture);
        }

        public void UpdateSelectedProjects(EclipseProject ecl)
        {
            throw new NotImplementedException();
        }

        float[] points = {
            // front
            -1.0f, -1.0f,  1.0f, 0.9f, 1, 0, 0,
             1.0f, -1.0f,  1.0f, 0.9f, 0, 1, 0,
             1.0f,  1.0f,  1.0f, 0.9f, 0, 1, 1,
            -1.0f,  1.0f,  1.0f, 0.9f, 0, 1, 0,
            // top
            -1.0f,  1.0f,  1.0f, 0.99f, 1, 0, 0,             // 4, 5, 6,
             1.0f,  1.0f,  1.0f, 0.99f, 0, 1, 0,             // 6, 7, 4,
             1.0f,  1.0f, -1.0f, 0.99f, 0, 1, 1,
            -1.0f,  1.0f, -1.0f, 0.99f, 0, 1, 0,
            // back
             1.0f, -1.0f, -1.0f, 0.6f, 1, 0, 0,
            -1.0f, -1.0f, -1.0f, 0.6f, 0, 1, 0,
            -1.0f,  1.0f, -1.0f, 0.6f, 0, 1, 1,
             1.0f,  1.0f, -1.0f, 0.6f, 0, 1, 0,
            // bottom
            -1.0f, -1.0f, -1.0f, 0.4f, 1, 0, 0,
             1.0f, -1.0f, -1.0f, 0.4f, 0, 1, 0,
             1.0f, -1.0f,  1.0f, 0.4f, 0, 1, 1,
            -1.0f, -1.0f,  1.0f, 0.4f, 0, 1, 0,
            // left
            -1.0f, -1.0f, -1.0f, 0.5f, 1, 0, 0,
            -1.0f, -1.0f,  1.0f, 0.5f, 0, 1, 0,
            -1.0f,  1.0f,  1.0f, 0.5f, 0, 1, 1,
            -1.0f,  1.0f, -1.0f, 0.5f, 0, 1, 0,
            // right
            1.0f, -1.0f,  1.0f, 0.8f, 1, 0, 0,
            1.0f, -1.0f, -1.0f, 0.8f, 0, 1, 0,
            1.0f,  1.0f, -1.0f, 0.8f, 0, 1, 1,
            1.0f,  1.0f,  1.0f, 0.8f, 0, 1, 0
        };

        uint[] indices = {
            //
            0, 1, 2,
            2, 3, 0,
            4, 5, 6,
            6, 7, 4,
            8, 9, 10,
            10, 11, 8,
            12, 13, 14,
            14, 15, 12,
            16, 17, 18,
            18, 19, 16,
            20, 21, 22,
            22, 23, 20
        };

    }
}
