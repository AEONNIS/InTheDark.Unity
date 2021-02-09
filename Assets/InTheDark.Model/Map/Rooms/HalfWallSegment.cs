using InTheDark.Model.Maths;
using Leopotam.Ecs.Types;
using System;

namespace InTheDark.Model.Map
{
    internal class HalfWallSegment
    {
        internal HalfWallSegment(Int2 start, Int2 end)
        {
            Start = start;
            End = end;
        }

        internal Int2 Start { get; }
        internal Int2 End { get; private set; }
        internal HalfWallSegment Twin { get; private set; }
        internal Room Room { get; private set; }

        internal bool IsHorizontal => Start.Y == End.Y;
        internal int Length => IsHorizontal ? Start.X - End.X : Start.Y - End.Y;
        internal int LengthAbs => Math.Abs(Length);

        internal void SetTwin(HalfWallSegment twin)
        {
            Twin = twin;
            twin.SetTwin(this);
        }

        internal void SetRoom(Room room) => Room = room;

        internal HalfWallSegment ToPartition(float position)
        {
            var point = GetPointIn(position);
            var segment = new HalfWallSegment(point, End);
            End = point;

            return segment;
        }

        private Int2 GetPointIn(float position) => IsHorizontal
                ? new Int2(new RangeInt(Start.X, End.X).Split(position), Start.Y)
                : new Int2(Start.X, new RangeInt(Start.Y, End.Y).Split(position));
    }
}
