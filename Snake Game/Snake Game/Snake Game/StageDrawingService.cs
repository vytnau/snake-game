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
        public StageDrawingService()
        {

        }

        public void DrawStage(SpriteBatch batch, GameStageTexture stageTexture)
        {
            batch.Begin();
            batch.Draw(stageTexture.Background, Vector2.Zero, Color.White);
            batch.Draw(stageTexture.Wall1, Vector2.Zero, Color.White);

            batch.Draw(stageTexture.Panel, new Vector2(10, 460), Color.White);
            batch.Draw(stageTexture.TLife, new Vector2(70, 480), Color.White);
            batch.Draw(stageTexture.LifeIcon, new Vector2(50, 510), Color.White);
            batch.Draw(stageTexture.LifeIcon, new Vector2(90, 510), Color.White);
            batch.Draw(stageTexture.LifeIcon, new Vector2(130, 510), Color.White);
            batch.Draw(stageTexture.LifeIcon, new Vector2(170, 510), Color.White);
            batch.Draw(stageTexture.LifeIcon, new Vector2(210, 510), Color.White);

            batch.Draw(stageTexture.TTIme, new Vector2(300, 482), Color.White);
            batch.Draw(stageTexture.RadarBackg, new Vector2(460, 467), Color.White);
            batch.Draw(stageTexture.Radar, new Vector2(460, 467), Color.White);
            batch.Draw(stageTexture.TPoints, new Vector2(620, 475), Color.White);

            //Batch.DrawString(font, "1:20", new Vector2(320, 520), Color.White);
            batch.End();
        }
    }
}
