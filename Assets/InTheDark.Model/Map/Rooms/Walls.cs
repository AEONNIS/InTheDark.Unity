namespace InTheDark.Model.Map
{
    internal class Walls
    {
        public Walls(Wall first, Wall second)
        {
            First = first;
            Second = second;
        }

        internal Wall First { get; }
        internal Wall Second { get; }
    }
}
