using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Sound;
using NUnit.Framework;
using Snake_Game.Service;
using Snake_Game.Service.SoundsService;
using Microsoft.Xna.Framework;

namespace SnakeGame.Test
{
    [TestFixture]
    public class GameServiceTest
    {

        [Test]
        public void MoveSnakeRightPosition()//snake coord X = 14  Y = 6
        {
            var sound = new SnakeSounds();
            sound.BackgroundSound = new GameSound();
            sound.SnakeSound = new SnakeSound();

            var gameService = new GameService(sound);
            gameService.SetLevel(0);

            gameService.SetMovment(-1, 1);
            Assert.AreEqual(new Vector3(13, 6, -1), gameService.GetSnakeHead());
        }

        [Test]
        public void MoveSnakeLeftPosition()//snake coord X = 14  Y = 6
        {
            var sound = new SnakeSounds();
            sound.BackgroundSound = new GameSound();
            sound.SnakeSound = new SnakeSound();

            var gameService = new GameService(sound);
            gameService.SetLevel(0);

            gameService.SetMovment(1, -1);
            gameService.SetMovment(1, 1);
            Assert.AreEqual(new Vector3(15, 5, 1), gameService.GetSnakeHead());
        }

        [Test]
        public void MoveSnakeUpPosition()//snake coord X = 14  Y = 6
        {
            var sound = new SnakeSounds();
            sound.BackgroundSound = new GameSound();
            sound.SnakeSound = new SnakeSound();

            var gameService = new GameService(sound);
            gameService.SetLevel(0);

            gameService.SetMovment(1, -1);
            Assert.AreEqual(new Vector3(14, 5, 2), gameService.GetSnakeHead());
        }

        [Test]
        public void MoveSnakeDownPosition()//snake coord X = 14  Y = 6
        {
            var sound = new SnakeSounds();
            sound.BackgroundSound = new GameSound();
            sound.SnakeSound = new SnakeSound();

            var gameService = new GameService(sound);
            gameService.SetLevel(0);

            gameService.SetMovment(-1, -1);
            Assert.AreEqual(new Vector3(14, 7, -2), gameService.GetSnakeHead());
        }

        [Test]
        public void GameDivicultLevelIsError()
        {            
            var sound = new SnakeSounds();
            sound.BackgroundSound = new GameSound();
            sound.SnakeSound = new SnakeSound();

            var gameService = new GameService(sound);
            gameService.SetLevel(0);            

            Assert.AreEqual("ee", gameService.GetGameType());
        }

        [Test]
        public void GameDivicultLevelIsCl1()
        {
            var sound = new SnakeSounds();
            sound.BackgroundSound = new GameSound();
            sound.SnakeSound = new SnakeSound();

            var gameService = new GameService(sound);
            gameService.SetLevel(0);
            gameService.SetPoints(10);

            Assert.AreEqual("cl1", gameService.GetGameType());
        }

        [Test]
        public void GameDivicultLevelIsCl2()
        {
            var sound = new SnakeSounds();
            sound.BackgroundSound = new GameSound();
            sound.SnakeSound = new SnakeSound();

            var gameService = new GameService(sound);
            gameService.SetLevel(0);
            gameService.SetPoints(25);

            Assert.AreEqual("cl2", gameService.GetGameType());
        }

        [Test]
        public void GameDivicultLevelIsCl0()
        {
            var sound = new SnakeSounds();
            sound.BackgroundSound = new GameSound();
            sound.SnakeSound = new SnakeSound();

            var gameService = new GameService(sound);
            gameService.SetLevel(0);
            gameService.SetPoints(5);

            Assert.AreEqual("cl0", gameService.GetGameType());
        }

        [Test]
        public void GameLevelIsAr1()
        {
            var sound = new SnakeSounds();
            sound.BackgroundSound = new GameSound();
            sound.SnakeSound = new SnakeSound();

            var gameService = new GameService(sound);
            gameService.SetLevel(1);

            Assert.AreEqual("ar1", gameService.GetGameType());
        }

        [Test]
        public void GameLevelIsAr6()
        {
            var sound = new SnakeSounds();
            sound.BackgroundSound = new GameSound();
            sound.SnakeSound = new SnakeSound();

            var gameService = new GameService(sound);
            gameService.SetLevel(6);

            Assert.AreEqual("ar6", gameService.GetGameType());            
        }        
    }
}
