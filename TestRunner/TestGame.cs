using GlobeEngine;
using GlobeEngine.Engine2D;

using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace TestRunner
{
    class TestGame : Engine2DScreen
    {
        public TestGame( )
            : base(new Vector2i(500, 500), "Test Game") { }

        private float[] vertices = new float[] {
            -0.8f, -0.8f, 1.0f,
             0.8f, -0.8f, 1.0f,
             0.0f,  0.8f, 1.0f,
        };

        private int _vao;
        private int _vbo;

        protected override void OnLoad( )
        {
            base.OnLoad();

            EngineTime.Delta = 0f;

            _vao = GL.GenVertexArray();
            GL.BindVertexArray(_vao);

            _vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
        }

        protected override void OnUnload( )
        {
            base.OnUnload();
            Dispose();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            EngineTime.Delta = float.Parse(args.Time.ToString());
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.BindVertexArray(_vao);
            GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length);

            Context.SwapBuffers();
        }
    }
}