using System;
using System.Collections.Generic;

namespace GADE6122DavidTristanPOE
{
    internal class GruntTile : EnemyTile
    {
        public GruntTile(Position position) : base(position, 10,  1)
        {
        }

        public override char Display => IsDead ? 'x' : 'Ϫ';

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
            List<CharacterTile> targets = new List<CharacterTile>();
            foreach (Tile tile in Vision)
            {
                if (tile is HeroTile)
                {
                    targets.Add((CharacterTile)tile);
                    break;
                }
            }
            return targets.ToArray();
        }
    }
}
