namespace GADE6122DavidTristanPOE
{
    internal abstract class PickupTile : Tile
    {
        // Constructor for PickupTile object
        public PickupTile(Position position) : base(position)
        {
        }

        public abstract void ApplyEffect(CharacterTile characterTile); // Method to be called for all instances of PickupTile in order to affect the character
    }
}
