namespace GADE6122DavidTristanPOE
{
    internal class HealthPickupTile : PickupTile
    {
        // Constructor for HealthPickupTile object
        public HealthPickupTile(Position position) : base(position)
        {
        }

        public override char Display => '+'; // The character that represents a HealthPickupTile

        public override void ApplyEffect(CharacterTile characterTile)
        {
            characterTile.Heal(10);
            if (characterTile.HitPoints > characterTile.MaxHitPoints) characterTile.HitPoints = characterTile.MaxHitPoints;
        }
    }
}
