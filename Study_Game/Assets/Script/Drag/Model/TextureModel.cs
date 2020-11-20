using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextureModel
{
    [Header("Texture Puzzle Setting")]
    public Texture2D[] TexturePuzzle;
    [HideInInspector] public int ran_Num_Texture;
    [HideInInspector] public int ran_Num;
    [HideInInspector] public GameObject[] ran_Puzzle_Game;
    [HideInInspector] public int Lenght;
    [HideInInspector] public List<int> NumRandomTexture = new List<int>();
    [HideInInspector] public int[] list_Texture;
}
