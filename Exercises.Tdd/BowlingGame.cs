using System.Collections.Generic;
using System.Linq;

namespace Exercises.Tdd
{
    public class BowlingGame
    {
        private readonly List<int> rolls = new List<int>();

        public void Roll(int pins)
        {
            rolls.Add(pins);
            if (WeJustRolledAStrike())
                rolls.Add(0);
        }

        public int Score
        {
            get
            {
                var score = 0;
                for (var frame = 1; frame <= 10; frame++)
                {
                    score += ScoreFor(frame);
                }
                return score;
            }
        }

        private int ScoreFor(int frame)
        {
            if (IsStrike(frame))
                return FirstRollOf(frame) + FirstRollAfter(frame) + SecondRollAfter(frame);
            
            if (IsSpare(frame))
                return FirstRollOf(frame) + SecondRollOf(frame) + FirstRollAfter(frame);
            
            return FirstRollOf(frame) + SecondRollOf(frame);
        }

        private int FirstRollAfter(int frame)
        {
            return FirstRollOf(frame + 1);
        }

        private int SecondRollAfter(int frame)
        {
            if (IsStrike(frame + 1))
                return FirstRollOf(frame + 2);
            return SecondRollOf(frame + 1);
        }

        private bool IsStrike(int frame)
        {
            return FirstRollOf(frame) == 10;
        }

        private bool IsSpare(int frame)
        {
            return FirstRollOf(frame) + SecondRollOf(frame) == 10;
        }

        private int FirstRollOf(int frame)
        {
            var index = (frame - 1) * 2;
            var firstRollOf = RollAt(index);
            return firstRollOf;
        }

        private int SecondRollOf(int frame)
        {
            var index = (frame - 1) * 2 + 1;
            return RollAt(index);
        }

        private int RollAt(int index)
        {
            if (index < rolls.Count)
                return rolls[index];

            return 0;
        }

        private bool WeJustRolledAStrike()
        {
            return rolls.Count % 2 == 1 && rolls.Last() == 10;
        }

    }
}