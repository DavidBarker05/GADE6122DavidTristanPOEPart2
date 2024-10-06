using System;

namespace GADE6122DavidTristanPOE
{
    internal class Level
    {
        public enum TileType // Enum for different tile types
        {
            EmptyTile,
            WallTile,
            HeroTile,
            ExitTile
        }

        private Tile[,] tiles; // Level's tiles
        private int width, height; // Level's width and height
        private HeroTile heroTile; // Hero
        private ExitTile exitTile; // Level exit

        // Read-only properties to expose fields that need to be read in other classes
        public HeroTile HeroTile { get { return heroTile; } }
        public ExitTile ExitTile { get { return exitTile; } }
        public Tile[,] Tiles { get {  return tiles; }}

        // Constructor for Level object, heroTile is optional with a default value of null
        public Level(int width, int height, HeroTile heroTile = null)
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[width, height];
            InitialiseTiles(); // Initialise level
            Position heroPos = GetRandomEmptyPosition(); // Find free space in level for hero
            if (heroTile == null) this.heroTile = (HeroTile)CreateTile(TileType.HeroTile, heroPos); // Create new hero if paramter null
            else // Use hero parameter if it is not null and update it's position
            {
                heroTile.Position = heroPos;
                tiles[heroPos.X, heroPos.Y] = heroTile;
                this.heroTile = heroTile;
            }
            Position exitPos = GetRandomEmptyPosition(); // Find free space in level for exit
            exitTile = (ExitTile)CreateTile(TileType.ExitTile, exitPos); // Create and place exit in level
            this.heroTile.UpdateVision(this); // Update hero vision
        }

        // Create new Tile child object based off of the tile's type and position
        private Tile CreateTile(TileType tileType, Position position)
        {
            Tile tile = null;
            switch (tileType)
            {
                case TileType.EmptyTile:
                    tile = new EmptyTile(position);
                    break;
                case TileType.WallTile: 
                    tile = new WallTile(position);
                    break;
                case TileType.HeroTile:
                    tile = new HeroTile(position);
                    break;
                case TileType.ExitTile:
                    tile = new ExitTile(position);
                    break;
            }
            tiles[position.X, position.Y] = tile;
            return tile;
        }

        // Overloaded method that uses x and y instead of position
        private Tile CreateTile(TileType tileType, int x, int y)
        {
            return CreateTile(tileType, new Position(x, y));
        }

        // Initialise tiles in level, used at start
        private void InitialiseTiles()
        {
            // For-loops go through all co-ordinates
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y == 0 || x == 0 || y == height - 1 || x == width - 1) CreateTile(TileType.WallTile, x, y); // Outer walls
                    else CreateTile(TileType.EmptyTile, x, y); // Inner empty spaces
                }
            }
        }

        // Find a random empty space in level
        private Position GetRandomEmptyPosition()
        {
            Random r = new Random(); // Random number generator
            int x, y; // X and y co-ordinates of space
            do // Keep searching for empty space if the random space isn't empty, guaranteed to do once so that x and y have values
            {
                x = r.Next(0, width);
                y = r.Next(0, height);
            } while (!(tiles[x, y] is EmptyTile));
            return new Position(x, y); // Return empty space position
        }

        // Swop two tiles in the array and swap their positions
        public void SwopTiles(Tile tile1, Tile tile2)
        {
            Tile _tile = tiles[tile1.X, tile1.Y]; // Temp value
            Position _position = tile1.Position; // Temp value
            tiles[tile1.X, tile1.Y] = tiles[tile2.X, tile2.Y];
            tile1.Position = tile2.Position;
            tiles[tile2.X, tile2.Y] = _tile;
            tile2.Position = _position;
        }

        // To string method to output all the tiles in the level
        public override string ToString()
        {
            string level = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    level += tiles[x, y].Display;
                }
                level += "\n";
            }
            return level;
        }
    }
}
