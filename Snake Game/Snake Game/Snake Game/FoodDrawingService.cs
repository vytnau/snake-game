using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Microsoft.Xna.Framework.Graphics;

namespace Snake_Game
{
    class FoodDrawingService
    {
        FoodTexture texture;
        public SpriteBatch Batch { set; get; }

        public FoodDrawingService(FoodTexture texture, SpriteBatch batch)
        {
            this.texture = texture;
            this.Batch = batch;
        }

        public void DrawFood(int[,] matrix)
        {
             Batch.Begin();
             for (int i = 0; i < 25; i++)//60
             {
                 for (int j = 0; j < 13; j++)//40
                 {
                     if (matrix[i, j] == 8)//maistas
                     {
                         // Batch.DrawString(font, "2", new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
                     }

                     //vabzdys
                     if (matrix[i, j] == 3)
                     {
                         // Batch.DrawString(font, "3", new Vector2(i * 10, j * 10), Color.Black);
                     }
                 }
             }
             Batch.End();
        }
    }
}
