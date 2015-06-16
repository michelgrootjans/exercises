using System.Collections.Generic;

namespace Exercises.Tdd
{
    public class BowlingGame
    {
        private readonly List<int> rolls = new List<int>();

        public void Roll(int pins)
        {
            rolls.Add(pins);
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
            //if is spare
            //return spare score
            //else
            return FirstRollOf(frame) + SecondRollOf(frame);
        }

        private int FirstRollOf(int frame)
        {
            var index = (frame - 1) * 2;
            return RollAt(index);
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
    }
}