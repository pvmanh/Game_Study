using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Puzzle 
{
    //ham tao puzzle
    public static void LoadPuzzleLevel(PuzzleModel puzzleData, Texture2D textureData, ImageModel imageData, List<RawImage> BasePuzzleObject)
    {
        puzzleData.txt_level.text = puzzleData.level.ToString();
        puzzleData.Lenght = puzzleData.Width * puzzleData.Height;

        //ImageView.RandomTexture(textureData, puzzleData);
        //tao so luong puzzle theo dien tich
        for (int i = 0; i < puzzleData.Lenght; i++)
        {
            //tao gameobject
            var GPuzzle = CutPuzzle.CreateObject(puzzleData.Puzzle_Game, puzzleData.Puzzle_Parent.transform);
            //Lay thong so imgcontrol
            puzzleData.pCon = GPuzzle.GetComponent<ImgControl>();
            //random x, y
            puzzleData.x = Random.Range(-53f, 53f);
            puzzleData.y = Random.Range(-80f, 80f);
            //set kich thuoc gameobject tren canvas co dinh
            puzzleData.pCon.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            puzzleData.pCon.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            puzzleData.pCon.rectTransform.localPosition = new Vector2(puzzleData.x, puzzleData.y);
            puzzleData.pCon.rectTransform.sizeDelta = new Vector2(100f, 80f);
            puzzleData.pCon.onParentRaw = true;
            BasePuzzleObject.Add(GPuzzle.GetComponent<RawImage>());
            puzzleData.pCon.RawPuzzle = puzzleData.Puzzle_Parent.transform;
        }
        //load anh
        ImageView.LoadRawTexture(puzzleData.Puzzle_Image_Raw, textureData);
        //load anh mau
        imageData.BaseImage = textureData;
        imageData.LoadDone = true;
    }
    //Kiem tra tro choi
    public static void CheckWinPuzzle(PuzzleModel puzzleData, TimeModel timeData, GameObject MenuSelectLevel, ImageModel imageData, List<RawImage> BasePuzzleObject)
    {
        puzzleData.iCount = puzzleData.ParentBase.transform.childCount;
        puzzleData.isTrueCount = 0;
        //Tim cac thanh phan con trong con de kiem tra theo tag cai dat san de kiem tra so luong puzzle dung vi tri
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
        //du dieu kien lvup
        if (puzzleData.iCount == puzzleData.isTrueCount)
        {
            //level dat gioi han bao xong tro choi
            if (puzzleData.level == puzzleData.level_limit)
                Debug.Log("Game Complete");
            //tien hanh lv up
            else
            {
                puzzleData.level++;
                puzzleData.Width++;
                puzzleData.Height++;
                //tinh lai dien tich
                puzzleData.Lenght = puzzleData.Width * puzzleData.Height;

                //Xoa toan bo child trong o chua grid
                foreach (Transform child in puzzleData.ParentBase.transform)
                {
                    foreach (Transform ChildPuzzle in child.transform)
                    {
                        //Destroy(ChildPuzzle.GetComponent<ImgControl>());
                        CutPuzzle.DestroyObject(ChildPuzzle.gameObject);
                    }
                }
                //cai dat lai thong so
                BasePuzzleObject.Clear();
                imageData.y = 1f;
                MenuSelectLevel.SetActive(true);
                GameObject.Find("/Canvas/Select-menu/Bottom/Rank-com").SetActive(true);
                GameObject.Find("/Canvas/Select-menu/Bottom/Rank-com/timecomplete").GetComponent<TextMeshProUGUI>().text = timeData.txt_time.text;
                puzzleData.levelup = true;
                //Puzzle.LoadPuzzleLevel(puzzleData, textureData, imageData, BasePuzzleObject);
            }
        }
    }
    //Ham random vi tri ngau nhien trong o chua theo xmin, xmax, ymin, ymax cai dat theo dien tich o chua
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
    //ham tao puzzle chon hinh khi bat dau moi man
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
