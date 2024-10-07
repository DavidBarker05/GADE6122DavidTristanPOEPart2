namespace GADE6122DavidTristanPOE
{
    internal class GruntTile : EnemyTile
    {
        public GruntTile(Position position) : base(position, 10,  1)
        {
        }

        public override char Display => IsDead ? 'Ϫ' : '▼';

        public override bool GetMove(out Tile tile)
        {
            throw new System.NotImplementedException();
        }

        public override CharacterTile[] GetTargets()
        {
            throw new System.NotImplementedException();
        }
    }
}
