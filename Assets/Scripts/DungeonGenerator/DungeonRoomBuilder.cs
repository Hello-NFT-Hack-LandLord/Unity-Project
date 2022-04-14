using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DungeonRoomBuilder : MonoBehaviour
{

        [SerializeField] TileBase freeTile;
        [SerializeField] TileBase blockedTile;

        public void PlaceTile(int x, int y, int xOffset, int yOffset, bool isFree, int tileIndex)
        {
                
                if (isFree)
                {
                        Tilemap freeTilemap = GameObject.Find("Tile" + tileIndex.ToString()).transform.GetChild(0).GetComponent<Tilemap>();
                        freeTilemap.SetTile(new Vector3Int(x + xOffset, y + yOffset, 0), freeTile);
                }
                else
                {
                        Tilemap blockedTilemap = GameObject.Find("Tile" + tileIndex.ToString()).transform.GetChild(1).GetComponent<Tilemap>();
                        blockedTilemap.SetTile(new Vector3Int(x + xOffset, y + yOffset, 0), blockedTile);
                }
        }

        public void RemoveTile(int tileIndex)
        {

                Tilemap freeTilemap = GameObject.Find("Tile" + tileIndex.ToString()).transform.GetChild(0).GetComponent<Tilemap>();
                Tilemap blockedTilemap = GameObject.Find("Tile" + tileIndex.ToString()).transform.GetChild(1).GetComponent<Tilemap>();
                

                freeTilemap.ClearAllTiles();
                blockedTilemap.ClearAllTiles();
        }
}
