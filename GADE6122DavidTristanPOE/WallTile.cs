namespace GADE6122DavidTristanPOE
{
    internal class WallTile : Tile
    {
        // Constructor for WallTile object
        public WallTile(Position position) : base(position)
        {
        }

        public override char Display => '█'; // The character that represents a WallTile
    }
}
