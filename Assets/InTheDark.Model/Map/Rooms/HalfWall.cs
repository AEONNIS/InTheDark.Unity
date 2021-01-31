namespace InTheDark.Model.Map
{
    internal class HalfWall
    {
        public HalfWall(Angle origin) => Origin = origin;

        internal Angle Origin { get; }
        internal HalfWall Prev { get; private set; }
        internal HalfWall Next { get; private set; }
        internal HalfWall Twin { get; private set; }
        internal Room Room { get; private set; }
    }
}
