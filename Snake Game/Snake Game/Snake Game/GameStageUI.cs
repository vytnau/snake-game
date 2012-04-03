using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Snake_Game.ServiceContracts;
using Snake_Game.Service;

namespace Snake_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameStageUI : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        SpriteFont text;
        Vector2 direction;
        bool up;
        bool down;
        int millisecondsPerFrame = 70; //Update every 1 second
        int timeSinceLastUpdate = 0; //Accumulate the elapsed time
        private readonly IGameService game;

        public GameStageUI()
        {
            game = new GameService();
            graphics = new GraphicsDeviceManager(this);
            direction.X = 1;
            direction.Y = 1;
            up = true;
            down = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Content.RootDirectory = "Content";//Content
            //Snake Game\Snake GameContent\Arial.spritefont";
            font = Content.Load<SpriteFont>("Font\\Arial");
            text = Content.Load<SpriteFont>("Font\\Fontas");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState key = Keyboard.GetState();
            timeSinceLastUpdate += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timeSinceLastUpdate >= millisecondsPerFrame)
            {
                timeSinceLastUpdate = 0;                           

            if (key.IsKeyDown(Keys.Left))
            {
                if (direction.Y != 1)
                {
                    direction.X = -1;
                    direction.Y = 1;
                    up = true;
                    down = true;
                }
            }

            if (key.IsKeyDown(Keys.Right))
            {
                if (direction.Y != 1)
                {
                    direction.X = 1;
                    direction.Y = 1;
                    up = true;
                    down = true;
                }
            }

            if (key.IsKeyDown(Keys.Up))
            {
                if (up)
                {
                    down = false;
                    direction.X = 1;
                    direction.Y = -1;
                }
            }

            if (key.IsKeyDown(Keys.Down))
            {
                if (down)
                {
                    up = false;
                    direction.X = -1;
                    direction.Y = -1;
                }
            }

            game.SetMovment((int)direction.X, (int)direction.Y);
            //game.SetMovment(

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
  
                        } 
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            DrawStage();
            DrwaPlayerInfo();
            base.Draw(gameTime);
        }

        private void DrawStage()
        {
            int[,] matrix = game.GetGameStage();
            spriteBatch.Begin();
            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                            spriteBatch.DrawString(font, "0", new Vector2(i * 10, j * 10), Color.Black);
                    }
                    if (matrix[i, j] == 1)
                    {
                        spriteBatch.DrawString(font, "1", new Vector2(i * 10, j * 10), Color.Black);
                    }
                    if (matrix[i, j] == 2)
                    {
                        spriteBatch.DrawString(font, "2", new Vector2(i * 10, j * 10), Color.Black);
                    }
                }
            }
            spriteBatch.End();
        }

        private void DrwaPlayerInfo()
        {
            string point = game.GetPoints();
            string lives = game.GetLives();
            spriteBatch.Begin();            
            spriteBatch.DrawString(text, "zaidejas", new Vector2(680, 50), Color.Black);
            spriteBatch.DrawString(text, "Turimi taskai:", new Vector2(640, 80), Color.Black);
            spriteBatch.DrawString(text, point, new Vector2(680, 100), Color.Black);
            spriteBatch.DrawString(text, "Gyvybes:", new Vector2(640, 120), Color.Black);
            spriteBatch.DrawString(text, lives, new Vector2(730, 120), Color.Black);
            spriteBatch.End();
        }
    }
}
