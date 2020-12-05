using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class PuzzleModel
{
    [Header("Random Puzzle Position Setting")]
    public Transform Puzzle_Area;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    [HideInInspector] public RectTransform Puzzle_Rect;
    [HideInInspector] public float x;
    [HideInInspector] public float y;

    [Header("Puzzle Setting")]
    public GameObject Puzzle_Game;
    public Transform Puzzle_Parent;
    public RawImage Puzzle_Image_Raw;
    public TextMeshProUGUI txt_level;
    public int Width;
    public int Height;
    public int level = 1;
    public int level_limit;
    [HideInInspector] public int Lenght;
    [HideInInspector] public ImgControl pCon;
    public GameObject ParentBase;
    [HideInInspector] public int iCount;
    [HideInInspector] public int isTrueCount;
    public bool levelup = false;
    public string str_name;
    public string str_class;
    public GameObject win_background;
    public GameObject btn_restart;
    public GameObject SFX;
}
