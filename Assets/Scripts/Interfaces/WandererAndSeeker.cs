using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandererAndSeeker
{
        #region Parameters
        public CirclePreparation circle;

        public List<Vector2Int> generalVisitedCells = new List<Vector2Int>();

        public HashSet<Vector2Int> generalVisitedSet = new HashSet<Vector2Int>();

        public Vector2Int seeker;

        public List<Vector2Int> seekerVisited = new List<Vector2Int>();

        public int walkingSpace;

        public Vector2Int wanderer;
        
        
        #endregion
        #region Constructor
        public WandererAndSeeker(int walkingSpace,ref CirclePreparation circle )
        {
                this.walkingSpace = walkingSpace;
                this.circle = circle;
                TerrainConfiguration();
                ShapeTerrain();
        }
        #endregion
        #region Methods

        public virtual void ShapeTerrain()
        {
                return;
        }

        public void ShapeTerrainHelper()
        {
                circle.matrix[wanderer.x][wanderer.y] = 2;
                if (!generalVisitedSet.Contains(wanderer))
                {
                        generalVisitedCells.Add(wanderer);
                        generalVisitedSet.Add(wanderer);
                }
                seekerVisited.Add(seeker);

                GetSeekerNextMove();
                GetWandererNextMove();
        }

        private void TerrainConfiguration()
        {
                List<Vector2Int> startOptions = new List<Vector2Int>();
                List<Vector2Int> endOptions = new List<Vector2Int>();

                for (int row = 0; row < circle.matrix.Count; row++)
                {
                        if (circle.matrix[circle.startRow][row] == 1)
                        {
                                startOptions.Add(new Vector2Int(circle.startRow, row));
                        }
                        if (circle.matrix[circle.endRow][row] == 1)
                        {
                                endOptions.Add(new Vector2Int(circle.endRow, row));
                        }
                }
                wanderer = startOptions[Random.Range(0, startOptions.Count)];
                seeker = endOptions[Random.Range(0, endOptions.Count)];
        }

        public virtual  bool IsValidMove(Vector2Int original, Vector2Int candidate)
        {
                return true;
        }

        private List<Vector2Int> GetMoves(Vector2Int point)
        {
                List<Vector2Int> moves = new List<Vector2Int>()
                {
                        new Vector2Int(point.x - 1 , point.y), //up
                        new Vector2Int(point.x + 1, point.y), //  down
                        new Vector2Int(point.x , point.y - 1), // left
                        new Vector2Int(point.x , point.y + 1) // right
                };
                List<Vector2Int> valid = new List<Vector2Int>();
                for (int i = 0; i < moves.Count; i++)
                {
                        if (IsValidMove(point, moves[i]))
                        {
                                valid.Add(moves[i]);
                        }
                }
                return valid;
        }

        private int ManhattanDistance(Vector2Int position)
        {
                int x = (int)Mathf.Abs(position.x - wanderer.x);
                int y = (int)Mathf.Abs(position.y - wanderer.y);
                return x + y;
        }

        public  void GetSeekerNextMove()
        {
                List<Vector2Int> moves = new List<Vector2Int>();
                List<Vector2Int> validMoves = new List<Vector2Int>();
                int originalDistance = ManhattanDistance(seeker);

                for (int i = 0; i < moves.Count; i++)
                {
                        int tempDistance = ManhattanDistance(moves[i]);
                        if (tempDistance < originalDistance)
                        {
                                validMoves.Add(moves[i]);
                        }
                }
                if (validMoves.Count == 0)
                {
                        if (generalVisitedSet.Contains(seeker))
                        {
                                for (int i = 0; i < seekerVisited.Count; i++)
                                {
                                        if (!generalVisitedSet.Contains(seekerVisited[i]))
                                        {
                                                circle.matrix[seekerVisited[i].x][seekerVisited[i].y] = 2;
                                                generalVisitedCells.Add(seekerVisited[i]);
                                                generalVisitedSet.Add(seekerVisited[i]);
                                        }
                                }
                        }
                        seekerVisited.Clear();
                }
                else
                {
                        seeker = validMoves[Random.Range(0, validMoves.Count)];

                }
        }

        public void GetWandererNextMove()
        {
                List<Vector2Int> moves = GetMoves(wanderer);
                if (moves.Count > 0)
                {
                        wanderer = moves[Random.Range(0, moves.Count)];
                }
                else
                {
                        wanderer = generalVisitedCells[Random.Range(0, generalVisitedCells.Count)];
                }

        }
        #endregion
}



