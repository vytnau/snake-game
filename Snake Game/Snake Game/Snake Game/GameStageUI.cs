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
using DataAccess;


namespace Snake_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameStageUI : Microsoft.Xna.Framework.Game
    {       
        public enum GameStates
        {
            Menu,
            Running,
            Pause,
            End
        }



        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        SpriteFont text;
        Vector2 direction;
        MeniuTexture meniuTexture;


        bool up;
        bool down;
        int millisecondsPerFrame = 70; //Update every 1 second
        int timeSinceLastUpdate = 0; //Accumulate the elapsed time
        private readonly IGameService game;
        public static GameStates gamestate;
        private Meniu menu;

        public GameStageUI()
        {
            game = new GameService();
            menu = new Meniu();
            meniuTexture = new MeniuTexture();
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
            //InitGraphicsMode(1280, 720, false);

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 449;
            graphics.ApplyChanges();
            millisecondsPerFrame = 100; //Update every 1 second
            gamestate = GameStates.Menu;
            //gamestate = GameStates.Running;
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

            meniuTexture.background = Content.Load<Texture2D>("Texture\\Meniu\\meniu_background");
            meniuTexture.gameTitle = Content.Load<Texture2D>("Texture\\Meniu\\Main\\gameTitle");
            meniuTexture.signPole = Content.Load<Texture2D>("Texture\\Meniu\\signPole");
            meniuTexture.sNew_game = Content.Load<Texture2D>("Texture\\Meniu\\Main\\newGame");
            meniuTexture.sNew_game_marked = Content.Load<Texture2D>("Texture\\Meniu\\Main\\newGameMarked");
            meniuTexture.sHighscores = Content.Load<Texture2D>("Texture\\Meniu\\Main\\highscores");
            meniuTexture.sHighscores_marked = Content.Load<Texture2D>("Texture\\Meniu\\Main\\highscoresMarked");
            meniuTexture.sHelp = Content.Load<Texture2D>("Texture\\Meniu\\Main\\help");
            meniuTexture.sHelp_marked = Content.Load<Texture2D>("Texture\\Meniu\\Main\\helpMarked");
            meniuTexture.sQuit = Content.Load<Texture2D>("Texture\\Meniu\\Main\\quit");
            meniuTexture.sQuit_marked = Content.Load<Texture2D>("Texture\\Meniu\\Main\\quitMarked");

            //choose
            meniuTexture.sArcade = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\arcade");
            meniuTexture.sArcade_marked = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\arcadeMarked");
            meniuTexture.sBack = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\back");
            meniuTexture.sBack_marked = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\backMarked");
            meniuTexture.sClassical = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\classical");
            meniuTexture.sClassical_marked = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\classicalMarked");
            meniuTexture.gameTypeTitle = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\chooseTypeTitle");

            //difficult level
            meniuTexture.sEasy = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\easy");
            meniuTexture.sEasy_marked = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\easyMarked");
            meniuTexture.sMedium = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\medium");
            meniuTexture.sMedium_marked = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\mediumMarked");
            meniuTexture.sHard = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\hard");
            meniuTexture.sHard_marked = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\hardMarked");
            

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
                if (gamestate == GameStates.Running)
                {


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
                }
            
                else if (gamestate == GameStates.Menu)
                {

                    if (key.IsKeyDown(Keys.Down))
                    {
                        menu.Iterator++;
                    }
                    else if (key.IsKeyDown(Keys.Up))
                    {
                        menu.Iterator--;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        menu.Enter();
                    }

                    /*if (input.MenuSelect)
                    {
                        if (menu.Iterator == 0)
                        {
                            gamestate = GameStates.Running;
                            SetUpSingle();
                        }
                        else if (menu.Iterator == 1)
                        {
                            gamestate = GameStates.Running;
                            SetUpMulti();
                        }
                        else if (menu.Iterator == 2)
                        {
                            this.Exit();
                        }
                        menu.Iterator = 0;
                    }*/
                }
            }
            //game.SetMovment(

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
  
                         
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (gamestate == GameStates.Running)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                DrawStage();
                DrwaPlayerInfo();
            }
            else if (gamestate == GameStates.Menu)
            {
                menu.DrawMenu(this.spriteBatch, 700, this.font, this.meniuTexture);
            }
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
                          //  spriteBatch.DrawString(font, "0", new Vector2(i * 10, j * 10), Color.Black);
                    }
                    if (matrix[i, j] == 1)
                    {
                        spriteBatch.DrawString(font, "1", new Vector2(i * 10, j * 10), Color.Black);
                    }
                    if (matrix[i, j] == 2)
                    {
                        spriteBatch.DrawString(font, "2", new Vector2(i * 10, j * 10), Color.Black);
                    }
                    if (matrix[i, j] == 3)
                    {
                        spriteBatch.DrawString(font, "3", new Vector2(i * 10, j * 10), Color.Black);
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
/*
    /// <summary>
        /// Attempt to set the display mode to the desired resolution.  Itterates through the display
        /// capabilities of the default graphics adapter to determine if the graphics adapter supports the
        /// requested resolution.  If so, the resolution is set and the function returns true.  If not,
        /// no change is made and the function returns false.
        /// </summary>
        /// <param name="iWidth">Desired screen width.</param>
        /// <param name="iHeight">Desired screen height.</param>
        /// <param name="bFullScreen">True if you wish to go to Full Screen, false for Windowed Mode.</param>
        private bool InitGraphicsMode(int iWidth, int iHeight, bool bFullScreen)
        {
            // If we aren't using a full screen mode, the height and width of the window can
            // be set to anything equal to or smaller than the actual screen size.
            if (bFullScreen == false)
            {
                if ((iWidth <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width)
                    && (iHeight <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height))
                {
                    graphics.PreferredBackBufferWidth = iWidth;
                    graphics.PreferredBackBufferHeight = iHeight;
                    graphics.IsFullScreen = bFullScreen;
                    graphics.ApplyChanges();
                    return true;
                }
            }
            else
            {
                // If we are using full screen mode, we should check to make sure that the display
                // adapter can handle the video mode we are trying to set.  To do this, we will
                // iterate thorugh the display modes supported by the adapter and check them against
                // the mode we want to set.
                foreach (DisplayMode dm in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
                {
                    // Check the width and height of each mode against the passed values
                    if ((dm.Width == iWidth) && (dm.Height == iHeight))
                    {
                        // The mode is supported, so set the buffer formats, apply changes and return
                        graphics.PreferredBackBufferWidth = iWidth;
                        graphics.PreferredBackBufferHeight = iHeight;
                        graphics.IsFullScreen = bFullScreen;
                        graphics.ApplyChanges();
                        return true;
                    }
                }
            }
            return false;
        }*/
}
