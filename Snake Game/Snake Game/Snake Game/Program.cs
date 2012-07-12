using System;
using System.Windows.Forms;
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
           // try
          //  {
                using (GameStageUI game = new GameStageUI())
                //using (Meniu game = new Meniu())
                {

                    // The old contents of Main go here
                    //game.Run();
                    game.Run();
                }
         //   }
       //     catch (Exception e)
       //     {
       /*         string lines = e.Message;

                // Write the string to a file.
                System.IO.StreamWriter file = new System.IO.StreamWriter("log.txt");
                file.WriteLine(lines);

                file.Close();*/
         //   }
        }
    }
#endif
}

