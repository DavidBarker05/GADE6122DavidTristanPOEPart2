using System;
using System.Collections;
using System.Linq;

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
            bool hasEmpty = false;
            foreach (Tile t in Vision)
            {
                hasEmpty |= t is EmptyTile;
                if (hasEmpty) break;
            }
            if (!hasEmpty) tile = null;
            else
            {
                Random random = new Random();
                int index;
                Tile emptyTile;
                do
                {
                    index = random.Next(Vision.Length);
                    emptyTile = Vision[index];
                } while (!(emptyTile is EmptyTile));
                tile = emptyTile;
            }
            return hasEmpty;
        }

        public override CharacterTile[] GetTargets()
        {
            CharacterTile[] targets = new CharacterTile[Vision.Length];
            for (int i = 0; i < Vision.Length; i++)
            {
                if (Vision[i] is HeroTile)
                {
                    targets[i] = (CharacterTile)Vision[i];
                    break;
                }
            }
            return targets;
        }
    }
}
