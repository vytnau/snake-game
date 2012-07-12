using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Snake_Game
{
    class FoodDrawingService
    {
        FoodTexture texture;
        public SpriteBatch Batch { set; get; }

        public FoodDrawingService(FoodTexture texture)
        {
            this.texture = texture;
        }

        public void Draw(int[,] matrix)
        {
            Batch.Begin();
            for (int i = 0; i < 25; i++)//60
            {
                for (int j = 0; j < 13; j++)//40
                {
                    var value = matrix[i, j];
                    if (value == 8 || value == -8)//maistas
                    {
                        DrawFood(i, j, value);
                        // Batch.DrawString(font, "2", new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
                    }

                    //vabzdys
                    if (value >= 40 && value < 44)
                        DrawBug(i, j, value);
                    
                }
            }
            Batch.End();
        }


        private void DrawFood(int i, int j, int value)
        {
            if (value == 8)
                Batch.Draw(texture.Mushroom, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);                
            else
                Batch.Draw(texture.Apple, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
        }

        private void DrawBug(int i, int j, int value)
        {
            if (value == 40)
                Batch.Draw(texture.BugR, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            else if (value == 41)
                Batch.Draw(texture.BugU, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            else if (value == 42)
                Batch.Draw(texture.BugL, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            else
                Batch.Draw(texture.BugD, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
        }

    }

}
