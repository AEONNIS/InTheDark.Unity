using Leopotam.Ecs.Types;

namespace InTheDark.Model.Map
{
    internal class Angle
    {
        internal Angle(in Int2 position) => Position = position;

        internal Int2 Position { get; }
        internal HalfWall Wall { get; private set; }

        internal void SetWall(HalfWall wall) => Wall = wall;
    }
}
