using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using NUnit.Framework;

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
            return FrameRollOne(frame) + FrameRollTwo(frame);
        }

        private int FrameRollOne(int frame)
        {
            var index = (frame - 1) * 2;
            return RollAt(index);
        }

        private int FrameRollTwo(int frame)
        {
            var index = (frame - 1) * 2 + 1;
            return RollAt(index);
        }

        private int RollAt(int index)
        {
            if (rolls.Count <= index )
                return 0;
            return rolls[index];
        }
    }
}