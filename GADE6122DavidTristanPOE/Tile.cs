namespace GADE6122DavidTristanPOE
{
    internal abstract class Tile
    {
        private Position position; // Field to store tile's position

        // Properties that expose the position of the tile, read-only for x and y
        public int X { get { return position.X; } }
        public int Y { get { return position.Y; } }
        public Position Position { get { return position; } set { position = value; } }

        // Base constructor for Tile child objects
        protected Tile(Position position)
        {
            this.position = position;
        }

        public abstract char Display { get; } // The character that represents a Tile object to be implemented by child classes
    }
}
