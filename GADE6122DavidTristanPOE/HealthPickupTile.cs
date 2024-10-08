namespace GADE6122DavidTristanPOE
{
    internal class HealthPickupTile : PickupTile
    {
        // Constructor for HealthPickupTile object
        public HealthPickupTile(Position position) : base(position)
        {
        }

        public override char Display => '+'; // The character that represents a HealthPickupTile

        // Implement the ApplyEffect method defined in the PickupTile class to heal a character
        public override void ApplyEffect(CharacterTile characterTile)
        {
            characterTile.Heal(10); // Heal 10 hit points
            if (characterTile.HitPoints > characterTile.MaxHitPoints) characterTile.HitPoints = characterTile.MaxHitPoints; // Clamp the hit points to the max hit points
        }
    }
}
