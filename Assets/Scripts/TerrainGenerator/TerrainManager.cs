using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainManager: MonoBehaviour
{
        [SerializeField] Tilemap myTilemap;
        public void Start()
        {
                CallTerrain();
                
        }
        public void CallTerrain()
        {
                LoadTerrain(Random.Range(int.MinValue, int.MaxValue));
        }
        public void LoadTerrain(int seed)
        {
                Random.InitState(seed);
                CirclePreparation circle = new CirclePreparation(15);
                new CircleTerrainShaper(1, ref circle);
                GetComponent<CircleTerrainDecorator>().DecorateBiome("Forest", ref circle);
                GetComponent<CircleTerrainDecorator>().BuildBiome("Forest", circle, myTilemap);
        }
}
