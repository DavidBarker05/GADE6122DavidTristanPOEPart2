namespace GADE6122DavidTristanPOE
{
    internal abstract class PickupTile : Tile
    {
        // Constructor for PickupTile object
        public PickupTile(Position position) : base(position)
        {
        }

        public abstract void ApplyEffect(CharacterTile characterTile);
    }
}
