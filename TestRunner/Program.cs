using System;

namespace TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new TestGame();
            if (!game.Initialize())
                return;
            game.RunGameLoop();
        }
    }
}