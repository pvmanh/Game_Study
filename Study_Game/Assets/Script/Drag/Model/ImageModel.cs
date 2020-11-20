using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ImageModel
{
    [Header("Image Puzzle Setting")]
    public Texture2D BaseImage;
    public bool LoadDone = false;
    [HideInInspector] public float WidthValue = 0f;
    [HideInInspector] public float HeightValue = 0f;
    [HideInInspector] public float x = 0f;
    [HideInInspector] public float y = 1f;
}
