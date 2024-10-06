namespace GADE6122DavidTristanPOE
{
    internal class HeroTile : CharacterTile
    {
        // Constructor for HeroTile object
        public HeroTile(Position position) : base(position, 40, 5)
        {
        }

        public override char Display => IsDead ? 'x' : '▼'; // The character that represents a HeroTile, when dead or alive
    }
}
