using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoomInformation
{
        public CirclePreparation circle;
        public List<GameObject> enemiesAlive;
        public List<GameObject> objects;

        public DungeonRoomInformation()
        {
                this.circle = new CirclePreparation(12);
                FillTerrain();
                new DungeonRoomCreator(1, ref circle);
        }

        private void FillTerrain()
        {
                
                for (int x = 0; x < circle.matrix.Count; x++)
                {
                        for(int y = 0; y < circle.matrix.Count; y++)
                        {
                                circle.matrix[x][y] = 1;
                        }
                }

        }
}
