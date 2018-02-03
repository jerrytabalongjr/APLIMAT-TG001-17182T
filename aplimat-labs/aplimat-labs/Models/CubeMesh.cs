using aplimat_labs.Utilities;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplimat_labs.Models
{
    public class CubeMesh
    {
        public double Cubex;

        public Vector3 Position;

        public CubeMesh()
        {
            this.Position = new Vector3();
        }

        public CubeMesh(Vector3 initPos)
        {
            this.Position = initPos;
        }

        public CubeMesh(float x, float y, float z)
        {
            this.Position = new Vector3(x, y, z);
        }

        public void Draw(OpenGL gl, double Cubex)
        {
            
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            //FrontFace
            gl.Vertex(this.Position.x - Cubex, this.Position.y + Cubex, this.Position.z + Cubex);
            gl.Vertex(this.Position.x - Cubex, this.Position.y - Cubex, this.Position.z + Cubex);
            gl.Vertex(this.Position.x + Cubex, this.Position.y + Cubex, this.Position.z + Cubex);
            gl.Vertex(this.Position.x + Cubex, this.Position.y - Cubex, this.Position.z + Cubex);

            //RightFace
            gl.Vertex(this.Position.x + Cubex, this.Position.y + Cubex, this.Position.z - Cubex);
            gl.Vertex(this.Position.x + Cubex, this.Position.y - Cubex, this.Position.z - Cubex);

            //BackFace
            gl.Vertex(this.Position.x - Cubex, this.Position.y + Cubex, this.Position.z - Cubex);
            gl.Vertex(this.Position.x - Cubex, this.Position.y - Cubex, this.Position.z - Cubex);

            //LeftFace
            gl.Vertex(this.Position.x - Cubex, this.Position.y + Cubex, this.Position.z + Cubex);
            gl.Vertex(this.Position.x - Cubex, this.Position.y - Cubex, this.Position.z + Cubex);
            gl.End();

            //TopFace
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            gl.Vertex(this.Position.x - Cubex, this.Position.y + Cubex, this.Position.z + Cubex);
            gl.Vertex(this.Position.x + Cubex, this.Position.y + Cubex, this.Position.z + Cubex);
            gl.Vertex(this.Position.x - Cubex, this.Position.y + Cubex, this.Position.z - Cubex);
            gl.Vertex(this.Position.x + Cubex, this.Position.y + Cubex, this.Position.z - Cubex);
            gl.End();

            //BotoomFace
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            gl.Vertex(this.Position.x - Cubex, this.Position.y - Cubex, this.Position.z + Cubex);
            gl.Vertex(this.Position.x + Cubex, this.Position.y - Cubex, this.Position.z + Cubex);
            gl.Vertex(this.Position.x - Cubex, this.Position.y - Cubex, this.Position.z - Cubex);
            gl.Vertex(this.Position.x + Cubex, this.Position.y - Cubex, this.Position.z - Cubex);
            gl.End();

        }

        internal void Draw(OpenGL gl)
        {
            throw new NotImplementedException();
        }
    }
}
