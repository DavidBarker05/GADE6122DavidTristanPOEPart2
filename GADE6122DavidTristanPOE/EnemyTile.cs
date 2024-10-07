namespace GADE6122DavidTristanPOE
{
    internal abstract class EnemyTile : CharacterTile
    {
        public EnemyTile(Position position, int hitPoints, int attackPower) : base(position, hitPoints, attackPower)
        {
        }

       public abstract bool GetMove(out Tile tile);
    }
}
