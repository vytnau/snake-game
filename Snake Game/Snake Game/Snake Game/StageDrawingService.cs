using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Snake_Game
{
    class StageDrawingService
    {
        public SpriteFont Font {set; get;}
        public StageDrawingService()
        {
        }

        public void DrawStage(SpriteBatch batch, GameStageTexture stageTexture, TimeSpan levelTime, string points, int lives)
        {
            batch.Begin();
            batch.Draw(stageTexture.Background, Vector2.Zero, Color.White);
            batch.Draw(stageTexture.Wall1, Vector2.Zero, Color.White);

            batch.Draw(stageTexture.Panel, new Vector2(10, 460), Color.White);
            batch.Draw(stageTexture.TLife, new Vector2(70, 480), Color.White);
            DrawLiVes(batch, stageTexture, lives);

            batch.Draw(stageTexture.TTIme, new Vector2(300, 482), Color.White);
            batch.Draw(stageTexture.RadarBackg, new Vector2(460, 467), Color.White);
            batch.Draw(stageTexture.Radar, new Vector2(460, 467), Color.White);
            batch.Draw(stageTexture.TPoints, new Vector2(620, 475), Color.White);  
            batch.DrawString(Font, ConvertTime(levelTime), new Vector2(308, 510), Color.White);
            batch.DrawString(Font, points , new Vector2(650, 510), Color.White);
            batch.End();
        }

        private string ConvertTime(TimeSpan levelTime)
        {
            String time;
            if (levelTime.Minutes < 10)
            {
                time = "0" + levelTime.Minutes.ToString();
            }
            else
            {
                time = levelTime.Minutes.ToString();
            }
            if (levelTime.Seconds < 10)
            {
                time += ":0" + levelTime.Seconds.ToString();
            }
            else
            {
                time += ":" + levelTime.Seconds.ToString();
            }            
            return time;
        }

        private void DrawLiVes(SpriteBatch batch, GameStageTexture stageTexture, int lives)
        {
            for (int i = 0; i < lives; i++)
            {
                batch.Draw(stageTexture.LifeIcon, new Vector2(50 + 40*i, 510), Color.White);
            }
        }
    }
}
