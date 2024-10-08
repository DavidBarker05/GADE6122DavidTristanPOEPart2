namespace GADE6122DavidTristanPOE
{
    internal class HealthPickupTile : PickupTile
    {
        public HealthPickupTile(Position position) : base(position)
        {
        }

        public override char Display => '+';

        public override void ApplyEffect(CharacterTile characterTile)
        {
            characterTile.Heal(10);
            if (characterTile.HitPoints > characterTile.MaxHitPoints) characterTile.HitPoints = characterTile.MaxHitPoints;
        }
    }
}
