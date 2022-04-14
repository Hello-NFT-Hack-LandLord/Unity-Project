using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoomCreator : WandererAndSeeker
{

        public DungeonRoomCreator(int walkingSpace, ref CirclePreparation circle)
                : base(walkingSpace, ref circle)
        {
                     
        }

        public override void ShapeTerrain()
        {
                base.ShapeTerrain();

                int roomSize = circle.matrix.Count * circle.matrix.Count;
                float targetRoomSize = Random.Range(0.7f, 0.86f);
                int maxIterations = (int)(roomSize * targetRoomSize);
                float currentRoomSize = (float)(generalVisitedCells.Count / ((float)roomSize));

                bool containsSeeker = (!generalVisitedSet.Contains(seeker));
                bool isSizeLimit = (currentRoomSize < targetRoomSize);
                bool seekerEmpty = (seekerVisited.Count > 0);
                
                while ((containsSeeker || isSizeLimit || seekerEmpty ) && (maxIterations > 0) )
                {
                        ShapeTerrainHelper();
                        containsSeeker = (!generalVisitedSet.Contains(seeker));
                        isSizeLimit = (currentRoomSize < targetRoomSize);
                        seekerEmpty = (seekerVisited.Count > 0);
                        maxIterations--;
                }
        }

        public override bool IsValidMove(Vector2Int original, Vector2Int candidate)
        {
                bool withinMatrix = (candidate.x >= 0 && candidate.y >= 0 && candidate.x < circle.matrix.Count &&
                        candidate.y < circle.matrix.Count);

                if (!withinMatrix)
                        return false;

                bool withinCircle = (circle.matrix[candidate.x][candidate.y] == walkingSpace);

                return withinCircle;
        }
}
