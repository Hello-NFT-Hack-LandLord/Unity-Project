using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CircleTerrainDecorator : MonoBehaviour
{
        [System.Serializable]
        public struct BiomeElementVariants
        {
                public List<TileBase> sprites;
                public List<float> probabilities;
        }
        [System.Serializable] public struct BiomeElement
        {
                public BiomeElementVariants variants;
        }
        [System.Serializable] public struct BiomeElementsInformation
        {
                public string elementName;
                public int key;
                public float probability;
                public List<BiomeElementVariants> biomeElementInfo;
        }

        [System.Serializable] public struct BiomeInformation
        {
                public string biomeName;
                public TileBase normalGround;
                public TileBase emptyGround;
                public List<BiomeElementsInformation> biomeElements;
        }


        public List<BiomeInformation> biomes;
       
        public void DecorateBiome(string biomeName,ref CirclePreparation circle)
        {
                BiomeInformation biome = GetBiome(biomeName);
                DecorationHelper(biome,ref circle);
        }

        public void BuildBiome(string biomeName, CirclePreparation circle, Tilemap myTilemap)
        {
                BiomeInformation biome = GetBiome(biomeName);

                for (int row = 0; row < circle.matrix.Count; row++)
                {
                        for (int col = 0; col < circle.matrix.Count; col++)
                        {
                                if(circle.matrix[row][col] == 2)
                                {
                                        myTilemap.SetTile(new Vector3Int(row, col, 0), biome.normalGround);
                                        continue;
                                }else if (circle.matrix[row][col] == 1)
                                {
                                        myTilemap.SetTile(new Vector3Int(row, col, 0), biome.emptyGround);
                                        continue;
                                }
                                for(int i = 0; i < biome.biomeElements.Count; i++)
                                {
                                        
                                        if (biome.biomeElements[i].key == circle.matrix[row][col])
                                        {
                                                for (int j = 0; j < biome.biomeElements[i].biomeElementInfo.Count; j++)
                                                {
                                                        bool placedTile = false;
                                                        for (int k = 0; k < biome.biomeElements[i].biomeElementInfo[j].probabilities.Count;k++) {
                                                                float number = Random.Range(0f, 1f);
                                                                if (number <= biome.biomeElements[i].biomeElementInfo[j].probabilities[k])
                                                                {
                                                                        placedTile = true;
                                                                        TileBase tile = biome.biomeElements[i].biomeElementInfo[j].sprites[k];
                                                                        myTilemap.SetTile(new Vector3Int(row, col, 0), tile);
                                                                        break;
                                                                }
                                                        }
                                                        if (placedTile)
                                                                break;
                                                }
                                        }
                                }
                        }
                }
        }

        private void DecorationHelper(BiomeInformation biome,ref CirclePreparation circle)
        {
                for (int row = 0; row < circle.matrix.Count; row++)
                {
                        for (int col = 0; col < circle.matrix.Count; col++)
                        {
                                if (circle.matrix[row][col] == 1)
                                {
                                        
                                        for (int i = 0; i < biome.biomeElements.Count; i++)
                                        {
                                                float number = Random.Range(0f, 1f);
                                                if (biome.biomeElements[i].probability >= number)
                                                {
                                                        circle.matrix[row][col] = biome.biomeElements[i].key;
                                                        break;
                                                }
                                        }
                                }
                        }
                }
        }

        private BiomeInformation GetBiome(string biomeName)
        {
                for (int i = 0; i < biomes.Count; i++)
                {
                        if (biomes[i].biomeName == biomeName)
                        {
                                return biomes[i];
                        }
                }
                return new BiomeInformation();
        }
}
