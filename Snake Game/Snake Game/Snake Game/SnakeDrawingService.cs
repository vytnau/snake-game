using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using DataAccess;
using Microsoft.Xna.Framework;

namespace Snake_Game
{
    class SnakeDrawingService
    {
        readonly SnakeTexture[] snakeTexture;
        public SpriteBatch Batch { set; get; }
        public int SnkateType {set; get;}

        public SnakeDrawingService(int type, SnakeTexture[] snakeTexture)
        {
            SnkateType = type;
            this.snakeTexture = snakeTexture;
        }


        private void DrawSnakeHead(int i, int j, int orent)
        {
            if (orent == -1) 
            {
                Batch.Draw(snakeTexture[SnkateType].HeadLeft, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
            if (orent == 1) //galva
            {
                Batch.Draw(snakeTexture[SnkateType].HeadRight, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
            if (orent == 2) //galva
            {
                Batch.Draw(snakeTexture[SnkateType].HeadUp, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
            if (orent == -2) //galva
            {
                Batch.Draw(snakeTexture[SnkateType].HeadDown, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
        }

        private void DrawSnakeBody(int i, int j, int orent)
        {
            if (orent == 5)//kunas
            {
                Batch.Draw(snakeTexture[SnkateType].BodyLR, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
            if (orent== -5)//kunas
            {
                Batch.Draw(snakeTexture[SnkateType].BodyUD, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
        }

        private void DrawSnakeTail(int i, int j, int orent)
        {
            if (orent == 6)// uodega
            {
                Batch.Draw(snakeTexture[SnkateType].TailLeft, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
            if (orent == -6)// uodega
            {
                Batch.Draw(snakeTexture[SnkateType].TailRight, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
            if (orent == 7)// uodega
            {
                Batch.Draw(snakeTexture[SnkateType].TailUp, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
            if (orent == -7)//uodega
            {
                Batch.Draw(snakeTexture[SnkateType].TailDown, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
        }

        private void DrawSnakeAngle(int i, int j, int orent)
        {
            if (orent == 10)//kampai
            {
                Batch.Draw(snakeTexture[SnkateType].CornerRight, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
            if (orent == 11)
            {
                Batch.Draw(snakeTexture[SnkateType].CornerDown, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
            if (orent == 12)
            {
                Batch.Draw(snakeTexture[SnkateType].CornerLeft, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
            if (orent == 13)
            {
                Batch.Draw(snakeTexture[SnkateType].CornerUp, new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
            }
        }

        public void DrawSnake(int[,] stageMatrix)
        {
            int value;
            Batch.Begin();
            for (int i = 0; i < 25; i++)//60
            {
                for (int j = 0; j < 13; j++)//40
                {
                    value = stageMatrix[i, j];
                    if (value == -2 || value == -1 || value == 1 || value == 2)
                    {
                        DrawSnakeHead(i, j, value);
                    }
                    if (value == -5 || value == 5)
                    {
                        DrawSnakeBody(i, j, value);
                    }
                    if (value == -7 || value == -6 || value == 6 || value == 7)
                    {
                        DrawSnakeTail(i, j, value);
                    }      
                    if (value == 10 || value == 11 || value == 12 || value == 13)
                    {
                        DrawSnakeAngle(i, j, value);
                    }

                   
                    if (stageMatrix[i, j] == 8)//maistas
                    {
                       // Batch.DrawString(font, "2", new Vector2(i * 30 + 30, j * 30 + 30), Color.White);
                    }

                    //vabzdys
                    if (stageMatrix[i, j] == 3)
                    {
                        // Batch.DrawString(font, "3", new Vector2(i * 10, j * 10), Color.Black);
                    }

                }
            }
            Batch.End();
        }
    }
}
