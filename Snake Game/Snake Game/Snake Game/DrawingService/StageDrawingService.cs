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
        public SpriteBatch Batch { set; get; }
        private GraphicsDevice graphicsDevice;
        public GraphicsDevice GraphicsDevice
        {
            get { return graphicsDevice;}   
            set
            {
                graphicsDevice = value;
                graphicsDevice.PresentationParameters.BackBufferHeight = 575;
                var pp = graphicsDevice.PresentationParameters;
                mainScene = new RenderTarget2D(graphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
                lightMask = new RenderTarget2D(graphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
                graphicsDevice.SamplerStates[1] = SamplerState.LinearClamp;
            }                
            
        }
        private GameStageTexture stageTexture;

        private RenderTarget2D mainScene;
        private RenderTarget2D lightMask;
        private Effect lightingEffect;

        public StageDrawingService(GameStageTexture texture)
        {
            stageTexture = texture;

            /*var pp = GraphicsDevice.PresentationParameters;
            mainScene = new RenderTarget2D(GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
            lightMask = new RenderTarget2D(GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);*/
        }

        public void DrawStage(TimeSpan levelTime, string points, int lives)
        {
            Batch.Begin();
            Batch.Draw(stageTexture.Background, Vector2.Zero, Color.White);
            Batch.Draw(stageTexture.Wall1, Vector2.Zero, Color.White);

            DrawPlayerInfo(levelTime, points, lives);
            Batch.End();
        }

        private void DrawPlayerInfo(TimeSpan levelTime, string points, int lives)
        {
            Batch.Draw(stageTexture.Panel, new Vector2(10, 460), Color.White);
            Batch.Draw(stageTexture.TLife, new Vector2(70, 480), Color.White);
            DrawLiVes(lives);

            Batch.Draw(stageTexture.TTIme, new Vector2(300, 482), Color.White);

            Batch.Draw(stageTexture.TPoints, new Vector2(620, 475), Color.White);
            Batch.DrawString(Font, ConvertTime(levelTime), new Vector2(308, 510), Color.White);
            Batch.DrawString(Font, points, new Vector2(650, 510), Color.White);
        }

        public void DrawFog()
        {
            //piesiamas backgroundas
            graphicsDevice.SetRenderTarget(mainScene);
            graphicsDevice.Clear(Color.Black);

            Batch.Begin();
            Batch.Draw(stageTexture.Background, Vector2.Zero, Color.White);
            Batch.Draw(stageTexture.Wall2, Vector2.Zero, Color.White);
            
            Batch.End();
            //graphicsDevice.SetRenderTarget(null);
        }

        public void DrawPlayerPanelInFog()
        {
            Batch.Begin();
            Batch.Draw(stageTexture.PanelLayer, new Vector2(10, 460), Color.White);
            Batch.End();
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

        private void DrawLiVes(int lives)
        {
            for (int i = 0; i < lives; i++)
            {
                Batch.Draw(stageTexture.LifeIcon, new Vector2(50 + 40*i, 510), Color.White);
            }
        }

        public void DrawStageInFogSquare(LinkedList<Vector2> head, TimeSpan levelTime, string points, int lives)
        {

            Vector2 leftUpCorner = head.ElementAt(0);
            graphicsDevice.SetRenderTarget(lightMask);
            graphicsDevice.Clear(Color.Black);
            //Juodas fonas
            Batch.Begin();
            Batch.Draw(stageTexture.NightBackground, Vector2.Zero, Color.White);
            Batch.End();
            

            //apskritimas
            Batch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            Batch.Draw(stageTexture.NightSquare, new Vector2(leftUpCorner.X * 30 - 30, leftUpCorner.Y * 30 - 30), Color.White);
            Batch.End();
            graphicsDevice.SetRenderTarget(null);




            graphicsDevice.Clear(Color.White);

            Batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            stageTexture.LightEffect.Parameters["lightMask"].SetValue(lightMask);
            stageTexture.LightEffect.CurrentTechnique.Passes[0].Apply();
            Batch.Draw(mainScene, Vector2.Zero, Color.White);
            Batch.End();

            Batch.Begin();
            DrawPlayerInfo(levelTime, points, lives);
            Batch.Draw(stageTexture.PanelLayer, new Vector2(10, 460), Color.White); 
            Batch.End();
        }
    }
}
