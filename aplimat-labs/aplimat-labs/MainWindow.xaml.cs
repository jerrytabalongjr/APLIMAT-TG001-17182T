﻿using aplimat_labs.Models;
using aplimat_labs.Utilities;
using SharpGL;
using SharpGL.SceneGraph.Primitives;
using SharpGL.SceneGraph.Quadrics;
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

namespace aplimat_labs
{

    /// <summary>
    /// Interaction logic for MainWindow.xml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        private CubeMesh mover = new CubeMesh(-25, 0, 0);
        private Vector3 acceleration = new Vector3(0.03f, 0, 0);

        private bool reached = false;

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -40.0f);

            mover.Draw(gl);

            if (reached == false)
            {
                mover.Velocity += acceleration;
                mover.Velocity.Clamp(3.0f);
            }


            if (mover.Position.x > 25.0f) 
            {
                mover.Velocity.x = -1.0f;
                reached = true;
            }
            
            if (reached == true)
            {
                mover.Velocity += acceleration;
                mover.Velocity.Clamp(0.0f);
            }

            gl.DrawText(20, 20, 1, 0, 0, "Arial", 25, mover.Velocity.x + " ");

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
        }

        //private void DrawCartesianPlane(OpenGL gl)
        //{

        //    //draw y-axis
        //    gl.Begin(OpenGL.GL_LINE_STRIP);

        //    gl.Color(1.0f, 0.0f, 1.0f);
        //    gl.Vertex(0, -GRAPH_LIMIT, 0);
        //    gl.Vertex(0, GRAPH_LIMIT, 0);
        //    gl.End();

        //    //draw x-axis
        //    gl.Begin(OpenGL.GL_LINE_STRIP);
        //    gl.Vertex(-GRAPH_LIMIT, 0, 0);
        //    gl.Vertex(GRAPH_LIMIT, 0, 0);
        //    gl.End();

        //    //draw unit lines
        //    for (int i = -15; i <= 15; i++)
        //    {
        //        gl.Begin(OpenGL.GL_LINE_STRIP);
        //        gl.Vertex(-0.2f, i, 0);
        //        gl.Vertex(0.2f, i, 0);
        //        gl.End();

        //        gl.Begin(OpenGL.GL_LINE_STRIP);
        //        gl.Vertex(i, -0.2f, 0);
        //        gl.Vertex(i, 0.2f, 0);
        //        gl.End();
        //    }
        //}

        //private void DrawPoint(OpenGL gl, float x, float y)
        //{
        //    gl.PointSize(5.0f);
        //    gl.Begin(OpenGL.GL_POINTS);
        //    gl.Vertex(x, y);
        //    gl.End();
        //}

        //private void DrawLinearFunction(OpenGL gl)
        //{
        //    /*
        //     * f(x) = x + 2;
        //     * Let x be 4, then y = 6 (4, 6)
        //     * Let x be -5, then y = -3 (-5, -3)
        //     * */
        //    gl.PointSize(2.0f);
        //    gl.Begin(OpenGL.GL_POINTS);
        //    for (float x = -(GRAPH_LIMIT - 5); x <= (GRAPH_LIMIT - 5); x+=LINE_SMOOTHNESS)
        //    {
        //        gl.Vertex(x, x + 2);
        //    }
        //    gl.End();

        //    DrawText(gl, "f(x) = x + 2", 500, 400);

        //}


        //private void DrawQuadraticFunction(OpenGL gl)
        //{
        //    gl.PointSize(2.0f);
        //    gl.Begin(OpenGL.GL_POINTS);
        //    for (float x = -(GRAPH_LIMIT - 5); x <= (GRAPH_LIMIT - 5); x += LINE_SMOOTHNESS)
        //    {
        //        gl.Vertex(x, Math.Pow(x, 2));
        //    }
        //    gl.End();

        //    DrawText(gl, "f(x) = x ^ 2", 360, 380);

        //}

        //private void DrawCircle(OpenGL gl)
        //{
        //    float radius = 3.0f;

        //    gl.PointSize(2.0f);
        //    gl.Begin(OpenGL.GL_POINTS);
        //    for (int i = 0; i <= TOTAL_CIRCLE_ANGLE; i++)
        //    {
        //        gl.Vertex(Math.Cos(i) * radius, Math.Sin(i) * radius);
        //    }
        //    gl.End();

        //    DrawText(gl, "(cos(x), sin(x))", 350, 200);
        //}

        //private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        //{
        //    switch (e.Key)
        //    {
        //        case Key.W:
        //            break;
        //    }
        //} 
        #region opengl init
        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            float[] light0pos = new float[] { 0.0f, 5.0f, 10.0f, 1.0f };
            float[] light0ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0diffuse = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] light0specular = new float[] { 0.8f, 0.8f, 0.8f, 1.0f };

            float[] lmodel_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);

            gl.Color(0,1,1);

            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            



            gl.ShadeModel(OpenGL.GL_SMOOTH);

        }
        #endregion

        #region draw text
        private void DrawText(OpenGL gl, string text, int x, int y)
        {
            gl.DrawText(x, y, 1, 1, 1, "Arial", 12, text);
        }
        #endregion

        private void OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
