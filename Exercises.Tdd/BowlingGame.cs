using System.Runtime.Versioning;

namespace Exercises.Tdd
{
    public class BowlingGame
    {
        public int Score { get; private set; }

        public void Roll(int pins)
        {
            Score += pins;
        }

    }
}