using System;
using System.Windows.Forms;
using System.IO;
namespace Snake_Game
{
#if WINDOWS || XBOX
    static class Program
    {
        private const string LOG_PATH = "log.txt";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                using (GameStageUI game = new GameStageUI())
                {
                    game.Run();
                }
            }
            catch (Exception e)
            {
                string lines = e.Message;
                using (StreamWriter sw = File.AppendText(LOG_PATH))
                {
                    sw.WriteLine(lines);
                    sw.Close();
                }    
            }
        }
    }
#endif
}

