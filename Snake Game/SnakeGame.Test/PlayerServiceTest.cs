using NUnit.Framework;
using Snake_Game.ServiceContracts;
using Snake_Game.Service;

namespace SnakeGame.Test
{
    [TestFixture]
    public class PlayerServiceTest
    {
        [Test]
        public void Add10Points()
        {
            var playerService = new PlayerService();
            playerService.AddPoint(10);
            Assert.AreEqual(10, playerService.GetPoints());
        }

        [Test]
        public void AddMinus10Points()
        {
            IPlayerService playerService = new PlayerService();
            playerService.AddPoint(-10);
            Assert.AreEqual(-10, playerService.GetPoints());
        }

        [Test]
        public void AddMinus1Live()
        {
            IPlayerService playerService = new PlayerService();
            playerService.DecreseLive();
            Assert.AreEqual(2, playerService.GetLive());
        }

        [Test]
        public void AddMinus4LiveToGet0()
        {
            IPlayerService playerService = new PlayerService();
            playerService.DecreseLive();
            playerService.DecreseLive();
            playerService.DecreseLive();
            playerService.DecreseLive();
            Assert.AreEqual(0, playerService.GetLive());
        }
    }
}
