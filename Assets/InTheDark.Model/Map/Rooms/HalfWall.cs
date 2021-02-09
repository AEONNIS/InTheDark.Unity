using Leopotam.Ecs.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InTheDark.Model.Map
{
    internal class HalfWall
    {
        private readonly List<HalfWallSegment> _segments = new List<HalfWallSegment>();

        internal HalfWall(Int2 start, Int2 end)
            => _segments.Add(new HalfWallSegment(start, end));

        internal Int2 Start => _segments[0].Start;
        internal Int2 End => _segments[_segments.Count - 1].End;
        internal ReadOnlyCollection<HalfWallSegment> Segments => _segments.AsReadOnly();
        internal bool IsHorizontal => Start.Y == End.Y;
        internal int Length => IsHorizontal ? Start.X - End.X : Start.Y - End.Y;
        internal int LengthAbs => Math.Abs(Length);

        internal void ToPartition(HalfWallSegment segment, float position) => _segments.Add(segment.ToPartition(position));
    }
}
