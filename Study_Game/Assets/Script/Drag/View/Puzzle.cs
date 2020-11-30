using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Puzzle 
{
    public static void LoadPuzzleLevel(PuzzleModel puzzleData, Texture2D textureData, ImageModel imageData, List<RawImage> BasePuzzleObject)
    {
        puzzleData.txt_level.text = puzzleData.level.ToString();
        puzzleData.Lenght = puzzleData.Width * puzzleData.Height;

        //ImageView.RandomTexture(textureData, puzzleData);

        for (int i = 0; i < puzzleData.Lenght; i++)
        {
            var GPuzzle = CutPuzzle.CreateObject(puzzleData.Puzzle_Game, puzzleData.Puzzle_Parent.transform);
            puzzleData.pCon = GPuzzle.GetComponent<ImgControl>();
            puzzleData.x = Random.Range(-53f, 53f);
            puzzleData.y = Random.Range(-80f, 80f);
            puzzleData.pCon.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            puzzleData.pCon.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            puzzleData.pCon.rectTransform.localPosition = new Vector2(puzzleData.x, puzzleData.y);
            puzzleData.pCon.rectTransform.sizeDelta = new Vector2(100f, 80f);
            puzzleData.pCon.onParentRaw = true;
            BasePuzzleObject.Add(GPuzzle.GetComponent<RawImage>());
            puzzleData.pCon.RawPuzzle = puzzleData.Puzzle_Parent.transform;
        }

        ImageView.LoadRawTexture(puzzleData.Puzzle_Image_Raw, textureData);

        imageData.BaseImage = textureData;
        imageData.LoadDone = true;
    }

    public static void CheckWinPuzzle(PuzzleModel puzzleData, TimeModel timeData, GameObject MenuSelectLevel, ImageModel imageData, List<RawImage> BasePuzzleObject)
    {
        puzzleData.iCount = puzzleData.ParentBase.transform.childCount;
        puzzleData.isTrueCount = 0;

        foreach (Transform child in puzzleData.ParentBase.transform)
        {
            foreach (Transform ChildPuzzle in child.transform)
            {
                if (child.GetComponent<ImgBasic>().TagValueImg == ChildPuzzle.GetComponent<ImgControl>().TagValueImg)
                {
                    puzzleData.isTrueCount++;
                    ChildPuzzle.GetComponent<ImgControl>().isTruePlace = true;
                }
            }
        }

        if (puzzleData.iCount == puzzleData.isTrueCount)
        {
            if (puzzleData.level == puzzleData.level_limit)
                Debug.Log("Game Complete");
            else
            {
                puzzleData.level++;
                puzzleData.Width++;
                puzzleData.Height++;

                puzzleData.Lenght = puzzleData.Width * puzzleData.Height;

                foreach (Transform child in puzzleData.ParentBase.transform)
                {
                    foreach (Transform ChildPuzzle in child.transform)
                    {
                        //Destroy(ChildPuzzle.GetComponent<ImgControl>());
                        CutPuzzle.DestroyObject(ChildPuzzle.gameObject);
                    }
                }
                BasePuzzleObject.Clear();
                imageData.y = 1f;
                MenuSelectLevel.SetActive(true);
                puzzleData.levelup = true;
                //Puzzle.LoadPuzzleLevel(puzzleData, textureData, imageData, BasePuzzleObject);
            }
        }
    }
    public static void RandomPuzzlePosition(PuzzleModel puzzleData)
    {
        foreach (Transform ChildPuzzle in puzzleData.Puzzle_Area)
        {
            puzzleData.Puzzle_Rect = ChildPuzzle.GetComponent<RectTransform>();
            puzzleData.x = Random.Range(puzzleData.xMin, puzzleData.xMax);
            puzzleData.y = Random.Range(puzzleData.yMin, puzzleData.yMax);
            puzzleData.Puzzle_Rect.localPosition = new Vector2(puzzleData.x, puzzleData.y);
        }
    }
    public static void LoadLevelImage(Texture2D[] listTexture, GameObject imgSD, Transform tposition)
    {
        for(int i = 0; i < listTexture.Length; i++)
        {
            var pImg = CutPuzzle.CreateObject(imgSD, tposition);
            pImg.transform.Find("img-show").gameObject.GetComponentInChildren<RawImage>().texture = listTexture[i];
            pImg.GetComponent<SelectLevelImg>().selectedTxture = listTexture[i];
        }
    }
}
