using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTerrainShaper:WandererAndSeeker
{

        #region Constructor
        public CircleTerrainShaper(int walkingSpace, ref CirclePreparation circle)
                : base(walkingSpace,ref circle)
        {
       
        }

        #endregion
        #region Methods

        public override void ShapeTerrain()
        {
                base.ShapeTerrain();
                int maxIterations = (int)
                        ((this.circle.matrix.Count * circle.matrix.Count) * Random.Range(0.2f, 0.3f));

                

                while (!generalVisitedSet.Contains(seeker) && maxIterations > 0)
                {
                        maxIterations--;
                        ShapeTerrainHelper();
                }
        }

        public override bool IsValidMove(Vector2Int original, Vector2Int candidate)
        {
                bool withinMatrix = (candidate.x >= 0 && candidate.y >= 0 && candidate.x < circle.matrix.Count &&
                        candidate.y < circle.matrix.Count);
                if (!withinMatrix)
                        return false;

                bool withinCircle = (circle.matrix[candidate.x][candidate.y] == walkingSpace);
                if (original.x < candidate.x)
                {
                        return withinCircle && (circle.matrix[candidate.x + 1][candidate.y] == walkingSpace);
                }
                else if (original.x > candidate.x)
                {
                        return withinCircle && (circle.matrix[candidate.x - 1][candidate.y] == walkingSpace);
                }

                else if (original.y < candidate.y)
                {
                        return withinCircle && (circle.matrix[candidate.x][candidate.y + 1] == walkingSpace);
                }

                return withinCircle && (circle.matrix[candidate.x][candidate.y - 1] == walkingSpace);
        }



        #endregion
}



