using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Threading;
using SharpGL.RenderContextProviders;
using SharpGL.SceneGraph;
using SharpGL.Version;
using SharpGL;
using SharpGL.SceneGraph.Primitives;

namespace lumysom
{
    
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenGLControl_OpenGLDraw(object sender, OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.LoadIdentity();

            gl.Translate(0.0, 0.0F, -4.0F);

            gl.Rotate(rotation, 1.0f, 1.0f, 0.0f);


            /*gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);

            gl.End();
            */
            /*
            IntPtr quadric = gl.NewQuadric();
            gl.QuadricNormals(quadric, OpenGL.GLU_SMOOTH);
            gl.Sphere(quadric, 1.0, 20, 20);

            gl.End();
            */
            Teapot tp = new Teapot();
            tp.Draw(gl, 14, 1, OpenGL.GL_FILL);


            rotation += 3.0f;
            
        }
        float rotation = 0;
        float rquad = 0;


        private void OpenGLControl_OpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] global_ambient = new float[] { 0.5f, 0.2f, 0.3f, 1.0f };
            float[] light0pos = new float[] { 0.1f, 0.5f, 5.0f, 1.0f };
            float[] light0ambient = new float[] { 0.5f, 0.2f, 0.3f, 1.0f };
            float[] light0diffuse = new float[] { 0.3f, 0.2f, 0.3f, 1.0f };
            float[] light0specular = new float[] { 0.9f, 0.2f, 0.3f, 1.0f };
            float[] lmodel_ambient = new float[] { 0.5f, 0.2f, 0.3f, 1.0f };
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);

            gl.ShadeModel(OpenGL.GL_SMOOTH);
        }

        //---------------------------------------------------------------------------------
        private void modluzAmbien_on(object sender, RoutedEventArgs e)
        {
           

            float[] lmodel_ambient = new float[] { 0.5f, 0.2f, 0.3f, 1.0f };
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);
            gl.Endable(OpenGL.GL_LIGHTING);
        }

        private void modluzAmbien_of(object sender, RoutedEventArgs e)
        {
            float[] lmodel_ambient = new float[] { 0.5f, 0.2f, 0.3f, 1.0f };
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);
            gl.Disable(OpenGL.GL_LIGHTING);
        }
        //---------------------------------------------------------------------------------
        private void luzAmbienGlob_on(object sender, RoutedEventArgs e)
        {
            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            gl.Endable(OpenGL.GL_LIGHTING);
        }

        private void luzAmbienGlob_of(object sender, RoutedEventArgs e)
        {
            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            gl.Disable(OpenGL.GL_LIGHTING);
        }
        //---------------------------------------------------------------------------------
        private void posicionLuz_on(object sender, RoutedEventArgs e)
        {
            float[] light0pos = new float[] { 0.0f, 5.0f, 10.0f, 1.0f };

            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Endable(OpenGL.GL_LIGHT0);

        }

        private void posicionLuz_of(object sender, RoutedEventArgs e)
        {
            float[] light0pos = new float[] { 0.0f, 5.0f, 10.0f, 1.0f };

            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Disable(OpenGL.GL_LIGHT0);
        }
        //---------------------------------------------------------------------------------
        private void luzambiental_on(object sender, RoutedEventArgs e)
        {
            float[] light0ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_AMBIENT, light0ambient);
            gl.Endable(OpenGL.GL_LIGHT1);
        }

        private void luzambiental_of(object sender, RoutedEventArgs e)
        {
            float[] light0ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_AMBIENT, light0ambient);
            gl.Disable(OpenGL.GL_LIGHT1);
        }
        //---------------------------------------------------------------------------------
        private void luzDifusa_on(object sender, RoutedEventArgs e)
        {
            float[] light0diffuse = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            gl.Light(OpenGL.GL_LIGHT2, OpenGL.GL_DIFFUSE, light0diffuse);
            gl.Endable(OpenGL.GL_LIGHT2);
        }

        private void luzDifusa_of(object sender, RoutedEventArgs e)
        {
            float[] light0diffuse = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            gl.Light(OpenGL.GL_LIGHT2, OpenGL.GL_DIFFUSE, light0diffuse);
            gl.Endable(OpenGL.GL_LIGHT2);
        }
        //---------------------------------------------------------------------------------
        private void luzEspecular_on(object sender, RoutedEventArgs e)
        {
            float[] light0specular = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            gl.Light(OpenGL.GL_LIGHT3, OpenGL.GL_SPECULAR, light0specular);
            gl.Endable(OpenGL.GL_LIGHT3);
        }

        private void luzEspecular_of(object sender, RoutedEventArgs e)
        {
            float[] light0specular = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            gl.Light(OpenGL.GL_LIGHT3, OpenGL.GL_SPECULAR, light0specular);
            gl.Disable(OpenGL.GL_LIGHT3);
        }
        //---------------------------------------------------------------------------------

    }
}
