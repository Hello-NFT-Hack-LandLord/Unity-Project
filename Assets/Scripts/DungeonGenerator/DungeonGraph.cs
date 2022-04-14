using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGraph
{
        public Dictionary<Vector2Int, DungeonNode> nodes;
        public HashSet<Vector2Int> currentBlock;
        public DungeonNode currentNode;
        public Vector2Int currentPosition;
        public DungeonRoomBuilder builder;
        private Dictionary<int, Vector2Int> centerChange = new Dictionary<int, Vector2Int>()
        {
                {1,new Vector2Int(-1,-1) },
                {2,new Vector2Int(-1,0) },
                {3,new Vector2Int(-1,1) },
                {4,new Vector2Int(0,-1) },
                {5,new Vector2Int(0,0) },
                {6,new Vector2Int(0,1) },
                {7,new Vector2Int(1,-1) },
                {8,new Vector2Int(1,0) },
                {9,new Vector2Int(1,1) }
        };

        public DungeonGraph()
        {
                currentBlock = new HashSet<Vector2Int>();
                nodes = new Dictionary<Vector2Int, DungeonNode>();
                currentPosition = new Vector2Int(0, 0);
                currentNode = new DungeonNode(0, 0);
                nodes[currentPosition] = new DungeonNode(0, 0);
                builder = GameObject.Find("DungeonManager").GetComponent<DungeonRoomBuilder>();
                BuildBlock();

        }

        private void BuildBlock()
        {
                int tileIndex = 0;
                for (int x = -1; x < 2; x++)
                {
                        for (int y = -1; y < 2; y++)
                        {
                                tileIndex++;
                                Vector2Int key = new Vector2Int(currentPosition.x + x , currentPosition.y + y);
                                

                                if (!nodes.ContainsKey(key))
                                {
                                        nodes[key] = new DungeonNode(currentPosition.x + x, currentPosition.y + y);
                                }
                                nodes[key].currentTileIndex = tileIndex;
                                nodes[key].Build(builder);
                                currentBlock.Add(key);
                                
                        }
                }
        }

        public void UpdateLocation(int tileIndex)
        {
                Vector2Int key = new Vector2Int(
                                currentPosition.x + centerChange[tileIndex].x,
                                currentPosition.y + centerChange[tileIndex].y
                        );

                foreach(Vector2Int v in currentBlock)
                {
                        nodes[v].Deconstruct(builder);  
                }
                currentBlock.Clear();
                currentNode = (nodes.ContainsKey(key)) ? nodes[key]:new DungeonNode(key.x, key.y);
                currentPosition = key;

                BuildBlock();
        }
}
