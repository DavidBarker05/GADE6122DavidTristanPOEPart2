using System;
using System.Collections.Generic;

namespace GADE6122DavidTristanPOE
{
    internal class GruntTile : EnemyTile
    {
        // Constructor for GruntTile object
        public GruntTile(Position position) : base(position, 10,  1)
        {
        }

        public override char Display => IsDead ? 'x' : 'Ϫ'; // The character that represents a GruntTile, when dead or alive

        // Implement the GetMove method defined in the EnemyTile class to define how a grunt moves
        public override bool GetMove(out Tile tile)
        {
            bool hasEmpty = false; // Bool to check if the grunt has an empty space to move to
            Random random;
            int index; // Index of tile to move to in the vision
            Tile emptyTile;
            foreach (Tile t in Vision) // Loop through each tile in the grunt's vision
            {
                hasEmpty |= t is EmptyTile; // Check if there is an empty tile
                if (hasEmpty) break; // If an empty tile is found we can exit loop early
            }
            if (!hasEmpty) tile = null; // If no empty tiles then the output tile will be null
            else // If there is at least one empty tile run through this code
            {
                random = new Random();
                do // Do-while loop to ensure code runs at least once
                {
                    index = random.Next(Vision.Length); // Choose a random tile index in vision
                    emptyTile = Vision[index]; // Set emptyTile to be the tile in vision
                } while (!(emptyTile is EmptyTile)); // Check if emptyTile is an EmptyTile to determine whether to run the loop again or not
                tile = emptyTile; // Set the output tile to be the empty tile
            }
            return hasEmpty; // Return if the grunt has a tile to move to or not
        }

        // Implement the GetMove method defined in the EnemyTile class to define how a grunt targets for attacks
        public override CharacterTile[] GetTargets()
        {
            List<CharacterTile> targets = new List<CharacterTile>(); // List of character tiles for dynamic size
            foreach (Tile tile in Vision) // Loop through each tile in the grunt's vision
            {
                if (tile is HeroTile) // Check if the tile is a hero
                {
                    targets.Add((CharacterTile)tile); // Add the tile to the list if it is
                    break; // Exit the loop early since the hero has been found
                }
            }
            return targets.ToArray(); // Return the list of targets as an array
        }
    }
}
