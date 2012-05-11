using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Texture;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Snake_Game.DrawingService
{
    public class BarrierDrawingService
    {
        private BarrierTexture texture;
        public SpriteBatch Batch { set; get; }

        public BarrierDrawingService(BarrierTexture texture)
        {
            this.texture = texture;
        }

        public void DrawBarrier(int[,] stage)
        {
            Batch.Begin();
            for (int i = 0; i < 25; i++)//60
            {
                for (int j = 0; j < 13; j++)//40
                {
                    var value = stage[i, j];
                    if (value >= 20 && value <= 24)//kliūtys
                    {
                        Draw(i, j, value);
                    }             
                }
            }

            Batch.End();
        }

        private void Draw(int i, int j, int value)
        {
            switch (value)
            {
                case 20:
                    Batch.Draw(texture.Bush1, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
                    break;
                case 21:
                    Batch.Draw(texture.Bush2, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
                    break;
                case 22:
                    Batch.Draw(texture.Log1, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
                    break;
                case 23:
                    Batch.Draw(texture.Log2, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
                    break;
                case 24:
                    Batch.Draw(texture.Rock, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
                    break;
            }
        }
    }
}
