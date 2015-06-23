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
            for (var roll = 0; roll < 20; roll++)
                game.Roll(0);
            Assert.That(game.Score, Is.EqualTo(0));
        }

        [Test]
        public void RollAllOnes()
        {
            for (var roll = 0; roll < 20; roll++)
                game.Roll(1);
            Assert.That(game.Score, Is.EqualTo(20));
        }

        [TestCase(4, Result = (3 + 7 + 4) + 4)]
        [TestCase(5, Result = (3 + 7 + 5) + 5)]
        public int ASimpleSpare(int extraRoll)
        {
            game.Roll(3);
            game.Roll(7);
            game.Roll(extraRoll);
            return game.Score;
        }

        [Test]
        public void RunAllFives()
        {
            for (var i = 0; i < 21; i++)
                game.Roll(5);
            Assert.That(game.Score, Is.EqualTo(150));
        }

        [Test]
        public void RollZeroThenTen()
        {
            game.Roll(0);
            game.Roll(10);
            game.Roll(2);

            Assert.That(game.Score, Is.EqualTo((0 + 10 + 2) + (2)));
        }

        [TestCase(1, 2, Result = (10 + 1 + 2) + (1 + 2))]
        [TestCase(2, 3, Result = (10 + 2 + 3) + (2 + 3))]
        public int ASimpleStrike(int firstRoll, int secondRoll)
        {
            game.Roll(10);
            game.Roll(firstRoll);
            game.Roll(secondRoll);
            return game.Score;
        }

        [Test]
        public void TwoConsecutiveStrikes()
        {
            game.Roll(10);
            game.Roll(10);
            game.Roll(2);
            game.Roll(3);
            Assert.That(game.Score, Is.EqualTo((10 + 10 + 2) + (10 + 2 + 3) + (2 + 3)));

        }

        [Test]
        public void RollingAPerfectGame_Scores300()
        {
            for (var i = 0; i < 12; i++)
                game.Roll(10);
            Assert.That(game.Score, Is.EqualTo(300));
        }

    }
}