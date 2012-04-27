using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Meniu 
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
            Quit
        }


        private int MenuItems;
        private int iterator;
        private MeniuState meniuState;
        public string InfoText { get; set; }
        public string Title { get; set; }

        public int Iterator
        {
            get
            {
                return iterator;
            }
            set
            {
                iterator = value;
                if (iterator > MenuItems) iterator = MenuItems;
                if (iterator < 1) iterator = 1;
            }
        }

        public Meniu()
        {
            MenuItems = 4;
            meniuState = MeniuState.Main;
            Title = "Meniu";
            Iterator = 0;
            InfoText = string.Empty;
        }

        public void DrawMenu(SpriteBatch batch, int screenWidth, SpriteFont arial, MeniuTexture texture)
        {
            switch (meniuState)
            {
                case MeniuState.Main:
                    DrawMainMeniu(batch, 1000, texture);
                    break;
                case MeniuState.GameType:
                    DrawGameType(batch, texture);
                    break;
                case MeniuState.Difficulty:
                    break;
                case MeniuState.ChooseSnake:
                    break;
                case MeniuState.Highscores:
                    break;
                case MeniuState.Level:
                    break;
            }
          
        }

        //zaidimo rezimo pasirinkimas
        private void DrawGameType(SpriteBatch batch, MeniuTexture texture)
        {
            batch.Begin();
            batch.Draw(texture.background, Vector2.Zero, Color.White);
            batch.Draw(texture.gameTypeTitle, new Vector2(380, 30), Color.White);
            batch.Draw(texture.signPole, new Vector2(620, 180), Color.White);
            System.Console.WriteLine(Iterator.ToString());
            if (Iterator == 1)
            {
                batch.Draw(texture.sClassical_marked, new Vector2(555, 190), Color.White);
            }
            else
            {
                batch.Draw(texture.sClassical, new Vector2(555, 190), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.sArcade_marked, new Vector2(555, 260), Color.White);
            }
            else
            {
                batch.Draw(texture.sArcade, new Vector2(555, 260), Color.White);
            }
            if (Iterator == 3)
            {
                batch.Draw(texture.sBack_marked, new Vector2(555, 320), Color.White);
            }
            else
            {
                batch.Draw(texture.sBack, new Vector2(555, 320), Color.White);
            }
            batch.End();
        }

        //pakoreguoti kintamuosius
        private void DrawMainMeniu(SpriteBatch batch, int screenWidth, MeniuTexture texture)
        {
            batch.Begin();
            batch.Draw(texture.background, Vector2.Zero, Color.White);
            batch.Draw(texture.gameTitle, new Vector2(500, 10), Color.White);
            batch.Draw(texture.signPole, new Vector2(620, 180), Color.White);
            System.Console.WriteLine(Iterator.ToString());
            if (Iterator == 1)
            {
                batch.Draw(texture.sNew_game_marked, new Vector2(555, 190), Color.White);
            }
            else
            {
                batch.Draw(texture.sNew_game, new Vector2(555, 190), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.sHighscores_marked, new Vector2(555, 260), Color.White);
            }
            else
            {
                batch.Draw(texture.sHighscores, new Vector2(555, 260), Color.White);
            }
            if (Iterator == 3)
            {
                batch.Draw(texture.sHelp_marked, new Vector2(555, 320), Color.White);
            }
            else
            {
                batch.Draw(texture.sHelp, new Vector2(555, 320), Color.White);
            }
            if (Iterator == 4)
            {
                batch.Draw(texture.sQuit_marked, new Vector2(555, 380), Color.White);
            }
            else
            {
                batch.Draw(texture.sQuit, new Vector2(555, 380), Color.White);
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
                    break;
                case MeniuState.ChooseSnake:
                    break;
                case MeniuState.Highscores:
                    break;
                case MeniuState.Level:
                    break;
            }
        }

        private void SelectGameType()
        {
            switch (Iterator)
            {
                case 1:
                    meniuState = MeniuState.ChooseSnake;
                    MenuItems = 4;
                    break;
                case 2:
                    meniuState = MeniuState.Level;
                    MenuItems = 2;///????????????????????????????
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
