namespace GADE6122DavidTristanPOE
{
    internal class ExitTile : Tile
    {
        // Constructor for ExitTile object
        public ExitTile(Position position) : base(position)
        {
        }

        public override char Display => '▒'; // The character that represents an ExitTile
    }
}
