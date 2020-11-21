using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectModel
{
    [Header("Object Setting")]
    public int Level = 1;
    public float Width;
    public float Height;
    [HideInInspector] public float xMin = 0f;
    [HideInInspector] public float xMax = 0f;
    [HideInInspector] public float yMin = 1f;
    [HideInInspector] public float yMax = 1f;
    [HideInInspector] public float WidthValue = 0f;
    [HideInInspector] public float HeightValue = 0f;
}
