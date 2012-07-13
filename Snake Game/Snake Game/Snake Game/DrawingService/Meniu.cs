using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DomainModel.Sound;
using Snake_Game.ServiceContracts.DataBaseInterface;
using DomainModel;

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
        SnakeInNight,
        SnakeandBugs,
        FastSnake,
        SnakeInBarrier,
        SnakeInBarrier1
    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Meniu 
    {

        public enum HighScoresType
        {
            Clasic,
            Cl0,
            Cl1,
            Cl2,
            Ar1,
            Ar2,
            Ar3,
            Ar4,
            Ar5,
            Ar6,
            Arcade
        }


        private int MenuItems;
        private int iterator;
        private IHighScores highScoresData;
        private HighScoresType highScore;
        public MeniuState meniuState {set; get;}
        public string InfoText { get; set; }
        public string Title { get; set; }
        public int SnakeType { get; set; }
        public int Difficult { get; set; }
        public ArcadeLevel Arcade { set; get; }
        public SpriteFont Font { set; get; }
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

        public Meniu(IHighScores highScores)
        {
            highScoresData = highScores;
            MenuItems = 4;
            meniuState = MeniuState.Main;
            highScore = HighScoresType.Cl0;
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
            DrawHighScoresBackground(batch, texture);
            batch.Draw(texture.DarkSignPole, new Vector2(680, 380), Color.White);

            if (Iterator == 1)
            {
                batch.Draw(texture.BPreviousMarked, new Vector2(155, 285), Color.White);
            }
            else
            {
                batch.Draw(texture.BPrevious, new Vector2(155, 285), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.BNextMarked, new Vector2(620, 285), Color.White);
            }
            else
            {
                batch.Draw(texture.BNext, new Vector2(620, 285), Color.White);
            }
            if (Iterator == 3)
            {
                batch.Draw(texture.SBack2Marked, new Vector2(620, 380), Color.White);
            }
            else
            {
                batch.Draw(texture.SBack2, new Vector2(620, 380), Color.White);
            }
            PlayerHighScores(batch);
            batch.End();
        }

        /// <summary>
        /// Piešiamas pasiekimų lango lenta bei prierašas, kokio tipo pasieikimai rodomi.
        /// </summary>
        /// <param name="batch">Piešimo objektas.</param>
        /// <param name="texture">Objektas, kuriame saugomos visos tekstūros</param>
        private void DrawHighScoresBackground(SpriteBatch batch, MeniuTexture texture)
        {
            switch (highScore)
            {
                case HighScoresType.Ar1: batch.Draw(texture.HighScoresArc, new Vector2(115, 0), Color.White);
                    batch.Draw(texture.L1, new Vector2(580, 142), Color.White);
                    break;
                case HighScoresType.Ar2: batch.Draw(texture.HighScoresArc, new Vector2(115, 0), Color.White);
                    batch.Draw(texture.L2, new Vector2(580, 142), Color.White);
                    break;
                case HighScoresType.Ar3: batch.Draw(texture.HighScoresArc, new Vector2(115, 0), Color.White);
                    batch.Draw(texture.L3, new Vector2(580, 142), Color.White);
                    break;
                case HighScoresType.Ar4: batch.Draw(texture.HighScoresArc, new Vector2(115, 0), Color.White);
                    batch.Draw(texture.L4, new Vector2(580, 142), Color.White);
                    break;
                case HighScoresType.Ar5: batch.Draw(texture.HighScoresArc, new Vector2(115, 0), Color.White);
                    batch.Draw(texture.L5, new Vector2(580, 142), Color.White);
                    break;
                case HighScoresType.Ar6: batch.Draw(texture.HighScoresArc, new Vector2(115, 0), Color.White);
                    batch.Draw(texture.L6, new Vector2(580, 142), Color.White);
                    break;
                case HighScoresType.Cl0: batch.Draw(texture.HighScoresCla, new Vector2(115, 0), Color.White);
                    batch.Draw(texture.LEasy, new Vector2(545, 142), Color.White);
                    break;
                case HighScoresType.Cl1: batch.Draw(texture.HighScoresCla, new Vector2(115, 0), Color.White);
                    batch.Draw(texture.LMedium, new Vector2(545, 142), Color.White);
                    break;
                case HighScoresType.Cl2: batch.Draw(texture.HighScoresCla, new Vector2(115, 0), Color.White);
                    batch.Draw(texture.LHard, new Vector2(545, 142), Color.White);
                    break;
            }
        }

        /// <summary>
        /// Aptinkama kokią statistiką norima peržiūrėti, ir pagal tai parenkamas raktinis trumpinys.
        /// </summary>
        /// <returns>Gražinamas raktinis trumpinys.</returns>
        private String GetGameType()
        {
            string value = "ee";
            switch (highScore)
            {
                case HighScoresType.Ar1: value = "ar1";
                    break;
                case HighScoresType.Ar2: value = "ar2";
                    break;
                case HighScoresType.Ar3: value = "ar3";
                    break;
                case HighScoresType.Ar4: value = "ar4";
                    break;
                case HighScoresType.Ar5: value = "ar5";
                    break;
                case HighScoresType.Ar6: value = "ar6";
                    break;
                case HighScoresType.Cl0: value = "cl0";
                    break;
                case HighScoresType.Cl1: value = "cl1";
                    break;
                case HighScoresType.Cl2: value = "cl2";
                    break;
            }
            return value;
        }

        /// <summary>
        /// Metodas paruošia sąrašą pasiekimų lentelei. Sąrašas parenkamas pagal tai, kokia pasiekimų lentelė peržiūrima.
        /// </summary>
        /// <returns>Gražinamas mažėjimo tvarak surikuotas pasiekimų sąrašas</returns>
        private IList<PlayerStat> PrepareList()
        {
            IEnumerable<PlayerStat> sortedEnum = highScoresData.GetHighScores(GetGameType()).OrderByDescending(f => f.Point);
            return sortedEnum.ToList();
        }

        private void PlayerHighScores(SpriteBatch batch)
        {
            IList<PlayerStat> players = PrepareList();
            for(int i = 0; i < 10; i++){
                PlayerStat stat =  GetPlayerStat(i, players);
                DrawHighScoreListNumber(i, batch);
                batch.DrawString(Font, stat.Name, new Vector2(280, 20 * i + 210), Color.White);
                PlayerTime(batch, stat.Time, i);
                DrawPlayerPoints(stat.Point.ToString(), batch, i);
            }
        }

        /// <summary>
        /// Metodas kuris pasiekimų lentelėje piešia laikus. Suskaidomas laikas į minutęs ir sekundęs.
        /// </summary>
        /// <param name="batch">Piešimo objektas.</param>
        /// <param name="time">Laikas, kiek truko žaidimas.</param>
        /// <param name="i">Indeksas nusakantis kuri eilutė yra spausdinama.</param>
        private void PlayerTime(SpriteBatch batch, TimeSpan time, int i)
        {
            if (time.Minutes < 10)
            {
                batch.DrawString(Font, "0" + time.Minutes.ToString(), new Vector2(415, 20 * i + 210), Color.White);
            }
            else
            {
                batch.DrawString(Font, time.Minutes.ToString(), new Vector2(415, 20 * i + 210), Color.White);
            }
            if (time.Seconds < 10)
            {
                batch.DrawString(Font, ":0" + time.Seconds.ToString(), new Vector2(435, 20 * i + 210), Color.White);
            }
            else
            {
                batch.DrawString(Font, ":" + time.Seconds.ToString(), new Vector2(435, 20 * i + 210), Color.White);
            }
        }

        /// <summary>
        /// Metodas spausdinantis eilutės numerius. Tikrinimas reikalingas tik tam, kad būtų išligiotas tekstas.
        /// </summary>
        /// <param name="i">Indeksas i, nusakantis kuri eilutė bus spausdinama.</param>
        /// <param name="batch">Piešimo objektas.</param>
        private void DrawHighScoreListNumber(int i, SpriteBatch batch)
        {
            if (i == 9)
                batch.DrawString(Font, (i + 1).ToString() + ".", new Vector2(203, 20 * i + 210), Color.White);
            else 
                batch.DrawString(Font, (i + 1).ToString() + ".", new Vector2(210, 20 * i + 210), Color.White);
        }


        /// <summary>
        /// Metodas kuris gražina iš sąrašo elementus. Tikrina, ar indekso numeris nedidesnis, nei sąraše yra elementų.
        /// </summary>
        /// <param name="i">Masyvo indeksas, kuris nurodo kuri vieta iš top 10 bus spausdinama.</param>
        /// <param name="list">Žaidėjo pasiekimų sąrašas.</param>
        /// <returns>Gražinama žaidėjo statisktika, jei tokios nėra, tai gražinama tusčia informacija.</returns>
        private PlayerStat GetPlayerStat(int i, IList<PlayerStat> list)
        {
            if (i < list.Count)
            {
                return list[i];
            }
            else
            {
                return new PlayerStat()
                {
                    Name = "--------",
                    Time = TimeSpan.Zero,
                    Point = 0
                
                };
            }
        }

        /// <summary>
        /// Metodas piešiantis žaidėjo sukauptus taškus į pasiekimų lentelę. Taškai išligiuojami pagal dešinį kraštą.
        /// </summary>
        /// <param name="point">Žaidėjo taškai.</param>
        /// <param name="batch">Piešimo objektas.</param>
        /// <param name="i">Indeksas nurodantis kuri eilutė piešiama.</param>
        private void DrawPlayerPoints(String point, SpriteBatch batch, int i)
        {
            if (point.Length == 1)
            {
                batch.DrawString(Font, point, new Vector2(580, 20 * i + 210), Color.White);
            }
            else if (point.Length == 2)
            {
                batch.DrawString(Font, point, new Vector2(570, 20 * i + 210), Color.White);
            }
            else if (point.Length == 3)
            {
                batch.DrawString(Font, point, new Vector2(560, 20 * i + 210), Color.White);
            }
            else if (point.Length == 4)
            {
                batch.DrawString(Font, point, new Vector2(550, 20 * i + 210), Color.White);
            }
            else
            {
                batch.DrawString(Font, point, new Vector2(540, 20 * i + 210), Color.White);
            }
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
                    ChangeHihgScoresBack();
                    Iterator = 1;
                    MenuItems = 3;
                    break;
                case 2:
                    ChangeHihgScores();
                    Iterator = 1;
                    MenuItems = 3;
                    break;
                case 3:
                    meniuState = MeniuState.Main;
                    Iterator = 1;
                    MenuItems = 4;
                    break;
                
            }
        }

        /// <summary>
        /// Metodas pakeičiantis highScore reikšmę. Tai duoda, kad atveriamas naujas pasiekimų langas su naujais duomenimis.
        /// </summary>
        private void ChangeHihgScores()
        {
            switch (highScore)
            {
                case HighScoresType.Ar1: highScore = HighScoresType.Ar2;
                    break;
                case HighScoresType.Ar2: highScore = HighScoresType.Ar3;
                    break;
                case HighScoresType.Ar3: highScore = HighScoresType.Ar4;
                    break;
                case HighScoresType.Ar4: highScore = HighScoresType.Ar5;
                    break;
                case HighScoresType.Ar5: highScore = HighScoresType.Ar6;
                    break;
                case HighScoresType.Ar6: highScore = HighScoresType.Cl0;
                    break;
                case HighScoresType.Cl0: highScore = HighScoresType.Cl1;
                    break;
                case HighScoresType.Cl1: highScore = HighScoresType.Cl2;
                    break;
                case HighScoresType.Cl2: highScore = HighScoresType.Ar1;
                    break;
            }
        }

        private void ChangeHihgScoresBack()
        {
            switch (highScore)
            {
                case HighScoresType.Ar1: highScore = HighScoresType.Cl2;
                    break;
                case HighScoresType.Ar2: highScore = HighScoresType.Ar1;
                    break;
                case HighScoresType.Ar3: highScore = HighScoresType.Ar2;
                    break;
                case HighScoresType.Ar4: highScore = HighScoresType.Ar3;
                    break;
                case HighScoresType.Ar5: highScore = HighScoresType.Ar4;
                    break;
                case HighScoresType.Ar6: highScore = HighScoresType.Ar5;
                    break;
                case HighScoresType.Cl0: highScore = HighScoresType.Ar6;
                    break;
                case HighScoresType.Cl1: highScore = HighScoresType.Cl0;
                    break;
                case HighScoresType.Cl2: highScore = HighScoresType.Cl1;
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
                    Arcade = ArcadeLevel.SnakeInNight;
                    break;
                case 3:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    Arcade = ArcadeLevel.SnakeandBugs;
                    break;
                case 4:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    Arcade = ArcadeLevel.FastSnake;
                    break;
                case 5:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    Arcade = ArcadeLevel.SnakeInBarrier;
                    break;
                case 6:
                    meniuState = MeniuState.Play;
                    Iterator = 1;
                    Arcade = ArcadeLevel.SnakeInBarrier1;
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
                    highScore = HighScoresType.Cl0;
                    MenuItems = 3;
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
