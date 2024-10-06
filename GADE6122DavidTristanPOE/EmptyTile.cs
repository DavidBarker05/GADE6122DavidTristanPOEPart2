namespace GADE6122DavidTristanPOE
{
    internal class EmptyTile : Tile
    {
        // Constructor for EmptyTile object
        public EmptyTile(Position position) : base(position)
        {
        }

        public override char Display => '.'; // The character that represents an EmptyTile
    }
}
