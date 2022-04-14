using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Test : MonoBehaviour
{
        [SerializeField] Tilemap myTile;
        [SerializeField] TileBase test;
        [SerializeField] TileBase test2;
        [SerializeField] int radius;
        List<Vector2Int> coords = new List<Vector2Int>();
        List<List<int>> matrix;
        // Start is called before the first frame update
        void Start()
        {
                /*
                int startRow = -1;
                int endRow = -1;
                matrix = new List<List<int>>();
                for (int i = 0; i < (radius * 2) + 1; i++)
                {
                        List<int> temp = new List<int>();
                        for (int j = 0; j < (radius * 2) + 1; j++)
                                temp.Add(0);
                        matrix.Add(temp);
                }
                
                for (int angle = 0; angle < 360; angle++) {
                        if (angle == 90 || angle == 0 || angle == 180 || angle == 270)
                                continue;
                        int x = (int) (radius * Mathf.Sin(Mathf.PI * 2 * angle / 360));
                        int y = (int)(radius * Mathf.Cos(Mathf.PI * 2 * angle / 360));
                        Vector2Int temp = new Vector2Int(x, y);
                        if (!coords.Contains(temp)){
                                coords.Add(temp);
                        }
                }

                int origin = (int)(matrix.Count / 2);

                for(int i = 0; i < coords.Count; i++)
                {
                        matrix[origin + coords[i].x][origin + coords[i].y] = 1;
                }
                
                for(int i = 0; i < matrix.Count; i++)
                {
                        int left = 0;
                        int right = matrix.Count - 1;
                        while(right > -1 && matrix[i][left] != 1 && matrix[i][right] != 1)
                        {
                                left++;
                                right--;
                        }
                        if (right > - 1 && matrix[i][right] == 1 && startRow == -1)
                        {
                                startRow = i;
                        }
                        if(right > -1 && matrix[i][right] == 1)
                        {
                                endRow = i;
                        }
                        while(left <= right)
                        {
                                matrix[i][right] = 1;
                                matrix[i][left] = 1;
                                left++;
                                right--;
                        }
                }
                startRow++;
                endRow--;
                SetTerrainFreeSpace(ref matrix,startRow, endRow);
                */
                CirclePreparation circle = new CirclePreparation(radius);
                new CircleTerrainShaper(1, ref circle);
                GetComponent<CircleTerrainDecorator>().DecorateBiome("Forest", ref circle);
                GetComponent<CircleTerrainDecorator>().BuildBiome("Forest", circle, myTile);
                /*string s = "";
                for (int i = 0; i < circle.matrix.Count; i++)
                {

                        for (int j = 0; j < circle.matrix.Count; j++)
                        {
                                s += circle.matrix[i][j].ToString();
                                if (circle.matrix[i][j] == 3)
                                        myTile.SetTile(new Vector3Int(i, j, 0), test);
                                if (circle.matrix[i][j] == 2)
                                        myTile.SetTile(new Vector3Int(i, j, 0), test2);
                        }
                        s += "\n\n";
                }
                s += "\n";*/
        }
}
