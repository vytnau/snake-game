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
            Level
        }


        private List<string> MenuItems;
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
                if (iterator > MenuItems.Count - 1) iterator = MenuItems.Count - 1;
                if (iterator < 1) iterator = 1;
            }
        }

        public Meniu()
        {
            meniuState = MeniuState.Main;
            Title = "Meniu";
            MenuItems = new List<string>();
            MenuItems.Add("Pradeti zaidima");
            MenuItems.Add("Pagalba");
            MenuItems.Add("Baigti zaidima");
            MenuItems.Add("Baigti zaidima");
            MenuItems.Add("Baigti zaidima");
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
                    DrawGameType(batch, 1000, texture);
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

        private void DrawGameType(SpriteBatch batch, int screenWidth, MeniuTexture texture)
        {
            batch.Begin();
            batch.Draw(texture.background, Vector2.Zero, Color.White);
            batch.Draw(texture.gameTitle, new Vector2(500, 10), Color.White);
            batch.Draw(texture.signPole, new Vector2(620, 180), Color.White);
            System.Console.WriteLine(Iterator.ToString());
            if (Iterator == 1)
            {
                batch.Draw(texture.new_game_marked, new Vector2(555, 190), Color.White);
            }
            else
            {
                batch.Draw(texture.new_game, new Vector2(555, 190), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.highscores_marked, new Vector2(555, 260), Color.White);
            }
            else
            {
                batch.Draw(texture.highscores, new Vector2(555, 260), Color.White);
            }
            if (Iterator == 3)
            {
                batch.Draw(texture.help_marked, new Vector2(555, 320), Color.White);
            }
            else
            {
                batch.Draw(texture.help, new Vector2(555, 320), Color.White);
            }
            if (Iterator == 4)
            {
                batch.Draw(texture.quit_marked, new Vector2(555, 380), Color.White);
            }
            else
            {
                batch.Draw(texture.quit, new Vector2(555, 380), Color.White);
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
                batch.Draw(texture.new_game_marked, new Vector2(555, 190), Color.White);
            }
            else
            {
                batch.Draw(texture.new_game, new Vector2(555, 190), Color.White);
            }
            if (Iterator == 2)
            {
                batch.Draw(texture.highscores_marked, new Vector2(555, 260), Color.White);
            }
            else
            {
                batch.Draw(texture.highscores, new Vector2(555, 260), Color.White);
            }
            if (Iterator == 3)
            {
                batch.Draw(texture.help_marked, new Vector2(555, 320), Color.White);
            }
            else
            {
                batch.Draw(texture.help, new Vector2(555, 320), Color.White);
            }
            if (Iterator == 4)
            {
                batch.Draw(texture.quit_marked, new Vector2(555, 380), Color.White);
            }
            else
            {
                batch.Draw(texture.quit, new Vector2(555, 380), Color.White);
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
            return MenuItems.Count;
        }

        public string GetItem(int index)
        {
            return MenuItems[index];
        }

    /*    protected override void LoadContent()
        {
           // spriteBatch = new SpriteBatch(GraphicsDevice);
            mainBackground = Content.Load<Texture2D>("content\\Texture\\Meniu\\meniu");
        }*/
        public void Enter()
        {

        }
    }
}
