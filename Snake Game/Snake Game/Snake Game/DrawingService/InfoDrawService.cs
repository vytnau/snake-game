using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using DataAccess;
using Microsoft.Xna.Framework;

namespace Snake_Game
{
    public class InfoDrawService
    {
        private int POINTER_TIME = 25;
        private int time = 0;
        private bool drawSlash = false;
        public SpriteBatch Batch { set; get; }
        private InfoTexture texture;
        public SpriteFont Font { set; get; }

        public InfoDrawService(InfoTexture texture)
        {
            this.texture = texture;
            time = 0;
        }

        public void Draw(int lives)
        {
            if (lives > 0)
            {
                DrawHitScreen(lives);
            }
        }
        /// <summary>
        /// Piešiamas informacinis langas apie gyvatės atsimušimą.
        /// </summary>
        /// <param name="lives">Parametras nuskantis kiek gyvybių žaidėjas dar turi.</param>
        public void DrawHitScreen(int lives)
        {
            Batch.Begin();
            Batch.Draw(texture.BDarkLayer, Vector2.Zero, Color.White);
            Batch.Draw(texture.BSign, new Vector2(160, 0), Color.White);
            Batch.Draw(texture.LLostLive, new Vector2(270, 180), Color.White);
            Batch.Draw(texture.GSnakeHead, new Vector2(380, 230), Color.White);
            Batch.End();
        }

        public void DrawGameOver(String points, TimeSpan time)
        {
            Batch.Begin();
            Batch.Draw(texture.BDarkLayer, Vector2.Zero, Color.White);
            Batch.Draw(texture.BSign, new Vector2(160, 0), Color.White);
            Batch.Draw(texture.LGameOver, new Vector2(235, 160), Color.White);
            Batch.Draw(texture.LPlayerPoint, new Vector2(230, 200), Color.White);
            Batch.DrawString(Font, points, new Vector2(500 ,205), Color.Black);
            Batch.Draw(texture.LPlayerTime, new Vector2(230, 250), Color.White);
            Batch.DrawString(Font, FormatTime(time), new Vector2(520, 255), Color.Black);
            Batch.End();
        }

        private string FormatTime(TimeSpan time)
        {
            string timeFormat;
            if (time.Minutes < 10)
            {
                timeFormat = "0" + time.Minutes.ToString() + ":";
            }
            else
            {
                timeFormat = "0" + time.Minutes.ToString() + ":";
            }
            if (time.Seconds < 10)
            {
                timeFormat += "0" + time.Seconds.ToString();
            }
            else
            {
                timeFormat += time.Seconds.ToString();
            }
            return timeFormat;
        }

        public void DrawNewRecordWindow(string name)
        {
            //TODO:
            //Suprogramuoti sio lango piesima, t.y. pranesti apie pasiekta rekorda ir paprasyt
            //ivesti vartotojo varda.
            Batch.Begin();
            Batch.Draw(texture.BDarkLayer, Vector2.Zero, Color.White);
            Batch.Draw(texture.InputName, new Vector2(180, 100), Color.White);
            Batch.DrawString(Font, name, new Vector2(CalculatePos(name), 273), Color.Black);//260
            DrawSlash(name);
            Batch.End();
        }

        private int CalculatePos(string text)
        {
            int length = text.Length;
            return 400 - (length)*5; 
        }

        private void DrawSlash(string text)
        {
            time++;
            if (time == POINTER_TIME)
            {
                time = 0;
                if (drawSlash)
                    drawSlash = false;
                else
                    drawSlash = true;
            }
            if (drawSlash)
            {
                Batch.DrawString(Font, "|", new Vector2(Slash(text), 271), Color.Black);//260
            }
        }

        private int Slash(string text)
        {
            int length = text.Length;
            return 400 + (length) * 9; 
        }
    }
}
