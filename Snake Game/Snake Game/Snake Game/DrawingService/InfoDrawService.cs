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
        public SpriteBatch Batch { set; get; }
        private InfoTexture texture;
        public SpriteFont Font { set; get; }

        public InfoDrawService(InfoTexture texture)
        {
            this.texture = texture;
        }

        public void Draw(int lives)
        {
            if (lives > 0)
            {
                DrawHitScreen(lives);
            }
        }

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
    }
}
