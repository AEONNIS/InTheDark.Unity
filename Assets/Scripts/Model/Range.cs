namespace InTheDark.Model
{
    public readonly struct Range<T>
    {
        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public readonly T Min { get; }
        public readonly T Max { get; }
    }
}