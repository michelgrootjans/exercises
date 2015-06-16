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
            get { return rolls.Sum(); }
        }
    }
}