namespace InTheDark.Model.Map
{
    public class Range<T> where T : unmanaged
    {
        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public T Min { get; }
        public T Max { get; }
    }
}
