using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DomainModel.Sound;

namespace Snake_Game
{
    public enum MeniuState
    {
        Main,
        GameType,
        Difficulty,
        ChooseSnake,
        Highscores,
        Level,
        Help,
        Play,
        Pause,
        Quit
    }

    public enum ArcadeLevel
    {
        Null,
        LongSnake,
        SnakeInFog,
        SnakeandBugs,
        FastSnake,
        SnakeInBarrier

    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Meniu 
    {

        public enum HighScoresType
        {
            Clasic,
            Arcade
        }


        private int MenuItems;
        private int iterator;
        private HighScoresType highScore;
        public MeniuState meniuState {set; get;}
        public string InfoText { get; set; }
        public string Title { get; set; }
        public int SnakeType { get; set; }
        public int Difficult { get; set; }
        public ArcadeLevel Arcade { set; get; }
        MeniuSound sound;

        public int Iterator
        {
            get
            {
                return iterator;
            }
            set
            {
                iterator = value;
                if(sound != null) sound.Play();
                if (iterator > MenuItems) iterator = MenuItems;
                if (iterator < 1) iterator = 1;
            }
        }

        public Meniu()
        {
            MenuItems = 4;
            meniuState = MeniuState.Main;
            highScore = HighScoresType.Clasic;
            Arcade = ArcadeLevel.Null;
            Title = "Meniu";
            Iterator = 0;
            InfoText = string.Empty;
        }

        public void SetSound(MeniuSound sound)
        {
            this.sound = sound;
        }

        /// <summary>
        /// Meniu piešimo parinkimas.
        /// </summary>
        /// <param name="Batch"></param>
        /// <param name="screenWidth"></param>
        /// <param name="arial"></param>
        /// <param name="texture"></param>
        public void DrawMenu(SpriteBatch batch, int screenWidth, SpriteFont arial, MeniuTexture texture)
        {
            switch (meniuState)
            {
                case MeniuState.Main:
                    DrawMainMenu(batch, 1000, texture);
                    break;
                case MeniuState.GameType:
                    DrawGameType(batch, texture);
                    break;
                case MeniuState.Difficulty:
                    DrawDifficultScreen(batch, texture);
                    break;
                case MeniuState.ChooseSnake:
                    DrawChooseSnakeMeniu(batch, texture);
                    break;
                case MeniuState.Highscores:
                    DrawHighScores(batch, texture);
                    break;
                case MeniuState.Level:
                    DrawChoseLevelMeniu(batch, texture);
                    break;
                case MeniuState.Help:
                    DrawHelpScreen(batch, texture);
                    break;
                case MeniuState.Pause:
                    MenuItems = 2;
                    DrawPauseScreen(batch, texture);
                    break;
            }
          
        }

        /// <summary>
        /// Piešiamas žaidimo stiliaus pasirinkimas.
        /// </summary>
        /// <param name="Batch"></param>
        /// <param name="texture"></param>
        private void DrawGameType(SpriteBatch batch, MeniuTexture texture)
        {
            batch.Begin();
            batch.Draw(texture.Background, Vector2.Zero, Color.White);
            batch.Draw(texture.GameTypeTitle, new Vector2(380, 30), Color.White);
            batch.Draw(texture.SignPole, new Vector2(620, 180), Color.White);
            System.Console.WriteLine(Iterator.ToString());
            if (Iterator == 1)
            {
                batch.Draw(texture.SClassical_marked, new Vector2(555, 190), Color.White);
            }
            else
            {
                batch.Draw(texture.SClassical, new Vector2(555, 190), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.SArcade_marked, new Vector2(555, 260), Color.White);
            }
            else
            {
                batch.Draw(texture.SArcade, new Vector2(555, 260), Color.White);
            }
            if (Iterator == 3)
            {
                batch.Draw(texture.SBack_marked, new Vector2(555, 320), Color.White);
            }
            else
            {
                batch.Draw(texture.SBack, new Vector2(555, 320), Color.White);
            }
            batch.End();
        }        
        
        //pakoreguoti kintamuosius

        /// <summary>
        /// Piešia pagrindinį Meniu.
        /// </summary>
        /// <param name="Batch"></param>
        /// <param name="screenWidth"></param>
        /// <param name="texture"></param>
        private void DrawMainMenu(SpriteBatch batch, int screenWidth, MeniuTexture texture)
        {
            batch.Begin();
            batch.Draw(texture.Background, Vector2.Zero, Color.White);
            batch.Draw(texture.GameTitle, new Vector2(500, 10), Color.White);
            batch.Draw(texture.SignPole, new Vector2(620, 180), Color.White);
            System.Console.WriteLine(Iterator.ToString());
            if (Iterator == 1)
            {
                batch.Draw(texture.SNew_game_marked, new Vector2(555, 190), Color.White);
            }
            else
            {
                batch.Draw(texture.SNew_game, new Vector2(555, 190), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.SHighscores_marked, new Vector2(555, 260), Color.White);
            }
            else
            {
                batch.Draw(texture.SHighscores, new Vector2(555, 260), Color.White);
            }
            if (Iterator == 3)
            {
                batch.Draw(texture.SHelp_marked, new Vector2(555, 320), Color.White);
            }
            else
            {
                batch.Draw(texture.SHelp, new Vector2(555, 320), Color.White);
            }
            if (Iterator == 4)
            {
                batch.Draw(texture.SQuit_marked, new Vector2(555, 380), Color.White);
            }
            else
            {
                batch.Draw(texture.SQuit, new Vector2(555, 380), Color.White);
            }
            batch.End();
        }
        /// <summary>
        /// Piešiamas gyvatės pasirinkimo langas.
        /// </summary>
        /// <param name="Batch"></param>
        /// <param name="texture"></param>
        private void DrawChooseSnakeMeniu(SpriteBatch batch, MeniuTexture texture)
        {
            batch.Begin();
            batch.Draw(texture.Background, Vector2.Zero, Color.White);
            batch.Draw(texture.ChooseSnakeTitle, new Vector2(500, 10), Color.White);
            batch.Draw(texture.SignPole, new Vector2(620, 180), Color.White);
            System.Console.WriteLine(Iterator.ToString());
            if (Iterator == 1)
            {
                batch.Draw(texture.SSnake1_marked, new Vector2(555, 190), Color.White);
                batch.Draw(texture.BTreeSnake1, new Vector2(108, 57), Color.White);
            }
            else
            {
                batch.Draw(texture.SSnake1, new Vector2(555, 190), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.SSnake2_marked, new Vector2(555, 260), Color.White);
                batch.Draw(texture.BTreeSnake2, new Vector2(108, 57), Color.White);
            }
            else
            {
                batch.Draw(texture.SSnake2, new Vector2(555, 260), Color.White);
            }
            if (Iterator == 3)
            {
                batch.Draw(texture.SSnake3_marked, new Vector2(555, 320), Color.White);
                batch.Draw(texture.BTreeSnake3, new Vector2(108, 57), Color.White);
            }
            else
            {
                batch.Draw(texture.SSnake3, new Vector2(555, 320), Color.White);
            }
            if (Iterator == 4)
            {
                batch.Draw(texture.SBack_marked, new Vector2(555, 380), Color.White);
            }
            else
            {
                batch.Draw(texture.SBack, new Vector2(555, 380), Color.White);
            }
            batch.End();
        }

        /// <summary>
        /// Piešiamas pagalbos langas.
        /// </summary>
        /// <param name="Batch"></param>
        /// <param name="texture"></param>
        private void DrawHelpScreen(SpriteBatch batch, MeniuTexture texture)
        {
            batch.Begin();
            batch.Draw(texture.Background, Vector2.Zero, Color.White);
            batch.Draw(texture.GameTitle, new Vector2(500, 10), Color.White);
            batch.Draw(texture.DarkLayer, Vector2.Zero, Color.White);
            batch.Draw(texture.Help, new Vector2(8, 0), Color.White);
            batch.Draw(texture.DarkSignPole, new Vector2(680, 380), Color.White);

            if (Iterator == 1)
            {
         //       batch.Draw(texture.BDownMarked, new Vector2(65, 360), Color.White);
            }
            else
            {
           //     batch.Draw(texture.BDown, new Vector2(65, 360), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.SBack2Marked, new Vector2(620, 380), Color.White);
            }
            else
            {
                batch.Draw(texture.SBack2, new Vector2(620, 380), Color.White);
            }

            batch.End();
        }

        /// <summary>
        /// Piešiama pasiekimų lentelė.
        /// </summary>
        /// <param name="Batch"></param>
        /// <param name="texture"></param>
        private void DrawHighScores(SpriteBatch batch, MeniuTexture texture)
        {
            batch.Begin();
            batch.Draw(texture.Background, Vector2.Zero, Color.White);
            batch.Draw(texture.GameTitle, new Vector2(500, 10), Color.White);
            batch.Draw(texture.DarkLayer, Vector2.Zero, Color.White);
            if (highScore == HighScoresType.Clasic)
            {
                batch.Draw(texture.HighScoresCla, new Vector2(115, 0), Color.White);
            }
            else
            {
                batch.Draw(texture.HighScoresArc, new Vector2(115, 0), Color.White);
            }
            batch.Draw(texture.DarkSignPole, new Vector2(680, 380), Color.White);

            if (Iterator == 1)
            {
                batch.Draw(texture.BNextMarked, new Vector2(620, 335), Color.White);
            }
            else
            {
                batch.Draw(texture.BNext, new Vector2(620, 335), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.SBack2Marked, new Vector2(620, 380), Color.White);
            }
            else
            {
                batch.Draw(texture.SBack2, new Vector2(620, 380), Color.White);
            }
            if (Iterator == 3)
            {
               // Batch.Draw(texture.SHelp_marked, new Vector2(555, 320), Color.White);
            }
            else
            {
               // Batch.Draw(texture.SHelp, new Vector2(555, 320), Color.White);
            }
            if (Iterator == 4)
            {
              //  Batch.Draw(texture.SQuit_marked, new Vector2(555, 380), Color.White);
            }
            else
            {
               // Batch.Draw(texture.SQuit, new Vector2(555, 380), Color.White);
            }
            batch.End();
        }

        /// <summary>
        /// Piešiamas nuotykių rėžimo lygio pasirinkimų Meniu.
        /// </summary>
        /// <param name="Batch"></param>
        /// <param name="texture"></param>
        private void DrawChoseLevelMeniu(SpriteBatch batch, MeniuTexture texture)
        {
            batch.Begin();
            batch.Draw(texture.Background, Vector2.Zero, Color.White);
            batch.Draw(texture.DarkLayer, Vector2.Zero, Color.White);
            batch.Draw(texture.ChooseLevelTitle, new Vector2(270, 50), Color.White);
            batch.Draw(texture.DarkSignPole, new Vector2(620, 180), Color.White);
            if (Iterator == 6)
            {
                batch.Draw(texture.SLevel6Marked, new Vector2(600, 0), Color.White);
            }
            else
            {
                batch.Draw(texture.SLevel6, new Vector2(600, 0), Color.White);
            }
            if (Iterator == 5)
            {
                batch.Draw(texture.SLevel5Marked, new Vector2(550, 150), Color.White);
            }
            else
            {
                batch.Draw(texture.SLevel5, new Vector2(550, 150), Color.White);
            }
            if (Iterator == 4)
            {
                batch.Draw(texture.SLevel4Marked, new Vector2(400, 275), Color.White);
            }
            else
            {
                batch.Draw(texture.SLevel4, new Vector2(400, 275), Color.White);
            }
            if (Iterator == 3)
            {
                batch.Draw(texture.SLevel3Marked, new Vector2(250, 160), Color.White);
            }
            else
            {
                batch.Draw(texture.SLevel3, new Vector2(250, 160), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.SLevel2Marked, new Vector2(90, 20), Color.White);
            }
            else
            {
                batch.Draw(texture.SLevel2, new Vector2(90, 20), Color.White);
            }
            if (Iterator == 1)
            {
                batch.Draw(texture.SLevel1Marked, new Vector2(25, 240), Color.White);
            }
            else
            {
                batch.Draw(texture.SLevel1, new Vector2(25, 240), Color.White);
            }                 
            if (Iterator == 7)
            {
                batch.Draw(texture.SBackSMarked, new Vector2(660, 380), Color.White);
            }
            else
            {
                batch.Draw(texture.SBackS, new Vector2(660, 380), Color.White);
            }
            batch.End();
        }

        /// <summary>
        /// Sudėtingumo lango piešimas
        /// </summary>
        /// <param name="Batch"></param>
        /// <param name="texture"></param>
        private void DrawDifficultScreen(SpriteBatch batch, MeniuTexture texture)
        {
            batch.Begin();
            batch.Draw(texture.Background, Vector2.Zero, Color.White);
            batch.Draw(texture.DiffLevelTitle, new Vector2(310, 10), Color.White);
            batch.Draw(texture.SignPole, new Vector2(620, 180), Color.White);
            DrawChosenSnake(batch, texture);
            if (Iterator == 1)
            {
                batch.Draw(texture.SEasy_marked, new Vector2(555, 190), Color.White);
            }
            else
            {
                batch.Draw(texture.SEasy, new Vector2(555, 190), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.SMedium_marked, new Vector2(555, 260), Color.White);
            }
            else
            {
                batch.Draw(texture.SMedium, new Vector2(555, 260), Color.White);
            }
            if (Iterator == 3)
            {
                batch.Draw(texture.SHard_marked, new Vector2(555, 320), Color.White);
            }
            else
            {
                batch.Draw(texture.SHard, new Vector2(555, 320), Color.White);
            }
            if (Iterator == 4)
            {
                batch.Draw(texture.SBack_marked, new Vector2(555, 380), Color.White);
            }
            else
            {
                batch.Draw(texture.SBack, new Vector2(555, 380), Color.White);
            }
            batch.End();
        }

        /// <summary>
        /// Sudėtingumo lange nupiešiama pasirinkta gyvatė.
        /// </summary>
        /// <param name="Batch"></param>
        /// <param name="texture"></param>
        private void DrawChosenSnake(SpriteBatch batch, MeniuTexture texture)
        {
            switch (SnakeType)
            {
                case 0:
                    batch.Draw(texture.BTreeSnake1, new Vector2(108, 57), Color.White);
                    break;
                case 1:
                    batch.Draw(texture.BTreeSnake2, new Vector2(108, 57), Color.White);
                    break;
                case 2:
                    batch.Draw(texture.BTreeSnake3, new Vector2(108, 57), Color.White);
                    break;
            }
        }

        private void DrawPauseScreen(SpriteBatch batch, MeniuTexture texture)
        {
            batch.Begin();
            batch.Draw(texture.BigDarkLayer, Vector2.Zero, Color.White);
            batch.Draw(texture.PauseSign, new Vector2(160, 110), Color.White);
            if (Iterator == 1)
            {
                batch.Draw(texture.TResumeMarked, new Vector2(350, 215), Color.White);
            }
            else
            {
                batch.Draw(texture.TResume, new Vector2(350, 220), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.TMeniuMarked, new Vector2(280, 255), Color.White);
            }
            else
            {
                batch.Draw(texture.TMeniu, new Vector2(280, 255), Color.White);
            }
            batch.End();
        }

        public void DrawEndScreen(SpriteBatch batch, int screenWidth, SpriteFont arial)
        {
            batch.DrawString(arial, InfoText, new Vector2(100, 300), Color.White);
            string prompt = "Press Enter to Continue";
            batch.DrawString(arial, prompt, new Vector2(100, 400), Color.White);
        }

        public int GetNumberOfOptions()
        {
            return MenuItems;
        }

       /* public string GetItem(int index)
        {
            return MenuItems[index];
        }*/

        /// <summary>
        /// Meniu iššrinkimo metodas.
        /// </summary>
        public void Enter()
        {
            switch (meniuState)
            {
                case MeniuState.Main:
                    SelectMainMenu();
                    break;
                case MeniuState.GameType:
                    SelectGameType();
                    break;
                case MeniuState.Difficulty:
                    SelectDifficult();
                    break;
                case MeniuState.ChooseSnake:
                    SelectSnakeType();
                    break;
                case MeniuState.Highscores:
                    SelectHighScore();
                    break;
                case MeniuState.Level:
                    SelectLevel();
                    break;
                case MeniuState.Pause:
                    SelectPause();
                    break;
                case MeniuState.Help:
                    SelectHelp();
                    break;
            }
        }


        private void SelectPause()
        {
            switch (Iterator)
            {
                case 1:
                    meniuState = MeniuState.Play;
                    break;
                case 2:
                    meniuState = MeniuState.Main;
                    Iterator = 1;
                    MenuItems = 4;
                    break;

            }
        }

        private void SelectHelp()
        {
            switch (Iterator)
            {
                case 1:
                    Iterator = 1;
                    MenuItems = 2;
                    break;
                case 2:
                    meniuState = MeniuState.Main;
                    Iterator = 1;
                    MenuItems = 4;
                    break;

            }
        }

        private void SelectHighScore()
        {
            switch (Iterator)
            {
                case 1:
                    if (highScore == HighScoresType.Arcade)
                    {
                        highScore = HighScoresType.Clasic;
                    }
                    else
                    {
                        highScore = HighScoresType.Arcade;
                    }
                    Iterator = 1;
                    MenuItems = 2;
                    break;
                case 2:
                    meniuState = MeniuState.Main;
                    Iterator = 1;
                    MenuItems = 4;
                    break;
                
            }
        }

        /// <summary>
        /// Žaidimo lygio pasirinkimas.
        /// </summary>
        private void SelectLevel()
        {
            // ToDo: sukurti kintamaji kuris nurodytu koks zaiimo lygis buvo parinktas
            switch (Iterator)
            {
                case 1:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    Arcade = ArcadeLevel.LongSnake;
                    break;
                case 2:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    Arcade = ArcadeLevel.FastSnake;
                    break;
                case 3:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    Arcade = ArcadeLevel.SnakeandBugs;
                    break;
                case 4:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    Arcade = ArcadeLevel.SnakeInFog;
                    break;
                case 5:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    Arcade = ArcadeLevel.SnakeInBarrier;
                    break;
                case 6:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    //reikia lygio cia
                    Arcade = ArcadeLevel.Null;
                    break;
                case 7:
                    meniuState = MeniuState.GameType;
                    MenuItems = 3;
                    Iterator = 1;
                    break;
            }
        }

        /// <summary>
        /// Žaidimo lygio sudėtingumo pasirinkimas.
        /// </summary>
        private void SelectDifficult()
        {
            ///TODO: sukurti kintamaji kuris saugotu koks sudetingumas parinktas
            switch (Iterator)
            {
                case 1:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    Difficult = 1;
                    break;
                case 2:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    Difficult = 2;
                    break;
                case 3:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    Difficult = 3;
                    break;
                case 4:
                    meniuState = MeniuState.ChooseSnake;
                    MenuItems = 4;
                    Iterator = 1;
                    break;
            }
        }

        /// <summary>
        /// Gyvatės pasirinkimas.
        /// </summary>
        private void SelectSnakeType()
        {
            switch (Iterator)
            {
                case 1:
                    meniuState = MeniuState.Difficulty;
                    MenuItems = 4;
                    Iterator = 1;
                    SnakeType = 0;
                    break;
                case 2:
                    meniuState = MeniuState.Difficulty;
                    MenuItems = 4;///????????????????????????????
                    Iterator = 1;
                    SnakeType = 1;
                    break;
                case 3:
                    meniuState = MeniuState.Difficulty;
                    MenuItems = 4;
                    Iterator = 1;
                    SnakeType = 2;
                    break;
                case 4:
                    meniuState = MeniuState.GameType;
                    MenuItems = 4;
                    Iterator = 1;
                    break;
            }
        }

        /// <summary>
        /// Žaidimo lygio pasirinkimas.
        /// </summary>
        private void SelectGameType()
        {
            switch (Iterator)
            {
                case 1:
                    meniuState = MeniuState.ChooseSnake;
                    Iterator = 1;
                    MenuItems = 4;
                    Arcade = ArcadeLevel.Null;
                    break;
                case 2:
                    meniuState = MeniuState.Level;
                    Iterator = 1;
                    MenuItems = 7;
                    break;
                case 3:
                    meniuState = MeniuState.Main;
                    MenuItems = 4;
                    Iterator = 1;
                    break;
            }
        }


        //pagrindinis langas
        private void SelectMainMenu()
        {
            switch (Iterator)
            {
                case 1:
                    meniuState = MeniuState.GameType;
                    MenuItems = 3;
                    Iterator = 1;
                    break;
                case 2:
                    meniuState = MeniuState.Highscores;
                    MenuItems = 2;
                    Iterator = 1;
                    break;
                case 3:
                    meniuState = MeniuState.Help;
                    MenuItems = 2;
                    Iterator = 1;
                    break;
                case 4:
                    meniuState = MeniuState.Quit;
                    break;
            }
        }
    }
}
