using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPuzzle
{
    //tinh thong so grid
    public static float[] CaculatorValueGrid(float[] Value_Width_Height, PuzzleModel puzzleData)
    {
        Value_Width_Height = new float[2];
        Value_Width_Height[0] = 1f / puzzleData.Width;
        Value_Width_Height[1] = 1f / puzzleData.Height;
        return Value_Width_Height;
    }
    //ham level up
    public static void PuzzleLevelUp(PuzzleModel puzzleData, GameObject gridObject, GridModel gridData, float[] value_grid, Transform parent)
    {
        if (puzzleData.level != gridData.Level)
        {
            //xoa grid
            DestroyGridPuzzle(parent);
            //reset thong so
            gridData.xMin = gridData.xMax = 0f;
            gridData.yMin = gridData.yMax = 1f;
            //gridData.WidthValue = 1f / puzzleData.Width;
            //gridData.HeightValue = 1f / puzzleData.Height;
            //tinh lai thong so
            value_grid = CaculatorValueGrid(value_grid, puzzleData);
            //tao grid
            SplitGridPuzzle(gridData, gridObject, puzzleData, value_grid, parent);
            //level up
            gridData.Level++;
        }
    }
    //ham xoa toan bo con trong parent
    public static void DestroyGridPuzzle(Transform parent)
    {
        foreach (Transform child in parent)
        {
            CutPuzzle.DestroyObject(child.gameObject);   
        }
    }
    //ham cat grid
    public static void SplitGridPuzzle(GridModel gridData, GameObject gridObject, PuzzleModel puzzleData, float[] value_grid, Transform parent)
    {
        int k = 0;
        //thong so dau vao
        gridData.WidthValue = value_grid[0];
        gridData.HeightValue = value_grid[1];
        gridData.xMax += gridData.WidthValue;
        gridData.yMin -= gridData.HeightValue;
        for (int i = 0; i < puzzleData.Height; i++)
        {
            for (int j = 0; j < puzzleData.Width; j++)
            {
                // tao gameobject theo thong so tinh dc
                var NewGrid = CutPuzzle.CreateObject(gridObject, parent);
                NewGrid.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                NewGrid.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                NewGrid.GetComponent<RectTransform>().anchorMin = new Vector2(gridData.xMin, gridData.yMin);
                NewGrid.GetComponent<RectTransform>().anchorMax = new Vector2(gridData.xMax, gridData.yMax);
                NewGrid.GetComponent<ImgBasic>().TagValueImg = k;
                //thong so theo cot
                gridData.xMin += gridData.WidthValue;
                gridData.xMax += gridData.WidthValue;
                k++;
            }
            //thong so theo hang
            gridData.yMin -= gridData.HeightValue;
            gridData.yMax -= gridData.HeightValue;
            gridData.xMin = 0f;
            gridData.xMax = gridData.WidthValue;
        }
    }
}
