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
using DataAccess.Texture;
using Snake_Game.DrawingService;


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
            Hit,
            End
        }



        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        SpriteFont text;
        Vector2 direction;
        MeniuTexture meniuTexture;
        GameStageTexture stageTexture;        
        SnakeTexture[] snakeTexture = new SnakeTexture[3];
        FoodTexture foodTexture;
        InfoTexture infoWindTexture;
        RadarTexture radarTexture;
        BarrierTexture barrierTexture;
        SnakeDrawingService snakeDraw;
        StageDrawingService stageDraw;
        FoodDrawingService foodDraw;
        InfoDrawService infoDraw;
        RadarDrawingService radarDraw;
        BarrierDrawingService barrierDraw;
        TimeSpan levelTime; 
        KeyboardState oldKeyState;

        Texture2D kvad;


        bool up;
        bool down;
        int millisecondsPerFrame = 70; //Update every 1 second
        int timeSinceLastUpdate = 0; //Accumulate the elapsed time
        private IGameService game;
        public static GameStates gamestate;
        private Meniu meniu;

        public GameStageUI()
        {
            game = new GameService();
            meniu = new Meniu();
            meniuTexture = new MeniuTexture();
            stageTexture = new GameStageTexture();
            snakeTexture[0] = new SnakeTexture();
            snakeTexture[1] = new SnakeTexture();
            snakeTexture[2] = new SnakeTexture();
            foodTexture = new FoodTexture();
            infoWindTexture = new InfoTexture();
            radarTexture = new RadarTexture();
            barrierTexture = new BarrierTexture();
            graphics = new GraphicsDeviceManager(this);           
            stageDraw = new StageDrawingService();
            snakeDraw = new SnakeDrawingService(0, snakeTexture);
            foodDraw = new FoodDrawingService(foodTexture);
            infoDraw = new InfoDrawService(infoWindTexture);
            radarDraw = new RadarDrawingService(radarTexture);
            barrierDraw = new BarrierDrawingService(barrierTexture);
            direction.X = -1;
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
            graphics.PreferredBackBufferHeight = 575;//449;
           // graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
            //graphics.PreferMultiSampling = false;
            //this.graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            millisecondsPerFrame =120; //Update every 1 second
            //gamestate = GameStates.Menu;
            gamestate = GameStates.Running;
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
            snakeDraw.Batch = spriteBatch;
            foodDraw.Batch = spriteBatch;
            infoDraw.Batch = spriteBatch;
            radarDraw.Batch = spriteBatch;
            barrierDraw.Batch = spriteBatch;
            Content.RootDirectory = "Content";//Content
            //Snake Game\Snake GameContent\Arial.spritefont";
            text = Content.Load<SpriteFont>("Font\\Arial");
            font = Content.Load<SpriteFont>("Font\\Fontas");
            stageDraw.Font = font;
            infoDraw.Font = Content.Load<SpriteFont>("Font\\bigerFont");//font;
            LoadMeniuContent();
            LoadGameStageContent();
            LoadInfoWindowContent();

            kvad = Content.Load<Texture2D>("Texture\\Game\\Snake\\kvadratas");
            // TODO: use this.Content to load your game content here
        }

        private void LoadInfoWindowContent(){
            infoWindTexture.BSign = Content.Load<Texture2D>("Texture\\Game\\InfoWindow\\sign");
            infoWindTexture.LLostLive = Content.Load<Texture2D>("Texture\\Game\\InfoWindow\\lostLive");
            infoWindTexture.GSnakeHead = Content.Load<Texture2D>("Texture\\Game\\InfoWindow\\head");
            infoWindTexture.LPlayerPoint = Content.Load<Texture2D>("Texture\\Game\\InfoWindow\\playerPoints");
            infoWindTexture.LPlayerTime = Content.Load<Texture2D>("Texture\\Game\\InfoWindow\\playerTime");
            infoWindTexture.LGameOver = Content.Load<Texture2D>("Texture\\Game\\InfoWindow\\lostAllLives");

            infoWindTexture.BDarkLayer = Content.Load<Texture2D>("Texture\\Game\\Pauze\\bigDarkLayer");
        }

        /// <summary>
        /// Iškviečiami metodai, įkrauti žaidimo lauko ir kitas tekstūras reikalingas žaisti žaidimą.
        /// </summary>
        private void LoadGameStageContent()
        {
            LoadStageBackgroundContent();
            LoadSnakeContent();
            LoadFoodContent();
            LoadRadarContent();
            LoadBarrierContent();
        }

        private void LoadFoodContent()
        {
            foodTexture.Apple = Content.Load<Texture2D>("Texture\\Game\\Food\\apple");
            foodTexture.Mushroom = Content.Load<Texture2D>("Texture\\Game\\Food\\mushroom");
        }


        private void LoadSnakeContent()
        {
            LoadSnake1Content();
            LoadSnake2Content();
            LoadSnake3Content();
        }

        /// <summary>
        /// Įkraunamos pirmos gyvatės tekstūros. 
        /// </summary>
        private void LoadSnake1Content()
        {
            snakeTexture[0].BodyLR = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\bodyRight");
            snakeTexture[0].BodyUD = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\bodyUp");
            snakeTexture[0].CornerRight = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\cornerDR");
            snakeTexture[0].CornerLeft = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\cornerLD");
            snakeTexture[0].CornerUp = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\cornerLU");
            snakeTexture[0].CornerDown = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\cornerUR");
            snakeTexture[0].TailDown = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\tailDown");
            snakeTexture[0].TailUp = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\tailUp");
            snakeTexture[0].TailLeft = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\tailLeft");
            snakeTexture[0].TailRight = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\tailRight");
            snakeTexture[0].HeadDown = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\headDown");
            snakeTexture[0].HeadLeft = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\headLeft");
            snakeTexture[0].HeadRight = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\headRight");
            snakeTexture[0].HeadUp = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake1\\headUp");
        }
        /// <summary>
        /// Įkraunamos antros gyvatės tekstūros. 
        /// </summary>
        private void LoadSnake2Content()
        {
            snakeTexture[1].BodyLR = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\bodyRight");
            snakeTexture[1].BodyUD = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\bodyUp");
            snakeTexture[1].CornerRight = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\cornerDR");
            snakeTexture[1].CornerLeft = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\cornerLD");
            snakeTexture[1].CornerUp = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\cornerLU");
            snakeTexture[1].CornerDown = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\cornerUR");
            snakeTexture[1].TailDown = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\tailDown");
            snakeTexture[1].TailUp = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\tailUp");
            snakeTexture[1].TailLeft = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\tailLeft");
            snakeTexture[1].TailRight = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\tailRight");
            snakeTexture[1].HeadDown = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\headDown");
            snakeTexture[1].HeadLeft = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\headLeft");
            snakeTexture[1].HeadRight = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\headRight");
            snakeTexture[1].HeadUp = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake2\\headUp");
        }

        /// <summary>
        /// Įkraunamos trečios gyvatės tekstūros. 
        /// </summary>
        private void LoadSnake3Content()
        {
            snakeTexture[2].BodyLR = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\bodyRight");
            snakeTexture[2].BodyUD = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\bodyUp");
            snakeTexture[2].CornerRight = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\cornerDR");
            snakeTexture[2].CornerLeft = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\cornerLD");
            snakeTexture[2].CornerUp = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\cornerLU");
            snakeTexture[2].CornerDown = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\cornerUR");
            snakeTexture[2].TailDown = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\tailDown");
            snakeTexture[2].TailUp = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\tailUp");
            snakeTexture[2].TailLeft = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\tailLeft");
            snakeTexture[2].TailRight = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\tailRight");
            snakeTexture[2].HeadDown = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\headDown");
            snakeTexture[2].HeadLeft = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\headLeft");
            snakeTexture[2].HeadRight = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\headRight");
            snakeTexture[2].HeadUp = Content.Load<Texture2D>("Texture\\Game\\Snake\\Snake3\\headUp");
        }

        /// <summary>
        /// Įkraunamos žaidimo lango foninės tekstūros.
        /// </summary>
        private void LoadStageBackgroundContent()
        {
            stageTexture.Background = Content.Load<Texture2D>("Texture\\Game\\Background\\background");
            stageTexture.LifeIcon = Content.Load<Texture2D>("Texture\\Game\\Background\\lifeIcon");
            stageTexture.Panel = Content.Load<Texture2D>("Texture\\Game\\Background\\panel");
            stageTexture.TLife = Content.Load<Texture2D>("Texture\\Game\\Background\\life");
            stageTexture.TPoints = Content.Load<Texture2D>("Texture\\Game\\Background\\points");
            stageTexture.TTIme = Content.Load<Texture2D>("Texture\\Game\\Background\\time");
            stageTexture.Wall1 = Content.Load<Texture2D>("Texture\\Game\\Background\\bushWall");
            stageTexture.Wall2 = Content.Load<Texture2D>("Texture\\Game\\Background\\logWall");
        }

        private void LoadRadarContent()
        {
            radarTexture.Radar = Content.Load<Texture2D>("Texture\\Game\\Radar\\radar");
            radarTexture.RadarBackg = Content.Load<Texture2D>("Texture\\Game\\Radar\\radarBackground");
            radarTexture.FoodMark = Content.Load<Texture2D>("Texture\\Game\\Radar\\foodMark");
        }

        private void LoadBarrierContent()
        {
            barrierTexture.Bush1 = Content.Load<Texture2D>("Texture\\Game\\Barriers\\bush1");
            barrierTexture.Bush2 = Content.Load<Texture2D>("Texture\\Game\\Barriers\\bush2");
            barrierTexture.Log1 = Content.Load<Texture2D>("Texture\\Game\\Barriers\\log");
            barrierTexture.Log2 = Content.Load<Texture2D>("Texture\\Game\\Barriers\\logUp");
            barrierTexture.Rock = Content.Load<Texture2D>("Texture\\Game\\Barriers\\rock");
        }


        /// <summary>
        /// Iškviečiami metodai įkrauti reikalingas Meniu tekstūras.
        /// </summary>
        private void LoadMeniuContent()
        {
            LoadMainMeniuContent();
            LoadGameTypeMeniuContent();
            LoadSnakeChooseMeniuContent();
            LoadDifficultMeniuContent();
            LoadArcadeLevelsMeniuContent();
            LoadHighScoresmeniuContent();
            LoadHelpMeniuContent();
            LoadGamePauseContent();
        }

        /// <summary>
        /// Įkraunamos žaidimo pauzės lango tekstūros
        /// </summary>
        private void LoadGamePauseContent()
        {
            meniuTexture.TMeniu = Content.Load<Texture2D>("Texture\\Game\\Pauze\\backToMeniu");
            meniuTexture.TMeniuMarked = Content.Load<Texture2D>("Texture\\Game\\Pauze\\backToMeniuMarked");
            meniuTexture.TResume = Content.Load<Texture2D>("Texture\\Game\\Pauze\\resume");
            meniuTexture.TResumeMarked = Content.Load<Texture2D>("Texture\\Game\\Pauze\\resumeMarked");
            meniuTexture.PauseSign = Content.Load<Texture2D>("Texture\\Game\\Pauze\\pauzeSign");
            meniuTexture.BigDarkLayer = Content.Load<Texture2D>("Texture\\Game\\Pauze\\bigDarkLayer");
        }

        /// <summary>
        /// Įkraunamos pagrininio Meniu tekstūros.
        /// </summary>
        private void LoadMainMeniuContent()
        {
            meniuTexture.Background = Content.Load<Texture2D>("Texture\\Meniu\\meniu_background");
            meniuTexture.GameTitle = Content.Load<Texture2D>("Texture\\Meniu\\Main\\gameTitle");
            meniuTexture.SignPole = Content.Load<Texture2D>("Texture\\Meniu\\signPole");
            meniuTexture.SNew_game = Content.Load<Texture2D>("Texture\\Meniu\\Main\\newGame");
            meniuTexture.SNew_game_marked = Content.Load<Texture2D>("Texture\\Meniu\\Main\\newGameMarked");
            meniuTexture.SHighscores = Content.Load<Texture2D>("Texture\\Meniu\\Main\\highscores");
            meniuTexture.SHighscores_marked = Content.Load<Texture2D>("Texture\\Meniu\\Main\\highscoresMarked");
            meniuTexture.SHelp = Content.Load<Texture2D>("Texture\\Meniu\\Main\\help");
            meniuTexture.SHelp_marked = Content.Load<Texture2D>("Texture\\Meniu\\Main\\helpMarked");
            meniuTexture.SQuit = Content.Load<Texture2D>("Texture\\Meniu\\Main\\quit");
            meniuTexture.SQuit_marked = Content.Load<Texture2D>("Texture\\Meniu\\Main\\quitMarked");
        }
        /// <summary>
        /// Įkraunamos žaidimo tipo pasirinkimo tekstūros.
        /// </summary>
        private void LoadGameTypeMeniuContent()
        {
            meniuTexture.SArcade = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\arcade");
            meniuTexture.SArcade_marked = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\arcadeMarked");
            meniuTexture.SBack = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\back");
            meniuTexture.SBack_marked = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\backMarked");
            meniuTexture.SClassical = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\classical");
            meniuTexture.SClassical_marked = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\classicalMarked");
            meniuTexture.GameTypeTitle = Content.Load<Texture2D>("Texture\\Meniu\\ChooseType\\chooseTypeTitle");
        }
        /// <summary>
        /// Įkraunamos gyvatės pasirinkimo tekstūros.
        /// </summary>
        private void LoadSnakeChooseMeniuContent()
        {
            meniuTexture.SSnake1 = Content.Load<Texture2D>("Texture\\Meniu\\ChooseSnake\\snakeArrow1");
            meniuTexture.SSnake1_marked = Content.Load<Texture2D>("Texture\\Meniu\\ChooseSnake\\snakeArrow1Marked");
            meniuTexture.SSnake2 = Content.Load<Texture2D>("Texture\\Meniu\\ChooseSnake\\snakeArrow2");
            meniuTexture.SSnake2_marked = Content.Load<Texture2D>("Texture\\Meniu\\ChooseSnake\\snakeArrow2Marked");
            meniuTexture.SSnake3 = Content.Load<Texture2D>("Texture\\Meniu\\ChooseSnake\\snakeArrow3");
            meniuTexture.SSnake3_marked = Content.Load<Texture2D>("Texture\\Meniu\\ChooseSnake\\snakeArrow3Marked");
            meniuTexture.BTreeSnake1 = Content.Load<Texture2D>("Texture\\Meniu\\ChooseSnake\\snake1");
            meniuTexture.BTreeSnake2 = Content.Load<Texture2D>("Texture\\Meniu\\ChooseSnake\\snake2");
            meniuTexture.BTreeSnake3 = Content.Load<Texture2D>("Texture\\Meniu\\ChooseSnake\\snake3");
            meniuTexture.ChooseSnakeTitle = Content.Load<Texture2D>("Texture\\Meniu\\ChooseSnake\\snakechooseTitle");
        }
        /// <summary>
        /// Įkraunamos žaidimo sudėtingumo tekstūros.
        /// </summary>
        private void LoadDifficultMeniuContent()
        {
            meniuTexture.DiffLevelTitle = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\difficultLevelTitle");
            meniuTexture.SEasy = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\easy");
            meniuTexture.SEasy_marked = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\easyMarked");
            meniuTexture.SMedium = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\medium");
            meniuTexture.SMedium_marked = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\mediumMarked");
            meniuTexture.SHard = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\hard");
            meniuTexture.SHard_marked = Content.Load<Texture2D>("Texture\\Meniu\\Difficult\\hardMarked");
        }
        /// <summary>
        /// Įkraunamos nuotykių rėžimo lygių pasirinkimo tekstūros.
        /// </summary>
        private void LoadArcadeLevelsMeniuContent()
        {
            meniuTexture.SBackS = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\back1");
            meniuTexture.SBackSMarked = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\back1Marked");
            meniuTexture.ChooseLevelTitle = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\chooseLevelTitle");
            meniuTexture.DarkLayer = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\darkLayer");
            meniuTexture.DarkSignPole = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\darkPole");
            meniuTexture.SLevel1 = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\level1");
            meniuTexture.SLevel1Marked = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\level1Marked");
            meniuTexture.SLevel2 = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\level2");
            meniuTexture.SLevel2Marked = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\level2Marked");
            meniuTexture.SLevel3 = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\level3");
            meniuTexture.SLevel3Marked = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\level3Marked");
            meniuTexture.SLevel4 = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\level4");
            meniuTexture.SLevel4Marked = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\level4Marked");
            meniuTexture.SLevel5 = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\level5");
            meniuTexture.SLevel5Marked = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\level5Marked");
            meniuTexture.SLevel6 = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\level6");
            meniuTexture.SLevel6Marked = Content.Load<Texture2D>("Texture\\Meniu\\Arcade\\level6Marked");
        }
        /// <summary>
        /// Įkraunamos pasiekimo lango tekstūros.
        /// </summary>
        private void LoadHighScoresmeniuContent()
        {
            meniuTexture.SBack2 = Content.Load<Texture2D>("Texture\\Meniu\\HighScores\\back2");
            meniuTexture.SBack2Marked = Content.Load<Texture2D>("Texture\\Meniu\\HighScores\\back2Marked");
            meniuTexture.HighScoresArc = Content.Load<Texture2D>("Texture\\Meniu\\HighScores\\highscoresArcade");
            meniuTexture.HighScoresCla = Content.Load<Texture2D>("Texture\\Meniu\\HighScores\\highscoresClas");
            meniuTexture.BNext = Content.Load<Texture2D>("Texture\\Meniu\\HighScores\\next");
            meniuTexture.BNextMarked = Content.Load<Texture2D>("Texture\\Meniu\\HighScores\\nextMarked");
        }
        /// <summary>
        /// Įkraunamos pagalbos lango tekstūros.
        /// </summary>
        private void LoadHelpMeniuContent()
        {
            meniuTexture.Help = Content.Load<Texture2D>("Texture\\Meniu\\Help\\help");
            meniuTexture.BDown = Content.Load<Texture2D>("Texture\\Meniu\\Help\\down");
            meniuTexture.BDownMarked = Content.Load<Texture2D>("Texture\\Meniu\\Help\\downMarked");
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
            if (gamestate == GameStates.Running)
            {
                levelTime += gameTime.ElapsedGameTime;
            }
            //KeyboardState key = Keyboard.GetState();             
            timeSinceLastUpdate += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timeSinceLastUpdate >= millisecondsPerFrame)
            {
                timeSinceLastUpdate = 0;
                if (gamestate == GameStates.Running)
                {                   
                    GamePlay();                    
                }
                else if (gamestate == GameStates.Menu)
                {
                    Meniu();
                }
                else if (gamestate == GameStates.Hit)
                {
                    InfoScreen();
                }
            }
            
            // TODO: Add your update logic here                        
            base.Update(gameTime);
        }

        private void GamePlay()
        {
            KeyboardState key = Keyboard.GetState();
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
                    System.Console.WriteLine("Up");

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
            if (key.IsKeyDown(Keys.Escape) && oldKeyState.IsKeyUp(Keys.Escape))
            {
                meniu.meniuState = MeniuState.Pause;
                gamestate = GameStates.Menu;
            }
            //game.SetMovment((int)direction.X, (int)direction.Y);
            GameStatus();
            oldKeyState = key;
        }

        private void GameStatus()
        {
            if (!game.SnakeHit())
            {
                game.SetMovment((int)direction.X, (int)direction.Y);
            }
            else
            {
                gamestate = GameStates.Hit;
            }
        }

        private void Meniu()
        {
            millisecondsPerFrame = 100;
            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Down) || key.IsKeyDown(Keys.Right))
            {
                meniu.Iterator++;
            }
            else if (key.IsKeyDown(Keys.Up) || key.IsKeyDown(Keys.Left))
            {
                meniu.Iterator--;
            }
            else if (key.IsKeyDown(Keys.Enter) && oldKeyState.IsKeyUp(Keys.Enter))
            {
                if (meniu.meniuState == MeniuState.Pause && gamestate == GameStates.Menu)
                {
                    ChangeScreenSizeToMeniu();//grazinama meniu rezoliucija
                }
                meniu.Enter();
            }
            if (meniu.meniuState == MeniuState.Main)
            {
                StartNewGame();
                levelTime = TimeSpan.Zero; 
            }
            if (meniu.meniuState == MeniuState.Play)
            {
                ChangeScreenSize();
                SetDifficult(meniu.Difficult);
                gamestate = GameStates.Running;
                snakeDraw.SnkateType = meniu.SnakeType;
            }

            if (meniu.meniuState == MeniuState.Pause)
            {
                if (key.IsKeyDown(Keys.Escape) && oldKeyState.IsKeyUp(Keys.Escape))
                {
                    SetDifficult(meniu.Difficult);
                    gamestate = GameStates.Running;
                }
            }
            if (meniu.meniuState == MeniuState.Quit)
            {
                this.Exit();
            }
            oldKeyState = key;
        }

        private void InfoScreen()
        {
            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Left) || key.IsKeyDown(Keys.Right) || key.IsKeyDown(Keys.Up) || key.IsKeyDown(Keys.Down)
                || key.IsKeyDown(Keys.Enter) || key.IsKeyDown(Keys.Escape))
            {                
                direction.X = -1;
                direction.Y = 1;
                up = true;
                down = true;
                game.NewGame();
                gamestate = GameStates.Running;
            }
        }

        /// <summary>
        /// Metodas skirtas nustatyti žaidimo sudėtingumą, t.y. parinkti 
        /// gyvatės greitį bei skiriamų taškų kiekį už suvalgytą gyvatės maistą. 
        /// </summary>
        /// <param name="level"></param>
        private void SetDifficult(int level)
        {
            switch (level)
            {
                case 1:
                    millisecondsPerFrame = 200;
                    game.SetPoints(5);
                    break;
                case 2:
                    millisecondsPerFrame = 120;
                    game.SetPoints(10);
                    break;
                case 3:
                    millisecondsPerFrame = 50;
                    game.SetPoints(25);
                    break;
            }
        }

        private void StartNewGame()
        {
            game = new GameService();
        }

        private void ChangeScreenSizeToMeniu()
        {
            graphics.PreferredBackBufferHeight = 449;
            graphics.ApplyChanges();
        }

        private void ChangeScreenSize()
        {
            graphics.PreferredBackBufferHeight = 575;
            graphics.ApplyChanges();
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
                int[,] matrix = game.GetGameStage();
                stageDraw.DrawStage(spriteBatch, stageTexture, levelTime, game.GetPoints(), game.GetLives());
                radarDraw.DrawRadar(game.RadarData());
                snakeDraw.DrawSnake(matrix);
                foodDraw.Draw(matrix);
                barrierDraw.DrawBarrier(matrix);
            }
            else if (gamestate == GameStates.Menu)
            {
                if (meniu.meniuState == MeniuState.Pause)
                {
                    stageDraw.DrawStage(spriteBatch, stageTexture, levelTime, game.GetPoints(), game.GetLives());
                    snakeDraw.DrawSnake(game.GetGameStage());
                }
                meniu.DrawMenu(this.spriteBatch, 700, this.font, this.meniuTexture);
            }
            else if (gamestate == GameStates.Hit)
            {
                stageDraw.DrawStage(spriteBatch, stageTexture, levelTime, game.GetPoints(), game.GetLives());
                snakeDraw.DrawSnake(game.GetGameStage());
                foodDraw.Draw(game.GetGameStage());
                if (false)//(game.GetLives() > 0)
                {
                    infoDraw.DrawHitScreen(game.GetLives());
                }
                else
                {
                    infoDraw.DrawGameOver(game.GetPoints(), levelTime);
                }
            }
            base.Draw(gameTime);
        }

        private void DrawStage()
        {
            spriteBatch.Begin();
            for (int i = 0; i < 25; i++)//60
            {
                for (int j = 0; j < 13; j++)//40
                {
                    spriteBatch.Draw(kvad, new Vector2(i * 30 + 40, j * 30 + 45), Color.White);
                   
                }
            }
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
