﻿using System;

namespace InTheDark.Model.Math
{
    public readonly struct RangeInt
    {
        private readonly Range<int> _range;

        public RangeInt(int min, int max) => _range = new Range<int>(min, max);

        public int Min => _range.Min;
        public int Max => _range.Max;

        public int Split(float position) => Min + (int)System.Math.Round((Max - Min) * position, MidpointRounding.AwayFromZero);
    }
}
