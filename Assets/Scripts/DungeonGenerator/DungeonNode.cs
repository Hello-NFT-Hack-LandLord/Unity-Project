using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonNode 
{
        public bool created;

        public DungeonRoomInformation roomInformation;
        
        public bool spawned;

        public int xOffset;

        public int yOffset;

        public int offsetMultiplier = 25;

        public int currentTileIndex;

        public DungeonNode(int xPos, int yPos)
        {
                this.xOffset = xPos;
                this.yOffset = yPos;
                this.created = true;
                this.spawned = false;
                this.currentTileIndex = -1;
                this.roomInformation = new DungeonRoomInformation();
        }

        public void Build(DungeonRoomBuilder builder)
        {
                if (spawned)
                        return;
                spawned = true;

                List<List<int>> matrix = roomInformation.circle.matrix;
                int roomSize = matrix.Count;
                Debug.Log(currentTileIndex + " PLACE TILE");
                for (int row = 0; row < roomSize; row++)
                {
                        for (int col = 0; col < roomSize; col++)
                        {
                                if (matrix[row][col] == 2)
                                {
                                        builder.PlaceTile(row, col, xOffset * offsetMultiplier, yOffset * offsetMultiplier, true, currentTileIndex);
                                }
                                else if (matrix[row][col] == 1)
                                {
                                        builder.PlaceTile(row, col, xOffset * offsetMultiplier, yOffset * offsetMultiplier, false,currentTileIndex);
                                }
                        }
                }
        }

        public void Deconstruct(DungeonRoomBuilder builder)
        {

                spawned = false;
                builder.RemoveTile(currentTileIndex);
                currentTileIndex = -1;
        }
}
