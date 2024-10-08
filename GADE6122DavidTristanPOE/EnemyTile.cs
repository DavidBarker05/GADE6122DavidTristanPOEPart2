namespace GADE6122DavidTristanPOE
{
    internal abstract class EnemyTile : CharacterTile
    {
        // Constructor for EnemyTile object
        public EnemyTile(Position position, int hitPoints, int attackPower) : base(position, hitPoints, attackPower)
        {
        }

        public abstract bool GetMove(out Tile tile); // Abstract method used to see if the enemy can move and the out tile is the tile it moves to

        public abstract CharacterTile[] GetTargets(); // Abstract method used to find all the characters the enemy can attack
    }
}
