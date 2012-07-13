using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace DataAccess
{
    public class MeniuTexture
    {
        /// <summary>
        /// Pagrindinio Meniu tekstūros.
        /// </summary>
        public Texture2D Background { set; get; }
        public Texture2D GameTitle { set; get; }
        public Texture2D Meniu { set; get; }
        public Texture2D SignPole { set; get; }
        public Texture2D SNew_game { set; get; }
        public Texture2D SNew_game_marked { set; get; }
        public Texture2D SHelp { set; get; }
        public Texture2D SHelp_marked { set; get; }
        public Texture2D SQuit { set; get; }
        public Texture2D SQuit_marked { set; get; }
        public Texture2D SHighscores { set; get; }
        public Texture2D SHighscores_marked { set; get; }

        /// <summary>
        ///Žaidimo Meniu pasirinkimo tekstūros. 
        /// </summary>
        public Texture2D GameTypeTitle { set; get; }
        public Texture2D SClassical { set; get; }
        public Texture2D SClassical_marked { set; get; }
        public Texture2D SArcade { set; get; }
        public Texture2D SArcade_marked { set; get; }
        public Texture2D SBack { set; get; }
        public Texture2D SBack_marked { set; get; }

        /// <summary>
        /// Žaidimo sudėtingumo pasirinkimo tekstūros.
        /// </summary>
        public Texture2D DiffLevelTitle { set; get; }
        public Texture2D SEasy { set; get; }
        public Texture2D SEasy_marked { set; get; }
        public Texture2D SMedium { set; get; }
        public Texture2D SMedium_marked { set; get; }
        public Texture2D SHard { set; get; }
        public Texture2D SHard_marked { set; get; }

        /// <summary>
        /// Gyvatės pasirinkimo tekstūros
        /// </summary>
        public Texture2D ChooseSnakeTitle { set; get; }
        public Texture2D SSnake1 { set; get; }
        public Texture2D SSnake1_marked { set; get; }
        public Texture2D SSnake2 { set; get; }
        public Texture2D SSnake2_marked { set; get; }
        public Texture2D SSnake3 { set; get; }
        public Texture2D SSnake3_marked { set; get; }
        public Texture2D BTreeSnake1 { set; get; }
        public Texture2D BTreeSnake2 { set; get; }
        public Texture2D BTreeSnake3 { set; get; }

        /// <summary>
        /// Nuotykių rėžimo lygio pasirinkimo tekstūros.
        /// </summary>
        public Texture2D SLevel1 { set; get; }
        public Texture2D SLevel1Marked { set; get; }
        public Texture2D SLevel2 { set; get; }
        public Texture2D SLevel2Marked { set; get; }
        public Texture2D SLevel3 { set; get; }
        public Texture2D SLevel3Marked { set; get; }
        public Texture2D SLevel4 { set; get; }
        public Texture2D SLevel4Marked { set; get; }
        public Texture2D SLevel5 { set; get; }
        public Texture2D SLevel5Marked { set; get; }
        public Texture2D SLevel6 { set; get; }
        public Texture2D SLevel6Marked { set; get; }
        public Texture2D DarkLayer { set; get; }
        public Texture2D ChooseLevelTitle { set; get; }
        public Texture2D SBackS { set; get; }
        public Texture2D SBackSMarked { set; get; }
        public Texture2D DarkSignPole { set; get; }

        /// <summary>
        /// Pasiekimų lentos tekstūros.
        /// </summary>
        public Texture2D HighScoresArc { set; get; }
        public Texture2D HighScoresCla { set; get; }
        public Texture2D BNext { set; get; }
        public Texture2D BNextMarked { set; get; }
        public Texture2D SBack2 { set; get; }
        public Texture2D BPrevious { set; get; }
        public Texture2D BPreviousMarked { set; get; }
        public Texture2D SBack2Marked { set; get; }
        public Texture2D L1 { set; get; }
        public Texture2D L2 { set; get; }
        public Texture2D L3 { set; get; }
        public Texture2D L4 { set; get; }
        public Texture2D L5 { set; get; }
        public Texture2D L6 { set; get; }
        public Texture2D LEasy { set; get; }
        public Texture2D LMedium { set; get; }
        public Texture2D LHard { set; get; }


        /// <summary>
        /// Pagalbos lango tekstūros.
        /// </summary>
        public Texture2D Help { set; get; }
        public Texture2D BDown { set; get; }
        public Texture2D BDownMarked { set; get; }

        /// <summary>
        /// Pauzės lango tekstūros.
        /// </summary>
        public Texture2D PauseSign { set; get; }
        public Texture2D TResume { set; get; }
        public Texture2D TResumeMarked { set; get; }
        public Texture2D TMeniu { set; get; }
        public Texture2D TMeniuMarked { set; get; }
        public Texture2D BigDarkLayer { set; get; }
    }
}