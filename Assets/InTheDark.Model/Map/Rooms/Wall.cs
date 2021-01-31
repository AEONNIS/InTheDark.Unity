using InTheDark.Model.Math;
using Leopotam.Ecs.Types;

namespace InTheDark.Model.Map
{
    internal class Wall
    {
        internal Wall(in Int2 start, in Int2 end, Room right)
        {
            Start = start;
            End = end;
            IsHorizontal = Start.Y == End.Y;
        }

        internal Int2 Start { get; }
        internal Int2 End { get; }
        internal bool IsHorizontal { get; }
        internal Room Right { get; private set; }
        internal Room Left { get; private set; }

        internal void SetRight(Room room) => Right = room;

        internal void SetLeft(Room room) => Left = room;

        internal Walls Split(float position) => IsHorizontal ? HorizontalSplit(position) : VerticalSplit(position);

        private Walls HorizontalSplit(float position)
        {
            var commonPoint = new RangeInt(Start.X, End.X).Split(position);

            return null;
        }

        private Walls VerticalSplit(float position)
        {
            return null;
        }
    }
}
