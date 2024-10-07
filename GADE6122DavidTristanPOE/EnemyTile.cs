using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122DavidTristanPOE
{
    internal  abstract class EnemyTile : CharacterTile
    {
        public EnemyTile(Position position, int hitPoints, int attackPower) : base(position, hitPoints, attackPower)
        {

        }

       //(Q2.1) public abstract void GetMove(out Tile);
        

        public override char Display => throw new NotImplementedException();
    }
}
