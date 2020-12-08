using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL;
using System;

namespace GlobeEngine.Engine2D
{
    public abstract class Engine2DScreen : GameWindow
    {
        private static readonly Vector2i _screenSize = new Vector2i(1366, 768);

        public bool IsRunning { get; private set; }

        public Engine2DScreen(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings) { }

        public Engine2DScreen(Vector2i size, Vector2i location, string title)
            : this(
                  new GameWindowSettings() { },
                  new NativeWindowSettings() {
                      Size = size,
                      Location = location,
                      Title = title
                  })
        { }

        public Engine2DScreen(Vector2i size, string title)
            : this(size, Vector2i.Divide(Vector2i.Add(size, _screenSize), 2), title) { }

        public Engine2DScreen(int width, int height, string title)
           : this(new Vector2i(width, height), Vector2i.Divide(Vector2i.Add(new Vector2i(width, height), _screenSize), 2), title) { }

        public bool Initialize( )
        {
            IsRunning = false;
            if (InitializeOpenGL())
            {
                Console.WriteLine("Succesfully initialized Game Engine");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to initialize Game Engine");
                return false;
            }
        }

        private bool InitializeOpenGL( )
        {
            GLFWBindingsContext binding = new GLFWBindingsContext();
            GL.LoadBindings(binding);
            if (GLFW.Init())
            {
                Console.WriteLine("Succesfully initialised GLFW and OpenGL");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to initialise GLFW and OpenGL");
                return false;
            }
        }

        public void RunGameLoop( )
        {
            if (!IsRunning)
            {
                IsRunning = true;
                Console.WriteLine("Starting Game Loop");
                base.Run();
            }
        }
    }
}