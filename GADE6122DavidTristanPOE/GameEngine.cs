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
        private int numMoves = 0;

        const int MIN_SIZE = 10; // Min size of level
        const int MAX_SIZE = 20; // Max size of level

        public Level CurrentLevel { get { return currentLevel; } }

        // Read-only properties that expose the max amount of levels, the current level, the hit points and the max hit points of the hero to be displayed on the form
        public int LevelAmt { get { return levelAmt; } }
        public int CurrentLevelNumber { get { return currentLevelNumber; } }
        public string HeroStats => $"{currentLevel.HeroTile.HitPoints}/40";

        // Constructor for GameEngine object
        public GameEngine(int levelAmt)
        {
            this.levelAmt = levelAmt;
            int width = rnd.Next(MIN_SIZE, MAX_SIZE + 1); // Roll width of level
            int height = rnd.Next(MIN_SIZE, MAX_SIZE + 1); // Roll height of level
            currentLevel = new Level(width, height, currentLevelNumber, 1 );
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
                if (heroTile.Vision[(int)direction] is HealthPickupTile) // See if destination is exit
                {
                    ((HealthPickupTile)heroTile.Vision[(int)direction]).ApplyEffect(currentLevel.HeroTile);
                    currentLevel.GrabPickup((HealthPickupTile)heroTile.Vision[(int)direction]);
                    currentLevel.UpdateVision(); // Update vision
                }
                success = heroTile.Vision[(int)direction] is EmptyTile; // Successful movement to empty space
                if (success)
                {
                    currentLevel.SwopTiles(heroTile, heroTile.Vision[(int)direction]); // Move to empty space
                    currentLevel.UpdateVision(); // Update vision
                }
            }
            return success; // Indicate successful movement or not
        }

        // Method used to move all enemies
        private void MoveEnemies()
        {
            foreach (EnemyTile enemy in currentLevel.EnemyTiles) // Loop through all enemies
            {
                if (enemy.IsDead || !enemy.GetMove(out Tile targetTile)) continue; // If enemy is dead or cannot move skip them
                currentLevel.SwopTiles(enemy, targetTile); // Move enemy
                currentLevel.UpdateVision(); // Update vision
            }
        }

        // Method used to trigger movement for the hero and enemies
        public void TriggerMovement(Direction direction)
        {
            bool heroMoved = MoveHero(direction); // Cause player to move in specified direction
            if (heroMoved) // See if the hero successfully moved that turn
            {
                numMoves++; // Increment number of moves
                if (numMoves % 2 == 0) MoveEnemies(); // Check if player has moved twice in order to move the enemies
            }
        }

        private bool HeroAttack(Direction direction)
        {
            HeroTile heroTile = currentLevel.HeroTile;
            Tile targetTile;
            if ((int)direction < 4) // Check if direction isn't "None"
            {
                targetTile = heroTile.Vision[(int)direction]; // Set the target tile to be the tile in the hero's vision in the position of the direction
                if (targetTile is CharacterTile) heroTile.Attack((CharacterTile)targetTile); // If the target is a character attack
            }
            else return false; // Return that the attack failed if the direction is "None"
            return targetTile is CharacterTile; // Return whether the target tile is a character or not to indicate the success of the attack
        }

        // Method used to make all enemies attack
        private void EnemiesAttack()
        {
            foreach (EnemyTile enemy in currentLevel.EnemyTiles) // Loop through all enemies
            {
                if (enemy.IsDead) continue; // If enemy is dead skip them
                CharacterTile[] targets = enemy.GetTargets(); // Retrieve all the characters the enemy can attack
                foreach (CharacterTile target in targets) // Loop through all the characters the enemy can attack
                {
                    enemy.Attack(target); // Attack the character
                }
            }
        }

        // Method used to trigger movement for the hero and enemies
        public void TriggerAttack(Direction direction)
        {
            bool heroAttacked = HeroAttack(direction); // Cause player to attack in specified direction
            if (heroAttacked) EnemiesAttack(); // See if the hero successfully attacked that turn and cause enemies to attack if they have
            if (currentLevel.HeroTile.IsDead) gameState = GameState.GameOver; // Set game state to be over if the hero is dead
        }

        // Generate new level and move character to it
        public void NextLevel()
        {
            currentLevelNumber++;
            HeroTile heroTile = currentLevel.HeroTile;
            int width = rnd.Next(MIN_SIZE, MAX_SIZE + 1); // Roll width of level
            int height = rnd.Next(MIN_SIZE, MAX_SIZE + 1); // Roll height of level
            currentLevel = new Level(width, height, currentLevelNumber, 1, heroTile);
        }

        public override string ToString()
        {
            // Displays if the player has won or lost or it displays the current level depending on the game state
            return gameState == GameState.Complete ? "YOU WIN!!!" : gameState == GameState.GameOver ? "GAME OVER!" : gameState == GameState.InProgress ? currentLevel.ToString() : "";
        }
    }
}
