using System;

namespace GADE6122DavidTristanPOE
{
    internal class GameEngine
    {
        public enum Direction // Enum for direction character can move
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3,
            None = 4
        }

        public enum GameState // Enum for different states of the game
        {
            InProgress,
            Complete,
            GameOver
        }

        private Level currentLevel; // The current level
        private int levelAmt; // Max amount of levels
        private Random rnd = new Random(); // Random number generator for level sizes
        private GameState gameState = GameState.InProgress; // Current game state
        private int currentLevelNumber = 1; // Current level player is on

        const int MIN_SIZE = 10; // Min size of level
        const int MAX_SIZE = 20; // Max size of level

        // Read-only properties that expose the max amount of levels and the current level to be displayed on the form
        public int LevelAmt { get { return levelAmt; } }
        public int CurrentLevelNumber { get { return currentLevelNumber; } }

        // Constructor for GameEngine object
        public GameEngine(int levelAmt)
        {
            this.levelAmt = levelAmt;
            int width = rnd.Next(MIN_SIZE, MAX_SIZE + 1); // Roll width of level
            int height = rnd.Next(MIN_SIZE, MAX_SIZE + 1); // Roll height of level
            currentLevel = new Level(width, height);
        }

        private bool MoveHero(Direction direction)
        {
            HeroTile heroTile = currentLevel.HeroTile;
            bool success = false;
            if ((int)direction < 4) // Check if direction isn't "None"
            {
                if (heroTile.Vision[(int)direction] is ExitTile) // See if destination is exit
                {
                    if (currentLevelNumber == levelAmt) gameState = GameState.Complete; // Win if final level
                    else NextLevel(); // Move to nect level if not
                    return currentLevelNumber < levelAmt; // Return early with true if not final level
                }
                success = heroTile.Vision[(int)direction] is EmptyTile; // Successful movement to empty space
                if (success)
                {
                    currentLevel.SwopTiles(heroTile, heroTile.Vision[(int)direction]); // Move to empty space
                    heroTile.UpdateVision(currentLevel); // Update vision
                }
            }
            return success; // Indicate successful movement or not
        }

        public void TriggerMovement(Direction direction)
        {
            MoveHero(direction); // Cause player to move in specified direction
        }

        // Generate new level and move character to it
        public void NextLevel()
        {
            currentLevelNumber++;
            HeroTile heroTile = currentLevel.HeroTile;
            int width = rnd.Next(MIN_SIZE, MAX_SIZE + 1); // Roll width of level
            int height = rnd.Next(MIN_SIZE, MAX_SIZE + 1); // Roll height of level
            currentLevel = new Level(width, height, heroTile);
        }

        public override string ToString()
        {
            return gameState == GameState.Complete ? "YOU WIN!!!" : currentLevel.ToString(); // Displays win state or current level if player hasn't won
        }
    }
}
