using NUnit.Framework;

namespace Exercises.Tdd
{
    [TestFixture]
    public class BowlingGameTests
    {
        private BowlingGame game;

        [SetUp]
        public void SetUp()
        {
            game = new BowlingGame();
        }

        [Test]
        public void NewGame()
        {
            Assert.That(game.Score, Is.EqualTo(0));
        }

        [Test]
        public void RollingZeroPins()
        {
            game.Roll(0);
            Assert.That(game.Score, Is.EqualTo(0));
        }

        [Test]
        public void RollingOnePin()
        {
            game.Roll(1);
            Assert.That(game.Score, Is.EqualTo(1));
        }

        [Test]
        public void RollingTwoPins()
        {
            game.Roll(2);
            Assert.That(game.Score, Is.EqualTo(2));
        }

        [Test]
        public void RollingOnePinTwice()
        {
            game.Roll(1);
            game.Roll(1);
            Assert.That(game.Score, Is.EqualTo(2));
        }

        [Test]
        public void GutterGame()
        {
            for (int roll = 0; roll < 20; roll++)
                game.Roll(0);
            Assert.That(game.Score, Is.EqualTo(0));
        }

        [Test]
        public void RollAllOnes()
        {
            for (int roll = 0; roll < 20; roll++)
                game.Roll(1);
            Assert.That(game.Score, Is.EqualTo(20));
        }

        [Ignore]
        [TestCase(4, Result = (3+7+4) + 4)]
        [TestCase(5, Result = (3+7+5) + 5)]
        public int ASimpleSpare(int extraRoll)
        {
            game.Roll(3);
            game.Roll(7);
            game.Roll(extraRoll);
            return game.Score;
        }


    }
}