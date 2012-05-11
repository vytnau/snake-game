using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Texture;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Snake_Game
{
    public class RadarDrawingService
    {
        public SpriteBatch Batch { set; get; }
        RadarTexture texture;
        public RadarDrawingService(RadarTexture texture)
        {
            this.texture = texture;
        }

        public void DrawRadar(int[,] radarData)
        {
            Batch.Begin();
            Batch.Draw(texture.RadarBackg, new Vector2(460, 467), Color.White);
            SetPoint(radarData);
            Batch.Draw(texture.Radar, new Vector2(460, 467), Color.White);
            Batch.End();
        }

        private void SetPoint(int[,] radarData)
        {
            for (int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++){
                    if(radarData[i,j] == 1)
                        Batch.Draw(texture.FoodMark, new Vector2(477+i*5, 490+j*5), Color.White);
                }
            }
        }
    }
}
