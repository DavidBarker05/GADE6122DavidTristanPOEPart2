namespace GADE6122DavidTristanPOE
{
    internal abstract class CharacterTile : Tile
    {
        // Character fields that store the hit points, hit point maximum, attack power and vision
        private int hitPoints, maxHitPoints, attackPower;
        private Tile[] vision;

        // Read-only properties used to retrieve the character's vision and if it is dead
        public Tile[] Vision { get { return vision; } }
        public bool IsDead { get { return hitPoints == 0; } }

        // Constructor for CharacterTile object
        public CharacterTile(Position position, int hitPoints, int attackPower) : base(position)
        {
            this.hitPoints = hitPoints;
            maxHitPoints = hitPoints;
            this.attackPower = attackPower;
            vision = new Tile[4];
        }

        // Update's the character's vision
        public void UpdateVision(Level level)
        {
            vision[0] = level.Tiles[X, Y - 1];
            vision[1] = level.Tiles[X + 1, Y];
            vision[2] = level.Tiles[X, Y + 1];
            vision[3] = level.Tiles[X - 1, Y];
        }

        // Reduce health by damage taken
        public void TakeDamage(int damage)
        {
            hitPoints -= damage;
            if (hitPoints < 0) hitPoints = 0;
        }

        // Attack another character
        public void Attack(CharacterTile characterTile)
        {
            characterTile.TakeDamage(attackPower);
        }
    }
}
