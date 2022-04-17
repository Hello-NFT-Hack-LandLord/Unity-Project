using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePreparation 
{
        #region Attributes

        public int endRow;

        public List<List<int>> matrix = new List<List<int>>();

        private int origin;

        private int radius;

        public int startRow;

        #endregion
        #region Constructor
        public CirclePreparation(int radius)
        {
                this.radius = radius;
                startRow = -1 ;
                endRow = -1;
                origin = (this.radius * 2 + 1) / 2;
                GenerateCircle();
        }
        #endregion
        #region Methods
        
        private void FillCircle()
        {
                for (int i = 0; i < matrix.Count; i++)
                {
                        int left = 0;
                        int right = matrix.Count - 1;
                        while (right > -1 && matrix[i][left] != 1 && matrix[i][right] != 1)
                        {
                                left++;
                                right--;
                        }
                        if (right > -1 && matrix[i][right] == 1 && startRow == -1)
                        {
                                startRow = i;
                        }
                        if (right > -1 && matrix[i][right] == 1)
                        {
                                endRow = i;
                        }
                        while (left <= right)
                        {
                                matrix[i][right] = 1;
                                matrix[i][left] = 1;
                                left++;
                                right--;
                        }
                }
                startRow++;
                endRow--;
        }
       
        private void FillMatrix()
        {
                for (int row = 0; row < (radius * 2) + 1; row++)
                {
                        List<int> temp = new List<int>();
                        for (int column = 0; column < (radius * 2) + 1; column++)
                                temp.Add(0);
                        matrix.Add(temp);
                }
        } 
       
        private void GenerateCircle()
        {
                FillMatrix();
                CreateCirclePerimeter();
                FillCircle();
        }

        private void CreateCirclePerimeter()
        {
                for (int angle = 0; angle < 360; angle++)
                {
                        if (angle == 90 || angle == 0 || angle == 180 || angle == 270)
                              continue;
                        int x = (int)(radius * Mathf.Sin(Mathf.PI * 2 * angle / 360));
                        int y = (int)(radius * Mathf.Cos(Mathf.PI * 2 * angle / 360));
                        Vector2Int temp = new Vector2Int(x, y);
                        matrix[origin + x][origin + y] = 1;
                }
        }  
        #endregion
}
