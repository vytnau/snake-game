using System;

namespace Snake_Game
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (GameStageUI game = new GameStageUI())
            {
                game.Run();
            }
        }
    }
#endif
}

